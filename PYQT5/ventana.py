import sys, os, sqlite3
from PyQt5.QtWidgets import (
    QApplication, QMainWindow, QWidget, QLabel, QLineEdit, QPushButton,
    QMessageBox, QComboBox, QVBoxLayout, QHBoxLayout, QFormLayout
)
from PyQt5.QtGui import QIcon

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
        conn.commit() # CONFIRMAR LOS CAMBIOS
        conn.close()
        return cursor.rowcount

# DISEÑO + LOGICA
class Ventana(QMainWindow):
    def __init__(self):
        super().__init__()
        self.db = DBManager()  # usar la clase de gestión de BD
        self.initialize_component()

    def initialize_component(self):
        self.personalizar_ventana()
        self.personalizar_componentes()
        self.cargar_numero_consultas()

    def personalizar_ventana(self):
        self.setWindowTitle("GESTION CONSULTA HOSPITAL")

        
        self.setWindowIcon(QIcon("C:/Program Files/dotnet/ProyectosCSHARP/Examen/PYQT5/hospital.ico"))

        self.setFixedSize(400, 220) #ancho, alto
        self.setStyleSheet("""
            QMainWindow {
                background-color: lightgray; /* fondo gris claro */
            }
            QMenuBar {
                background-color: white;     /* barra de menú blanca */
                color: black;
            }
            QMenuBar::item {
                background-color: white;
                color: black;
            }
            QMenuBar::item:selected {
                background-color: #cfd8dc;   /* gris muy claro cuando pasas el mouse */
            }
            QToolBar {
                background-color: white;     /* toolbars blancas */
            }
            QStatusBar {
                background-color: white;     /* barra de estado blanca */
                color: black;
            }
        """)
        

        self.pnlPrincipal = QWidget()
        self.setCentralWidget(self.pnlPrincipal)

    def personalizar_componentes(self):
        #-----------------------------------------------------------------------------
        lienzo_principal = QVBoxLayout() # Crear un objeto lienzo principal

        # ==== Selección de producto ====
        lienzoH_1 = QHBoxLayout() #Crear un objeto lienzo 1

        lblSeleccion = QLabel("Selecciona ID:")
        self.cbConsultas = QComboBox()

        self.cbConsultas.currentIndexChanged.connect(self.cargar_consultas)

        lienzoH_1.addWidget(lblSeleccion)
        lienzoH_1.addWidget(self.cbConsultas)
        #-----------------------------------------------------------------------------
        # ==== Formulario de producto ====
        
        lienzo_formulario = QFormLayout()
        self.txtCampos = {}
        etiquetas = ["NC:", "Fecha:", "Nombre:", "Deinpr:", "Procedencia:"]

        for texto in etiquetas:
            txt = QLineEdit()
            if texto == "NC:":
               txt.setReadOnly(True)
            self.txtCampos[texto] = txt # Key(texto),Value(txt)
            lienzo_formulario.addRow(QLabel(texto), txt)

        

        #-----------------------------------------------------------------------------
        # ==== Botones ====
        lienzoH_2 = QHBoxLayout()

        self.btnInsertar = QPushButton("Insertar")
        self.btnInsertar.clicked.connect(self.insertar_consulta)

        self.btnActualizar = QPushButton("Actualizar")
        self.btnActualizar.clicked.connect(self.actualizar_consulta)

        self.btnEliminar = QPushButton("Eliminar")
        self.btnEliminar.clicked.connect(self.eliminar_consulta)

        self.btnLimpiar = QPushButton("Limpiar")
        self.btnLimpiar.clicked.connect(self.limpiar_campos)

        lienzoH_2.addWidget(self.btnInsertar)
        lienzoH_2.addWidget(self.btnActualizar)
        lienzoH_2.addWidget(self.btnEliminar)
        lienzoH_2.addWidget(self.btnLimpiar)
        
        '''
        for btn in [self.btnInsertar, self.btnActualizar, self.btnEliminar, self.btnLimpiar]:
            hlayoutBotones.addWidget(btn)
        '''
        #-----------------------------------------------------------------------------
        
        
        lienzo_principal.addLayout(lienzoH_1)
        lienzo_principal.addLayout(lienzo_formulario)
        lienzo_principal.addLayout(lienzoH_2)

        self.pnlPrincipal.setLayout(lienzo_principal) 

    def cargar_numero_consultas(self):
        self.cbConsultas.clear()
        lista_tuplas = self.db.query("SELECT * FROM Consulta")
        for tupla in lista_tuplas:
            self.cbConsultas.addItem(str(tupla[0]))


    def cargar_consultas(self):
        if self.cbConsultas.currentText() == "":
           return
        
        numero_consulta = self.cbConsultas.currentText()
        lista_tuplas = self.db.query("SELECT * FROM Consulta WHERE numeroConsulta=?", (numero_consulta,))

        if lista_tuplas:
            mitupla = lista_tuplas[0]
            self.txtCampos["NC:"].setText(mitupla[0])
            self.txtCampos["Fecha:"].setText(mitupla[1])
            self.txtCampos["Nombre:"].setText(mitupla[2])
            self.txtCampos["Deinpr:"].setText(mitupla[3])
            self.txtCampos["Procedencia:"].setText(mitupla[4])
    
    def limpiar_campos(self):
        for txt in self.txtCampos.values():
            txt.clear()
        self.cbConsultas.setCurrentIndex(-1)

    def insertar_consulta(self):
        nc = str(self.generar_numero_consulta())
        self.txtCampos["NC:"].setText(nc)
        fecha = self.txtCampos["Fecha:"].text()
        nombre = self.txtCampos["Nombre:"].text()
        deinpr = self.txtCampos["Deinpr:"].text()
        procedencia = self.txtCampos["Procedencia:"].text()

        if not (nc and fecha and nombre and deinpr and procedencia):
            QMessageBox.warning(self, "Advertencia", "Todos los campos deben estar completos.")
            return

        numero_filas = self.db.execute("""INSERT INTO Consulta
                                   (numeroConsulta, fecha, nombreMedico, deinpr, procedencia)
                                   VALUES (?, ?, ?, ?, ?)""",(nc,fecha,nombre,deinpr,procedencia))

        if numero_filas > 0:
            QMessageBox.information(self, "Éxito", "Consulta insertado correctamente.")
            self.cargar_numero_consultas()
            self.limpiar_campos()   

    def generar_numero_consulta(self):
        lista_tupla = self.db.query("SELECT COUNT(*)+1 FROM Consulta")# [(30)]
        tupla = lista_tupla[0] # (30)
        return tupla[0] # 30
    
    def actualizar_consulta(self):
        numero_consulta = self.txtCampos["NC:"].text()
        if not numero_consulta: # hay contenido = true, no hay contenido = false
            QMessageBox.warning(self, "Advertencia", "Seleccione un consulta para actualizar.")
            return

        nc = self.txtCampos["NC:"].text()
        fecha = self.txtCampos["Fecha:"].text()
        nombre = self.txtCampos["Nombre:"].text()
        deinpr = self.txtCampos["Deinpr:"].text()
        procedencia = self.txtCampos["Procedencia:"].text()

        if not (nc and fecha and nombre and deinpr and procedencia):
            QMessageBox.warning(self, "Advertencia", "Todos los campos deben estar completos.")
            return

        numero_filas_afectadas = self.db.execute('''UPDATE Consulta SET 
                                  fecha=?, nombreMedico=?, deinpr=?, procedencia=? 
                                  WHERE numeroConsulta=?''',
                                (fecha, nombre, deinpr, procedencia, nc))
        """
        comentario
        varias
        filas
        """
        if numero_filas_afectadas > 0:
            QMessageBox.information(self, "Éxito", "Consulta actualizado correctamente.")
            self.cargar_numero_consultas()

    def eliminar_consulta(self):
        numero_consulta = self.txtCampos["NC:"].text()
        if not numero_consulta:
            QMessageBox.warning(self, "Advertencia", "Seleccione un consulta para eliminar.")
            return

        numero_filas_afectadas = self.db.execute("DELETE FROM Consulta WHERE numeroConsulta=?", (numero_consulta,))
        if numero_filas_afectadas > 0:
            QMessageBox.information(self, "Éxito", "Consulta eliminado correctamente.")
            self.cargar_numero_consultas()
            self.limpiar_campos()


    
# ============================
# MAIN
# ============================
if __name__ == "__main__":
    app = QApplication(sys.argv)
    ventana = Ventana()
    ventana.show()
    sys.exit(app.exec_())