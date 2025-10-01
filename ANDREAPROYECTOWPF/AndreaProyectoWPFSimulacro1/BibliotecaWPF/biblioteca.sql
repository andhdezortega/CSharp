-- Crear tabla solo si no existe
CREATE TABLE IF NOT EXISTS Libro (
    IdLibro INTEGER PRIMARY KEY AUTOINCREMENT,
    Titulo TEXT NOT NULL,
    Autor TEXT NOT NULL,
    Anio INTEGER NOT NULL,
    Genero TEXT NOT NULL
);

-- Limpiar tabla
DELETE FROM Libro;
DELETE FROM sqlite_sequence WHERE name='Libro';

-- Insertar 10 libros de ejemplo
INSERT INTO Libro (Titulo, Autor, Anio, Genero) VALUES
('Cien Años de Soledad', 'Gabriel García Márquez', 1967, 'Realismo mágico'),
('Don Quijote de la Mancha', 'Miguel de Cervantes', 1605, 'Novela'),
('El Principito', 'Antoine de Saint-Exupéry', 1943, 'Infantil'),
('1984', 'George Orwell', 1949, 'Distopía'),
('Crimen y Castigo', 'Fiódor Dostoyevski', 1866, 'Novela'),
('Orgullo y Prejuicio', 'Jane Austen', 1813, 'Romance'),
('El Hobbit', 'J.R.R. Tolkien', 1937, 'Fantasía'),
('Moby Dick', 'Herman Melville', 1851, 'Aventura'),
('Harry Potter y la Piedra Filosofal', 'J.K. Rowling', 1997, 'Fantasía'),
('El Código Da Vinci', 'Dan Brown', 2003, 'Misterio');
