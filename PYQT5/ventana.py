import sys, sqlite3
from PyQt5.QtWidgets import (
    QApplication, QMainWindow, QWidget, QLabel, QLineEdit, QPushButton,
    QMessageBox, QComboBox, QVBoxLayout, QHBoxLayout, QFormLayout
)
from PyQt5.QtGui import QIcon, QFont



class DBManager:
    def __init__(self, db_name="hospital.sqlite3"):
        self.db_name = db_name

    # SELECT (READ)
    def query(self, sql, params=()):
        conn = sqlite3.connect(self.db_name)
        cursor = conn.cursor()
        cursor.execute(sql, params)
        results = cursor.fetchall()
        conn.close()
        return results

    # INSERT UPDATE DELETE (CREATE UPDATE DELETE)
    def execute(self, sql, params=()):
        conn = sqlite3.connect(self.db_name)
        cursor = conn.cursor()
        cursor.execute(sql, params)
        conn.commit()
        rowcount = cursor.rowcount
        conn.close()
        return rowcount


class Ventana(QMainWindow):
    def __init__(self):
        super().__init__()
        self.db = DBManager()
        self.initialize_component()

    def initialize_component(self):
        self.personalizar_ventana()
        self.personalizar_componentes()
        self.cargar_numero_consultas()

    def personalizar_ventana(self):
        self.setWindowTitle("GESTION CONSULTA HOSPITAL")
        self.setWindowIcon(QIcon("C:/Program Files/dotnet/ProyectosCSHARP/Examen/PYQT5/hospital.ico"))
        self.setFixedSize(600, 300)

        self.pnlPrincipal = QWidget()
        self.setCentralWidget(self.pnlPrincipal)

    def personalizar_componentes(self):
        layout_principal = QVBoxLayout()
        fuente_general = QFont("Arial", 14)

        # Selección de consulta
        layout_h1 = QHBoxLayout()
        lblSeleccion = QLabel("Selecciona ID:")
        self.cbConsultas = QComboBox()
        self.cbConsultas.currentIndexChanged.connect(self.cargar_consultas)
        layout_h1.addWidget(lblSeleccion)
        layout_h1.addWidget(self.cbConsultas)

        # Formulario
        layout_formulario = QFormLayout()
        self.txtCampos = {}
        etiquetas = ["NC:", "Fecha:", "Nombre:", "Deinpr:", "Procedencia:"]
        for texto in etiquetas:
            txt = QLineEdit()
            if texto == "NC:":
                txt.setReadOnly(True)
            self.txtCampos[texto] = txt
            layout_formulario.addRow(QLabel(texto), txt)

        # Botones
        layout_h2 = QHBoxLayout()
        self.btnInsertar = QPushButton("Insertar")
        self.btnInsertar.clicked.connect(self.insertar_consulta)
        self.btnActualizar = QPushButton("Actualizar")
        self.btnActualizar.clicked.connect(self.actualizar_consulta)
        self.btnEliminar = QPushButton("Eliminar")
        self.btnEliminar.clicked.connect(self.eliminar_consulta)
        self.btnLimpiar = QPushButton("Limpiar")
        self.btnLimpiar.clicked.connect(self.limpiar_campos)

        for btn in [self.btnInsertar, self.btnActualizar, self.btnEliminar, self.btnLimpiar]:
            layout_h2.addWidget(btn)

        layout_principal.addLayout(layout_h1)
        layout_principal.addLayout(layout_formulario)
        layout_principal.addLayout(layout_h2)
        self.pnlPrincipal.setLayout(layout_principal)

    def cargar_numero_consultas(self):
        self.cbConsultas.clear()
        lista = self.db.query("SELECT numeroConsulta FROM Consulta ORDER BY CAST(numeroConsulta AS INTEGER)")
        for tupla in lista:
            self.cbConsultas.addItem(str(tupla[0]))

    def cargar_consultas(self):
        if not self.cbConsultas.currentText():
            return
        nc = self.cbConsultas.currentText()
        lista = self.db.query("SELECT * FROM Consulta WHERE numeroConsulta=?", (nc,))
        if lista:
            fila = lista[0]
            self.txtCampos["NC:"].setText(fila[0])
            self.txtCampos["Fecha:"].setText(fila[1])
            self.txtCampos["Nombre:"].setText(fila[2])
            self.txtCampos["Deinpr:"].setText(fila[3])
            self.txtCampos["Procedencia:"].setText(fila[4])

    def limpiar_campos(self):
        for txt in self.txtCampos.values():
            txt.clear()
        self.cbConsultas.setCurrentIndex(-1)

    def generar_numero_consulta(self):
        # Convertimos a INTEGER para obtener el max correctamente
        lista = self.db.query("SELECT COALESCE(MAX(CAST(numeroConsulta AS INTEGER)), 0) + 1 FROM Consulta")
        return str(lista[0][0])

    def insertar_consulta(self):
        try:
            nc = self.generar_numero_consulta()
            self.txtCampos["NC:"].setText(nc)
            fecha = self.txtCampos["Fecha:"].text().strip()
            nombre = self.txtCampos["Nombre:"].text().strip()
            deinpr = self.txtCampos["Deinpr:"].text().strip()
            procedencia = self.txtCampos["Procedencia:"].text().strip()

            if not all([nc, fecha, nombre, deinpr, procedencia]):
                QMessageBox.warning(self, "Advertencia", "Todos los campos deben estar completos.")
                return

            self.db.execute(
                "INSERT INTO Consulta(numeroConsulta, fecha, nombreMedico, deinpr, procedencia) VALUES (?, ?, ?, ?, ?)",
                (nc, fecha, nombre, deinpr, procedencia)
            )
            QMessageBox.information(self, "Éxito", "Consulta insertada correctamente.")
            self.cargar_numero_consultas()
            self.limpiar_campos()

        except sqlite3.IntegrityError as e:
            QMessageBox.critical(self, "Error", f"No se pudo insertar la consulta (clave duplicada): {e}")
        except Exception as e:
            QMessageBox.critical(self, "Error", f"Ocurrió un error inesperado: {e}")

    def actualizar_consulta(self):
        nc = self.txtCampos["NC:"].text().strip()
        if not nc:
            QMessageBox.warning(self, "Advertencia", "Seleccione un consulta para actualizar.")
            return

        fecha = self.txtCampos["Fecha:"].text().strip()
        nombre = self.txtCampos["Nombre:"].text().strip()
        deinpr = self.txtCampos["Deinpr:"].text().strip()
        procedencia = self.txtCampos["Procedencia:"].text().strip()

        if not all([nc, fecha, nombre, deinpr, procedencia]):
            QMessageBox.warning(self, "Advertencia", "Todos los campos deben estar completos.")
            return

        self.db.execute(
            "UPDATE Consulta SET fecha=?, nombreMedico=?, deinpr=?, procedencia=? WHERE numeroConsulta=?",
            (fecha, nombre, deinpr, procedencia, nc)
        )
        QMessageBox.information(self, "Éxito", "Consulta actualizada correctamente.")
        self.cargar_numero_consultas()

    def eliminar_consulta(self):
        nc = self.txtCampos["NC:"].text().strip()
        if not nc:
            QMessageBox.warning(self, "Advertencia", "Seleccione un consulta para eliminar.")
            return

        self.db.execute("DELETE FROM Consulta WHERE numeroConsulta=?", (nc,))
        QMessageBox.information(self, "Éxito", "Consulta eliminada correctamente.")
        self.cargar_numero_consultas()
        self.limpiar_campos()


if __name__ == "__main__":
    app = QApplication(sys.argv)
    ventana = Ventana()
    ventana.show()
    sys.exit(app.exec_())
