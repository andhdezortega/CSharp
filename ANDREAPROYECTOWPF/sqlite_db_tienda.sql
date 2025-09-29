-- Crear tabla solo si no existe
CREATE TABLE IF NOT EXISTS Producto (
    id_producto INTEGER PRIMARY KEY AUTOINCREMENT,
    nombre TEXT NOT NULL,
    precio REAL NOT NULL,
    stock INTEGER DEFAULT 0,
    fecha_creacion DATE NOT NULL,
    disponible BOOLEAN NOT NULL DEFAULT 1,
    categoria TEXT NOT NULL
);

-- Eliminar registros (si existen)
DELETE FROM Producto;

-- Reiniciar el autoincremento (solo si existe la secuencia)
DELETE FROM sqlite_sequence WHERE name = 'Producto';

-- Insertar 50 registros
INSERT INTO Producto (nombre, precio, stock, fecha_creacion, disponible, categoria)
VALUES
('Laptop Lenovo', 850.75, 10, '2025-09-09', 1, 'Electrónica'),
('Mouse Logitech', 25.99, 50, '2025-09-08', 1, 'Accesorios'),
('Silla Gamer', 199.90, 15, '2025-09-05', 1, 'Muebles'),
('Cuaderno A4', 3.50, 200, '2025-09-01', 1, 'Papelería'),
('Teléfono Samsung', 699.00, 5, '2025-09-03', 0, 'Electrónica'),

('Teclado Mecánico', 79.99, 30, '2025-09-02', 1, 'Accesorios'),
('Monitor LG 24"', 189.50, 12, '2025-09-04', 1, 'Electrónica'),
('Escritorio Oficina', 250.00, 8, '2025-09-06', 1, 'Muebles'),
('Audífonos Sony', 120.00, 20, '2025-09-07', 1, 'Accesorios'),
('Impresora HP', 140.00, 7, '2025-09-08', 1, 'Electrónica'),

('Calculadora Casio', 15.75, 60, '2025-09-01', 1, 'Papelería'),
('Bolígrafo Azul', 1.20, 500, '2025-09-02', 1, 'Papelería'),
('Tablet iPad', 999.00, 3, '2025-09-03', 1, 'Electrónica'),
('Auriculares JBL', 59.99, 25, '2025-09-04', 1, 'Accesorios'),
('Router TP-Link', 49.99, 18, '2025-09-05', 1, 'Electrónica'),

('Silla Oficina', 130.00, 11, '2025-09-06', 1, 'Muebles'),
('Papel Resma A4', 5.00, 300, '2025-09-07', 1, 'Papelería'),
('Disco Duro 1TB', 75.00, 14, '2025-09-08', 1, 'Electrónica'),
('Memoria USB 32GB', 12.00, 100, '2025-09-09', 1, 'Accesorios'),
('Smartwatch Xiaomi', 149.90, 9, '2025-09-02', 1, 'Electrónica'),

('Cámara Canon', 450.00, 6, '2025-09-03', 1, 'Electrónica'),
('Mochila Laptop', 39.99, 40, '2025-09-04', 1, 'Accesorios'),
('Archivador Metálico', 220.00, 5, '2025-09-05', 1, 'Muebles'),
('Regla 30cm', 0.99, 250, '2025-09-06', 1, 'Papelería'),
('Teléfono iPhone', 1299.00, 4, '2025-09-07', 1, 'Electrónica'),

('Proyector Epson', 350.00, 7, '2025-09-08', 1, 'Electrónica'),
('Cafetera Philips', 85.00, 10, '2025-09-09', 1, 'Electrodomésticos'),
('Sofá 3 Plazas', 599.00, 2, '2025-09-01', 1, 'Muebles'),
('Lámpara Escritorio', 19.99, 50, '2025-09-02', 1, 'Accesorios'),
('Cámara Web Logitech', 69.99, 13, '2025-09-03', 1, 'Electrónica'),

('Micrófono USB', 89.99, 9, '2025-09-04', 1, 'Accesorios'),
('Almohada Memory Foam', 25.00, 30, '2025-09-05', 1, 'Muebles'),
('Cargador Samsung', 29.99, 45, '2025-09-06', 1, 'Accesorios'),
('Pizarra Blanca', 75.00, 6, '2025-09-07', 1, 'Papelería'),
('Smart TV LG 55"', 799.00, 5, '2025-09-08', 1, 'Electrónica'),

('Bicicleta Montaña', 350.00, 4, '2025-09-09', 1, 'Deportes'),
('Raqueta Tenis', 120.00, 15, '2025-09-01', 1, 'Deportes'),
('Balón Fútbol', 25.00, 40, '2025-09-02', 1, 'Deportes'),
('Zapatos Running', 75.00, 20, '2025-09-03', 1, 'Deportes'),
('Guantes Gimnasio', 15.00, 60, '2025-09-04', 1, 'Deportes'),

('Camiseta Deportiva', 20.00, 35, '2025-09-05', 1, 'Deportes'),
('Mancuernas 10kg', 55.00, 12, '2025-09-06', 1, 'Deportes'),
('Colchón Queen', 450.00, 3, '2025-09-07', 1, 'Muebles'),
('Estante Librero', 180.00, 6, '2025-09-08', 1, 'Muebles'),
('Mousepad Grande', 14.99, 70, '2025-09-09', 1, 'Accesorios'),

('Ventilador Orbegozo', 60.00, 9, '2025-09-01', 1, 'Electrodomésticos'),
('Plancha Philips', 45.00, 15, '2025-09-02', 1, 'Electrodomésticos'),
('Aspiradora Bosch', 150.00, 5, '2025-09-03', 1, 'Electrodomésticos'),
('Secadora Remington', 65.00, 8, '2025-09-04', 1, 'Electrodomésticos'),
('Horno Microondas', 120.00, 7, '2025-09-05', 1, 'Electrodomésticos');