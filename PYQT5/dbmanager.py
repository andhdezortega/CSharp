import sqlite3

#ESTA ES LA CLASE QUE GESTIONA LA BASE DE DATOS

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