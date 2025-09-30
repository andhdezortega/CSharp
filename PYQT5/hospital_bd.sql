-- 1. CREAR UNA TABLA

DROP TABLE IF EXISTS Consulta;

CREATE TABLE Consulta (
  numeroConsulta TEXT(10) NOT NULL,
  fecha          TEXT     NOT NULL,
  nombreMedico   TEXT(50) NOT NULL,
  deinpr         TEXT(20) NOT NULL,
  procedencia    TEXT(20) NOT NULL,
                 PRIMARY KEY (numeroConsulta)
);

-- 2. MOSTRAR LAS TABLAS DE UNA BASE DE DATOS

SELECT * FROM sqlite_master WHERE type = "table";

-- 3. MOSTRAR LA ESTRUCTURA DE UNA TABLA

SELECT sql FROM sqlite_master WHERE type = "table";

-- 4. INSERTAR REGISTROS A UNA TABLA

INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('1','2012-01-02','JUAN ANTONIO LEON LUIS','INDUCCION','URGENCIAS');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('2','2012-01-02','CONCEPCION HERNANDEZ MARTIN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('3','2012-01-02','CRISTINA OLIVER BARRECHEGUREN','CESAREA','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('4','2012-01-02','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('5','2012-01-02','LOURDES FATIMA YLLANA PEREZ','CESAREA','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('6','2012-01-02','LOURDES FATIMA YLLANA PEREZ','CESAREA','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('7','2012-01-02','TATIANA CUESTA GUARDIOLA','INDUCCION','URGENCIAS');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('8','2012-01-03','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('9','2012-01-03','CRISTINA OLIVER BARRECHEGUREN','CESAREA','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('10','2012-01-03','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('11','2012-01-03','LOURDES FATIMA YLLANA PEREZ','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('12','2012-01-03','LOURDES FATIMA YLLANA PEREZ','CESAREA','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('13','2012-01-04','VIRGINIA ORTEGA ABAD','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('14','2012-01-04','VIRGINIA ORTEGA ABAD','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('15','2012-01-04','VIRGINIA ORTEGA ABAD','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('16','2012-01-05','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('17','2012-01-05','LOURDES FATIMA YLLANA PEREZ','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('18','2012-01-06','MARIA CARMEN VIÑUELA BENEITEZ','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('19','2012-01-06','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('20','2012-01-06','RAQUEL MORENO MOLINA','INDUCCION','URGENCIAS');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('21','2012-01-06','VIRGINIA ORTEGA ABAD','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('22','2012-01-07','MARIA CARMEN VIÑUELA BENEITEZ','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('23','2012-01-07','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('24','2012-01-08','VIRGINIA ORTEGA ABAD','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('25','2012-01-09','ANA PEREDA','INDUCCION','URGENCIAS');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('26','2012-01-09','CONCEPCION HERNANDEZ MARTIN','CESAREA','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('27','2012-01-09','CONCEPCION HERNANDEZ MARTIN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('28','2012-01-09','CONCEPCION HERNANDEZ MARTIN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('29','2012-01-09','CRISTINA OLIVER BARRECHEGUREN','CESAREA','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('30','2012-01-10','CONCEPCION HERNANDEZ MARTIN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('31','2012-01-10','CONCEPCION HERNANDEZ MARTIN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('32','2012-01-10','CONCEPCION HERNANDEZ MARTIN','CESAREA','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('33','2012-01-10','CONCEPCION HERNANDEZ MARTIN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('34','2012-01-10','LOURDES FATIMA YLLANA PEREZ','CESAREA','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('35','2012-01-10','RAQUEL PEREZ LUCAS','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('36','2012-01-11','CONCEPCION HERNANDEZ MARTIN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('37','2012-01-11','CONCEPCION HERNANDEZ MARTIN','CESAREA','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('38','2012-01-11','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('39','2012-01-11','RAQUEL PEREZ LUCAS','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('40','2012-01-11','RAQUEL PEREZ LUCAS','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('41','2012-01-11','VIRGINIA ORTEGA ABAD','CESAREA','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('42','2012-01-11','VIRGINIA ORTEGA ABAD','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('43','2012-01-12','CONCEPCION HERNANDEZ MARTIN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('44','2012-01-12','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('45','2012-01-12','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('46','2012-01-12','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('47','2012-01-12','RAQUEL PEREZ LUCAS','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('48','2012-01-13','CONCEPCION HERNANDEZ MARTIN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('49','2012-01-13','RAQUEL PEREZ LUCAS','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('50','2012-01-13','RAQUEL PEREZ LUCAS','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('51','2012-01-13','RAQUEL PEREZ LUCAS','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('52','2012-01-13','VIRGINIA ORTEGA ABAD','CESAREA','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('53','2012-01-14','CONCEPCION HERNANDEZ MARTIN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('54','2012-01-14','MARIA LUZ BAEZ TORRE','INDUCCION','URGENCIAS');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('55','2012-01-15','CONCEPCION HERNANDEZ MARTIN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('56','2012-01-15','MARIA LUZ BAEZ TORRE','INDUCCION','URGENCIAS');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('57','2012-01-16','ANGEL AGUARON','INDUCCION','URGENCIAS');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('58','2012-01-16','MARIA CARMEN VIÑUELA BENEITEZ','CESAREA','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('59','2012-01-16','CONCEPCION HERNANDEZ MARTIN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('60','2012-01-16','RAQUEL PEREZ LUCAS','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('61','2012-01-16','RAQUEL PEREZ LUCAS','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('62','2012-01-16','RAQUEL PEREZ LUCAS','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('63','2012-01-17','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('64','2012-01-17','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('65','2012-01-17','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('66','2012-01-17','MARIA LUZ BAEZ TORRE','INDUCCION','URGENCIAS');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('67','2012-01-17','RAQUEL PEREZ LUCAS','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('68','2012-01-17','VIRGINIA ORTEGA ABAD','CESAREA','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('69','2012-01-17','VIRGINIA ORTEGA ABAD','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('70','2012-01-18','ANGEL AGUARON','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('71','2012-01-18','CONCEPCION HERNANDEZ MARTIN','CESAREA','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('72','2012-01-18','CRISTINA OLIVER BARRECHEGUREN','CESAREA','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('73','2012-01-18','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('74','2012-01-18','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('75','2012-01-18','LOURDES FATIMA YLLANA PEREZ','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('76','2012-01-18','RAQUEL PEREZ LUCAS','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('77','2012-01-19','MARIA CARMEN VIÑUELA BENEITEZ','CESAREA','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('78','2012-01-19','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('79','2012-01-19','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('80','2012-01-19','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('81','2012-01-19','MARIA PILAR PINTADO RECARTE','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('82','2012-01-19','RAQUEL PEREZ LUCAS','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('83','2012-01-20','CONCEPCION HERNANDEZ MARTIN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('84','2012-01-20','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('85','2012-01-20','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('86','2012-01-20','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('87','2012-01-20','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('88','2012-01-21','LOURDES FATIMA YLLANA PEREZ','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('89','2012-01-21','RAQUEL PEREZ LUCAS','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('90','2012-01-21','YOLANDA CUÑARRO LOPEZ','INDUCCION','URGENCIAS');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('91','2012-01-22','LOURDES FATIMA YLLANA PEREZ','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('92','2012-01-23','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('93','2012-01-23','CRISTINA OLIVER BARRECHEGUREN','CESAREA','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('94','2012-01-23','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('95','2012-01-23','LOURDES FATIMA YLLANA PEREZ','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('96','2012-01-23','MARIA PILAR PINTADO RECARTE','INDUCCION','CONSULTA');
INSERT INTO Consulta(numeroConsulta,fecha,nombreMedico,deinpr,procedencia) VALUES('97','2012-01-24','CRISTINA OLIVER BARRECHEGUREN','INDUCCION','CONSULTA');

-- 5. MOSTRAR TODOS LOS REGISTROS

SELECT * FROM Consulta;