-- Crear la tabla Autor
CREATE TABLE Autor (
    id INT PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);

-- Crear la tabla Libro
CREATE TABLE Libro (
    id INT PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    chapters INT NOT NULL,
    pages INT NOT NULL,
    price INT NOT NULL,
    author_id INT NOT NULL
);

-- Insertar datos en la tabla Autor
INSERT INTO Autor (id, name)
VALUES
    (1, 'Gabriel'),
    (2, 'Jaquelin'),
    (3, 'Diana');

-- Insertar datos en la tabla Libro
INSERT INTO Libro (id, title, chapters, pages, price, author_id)
VALUES
    (1, 'Star Wars', 10, 200, 19, 1),
    (2, 'Percy Jackson', 8, 150, 14, 2),
    (3, 'Lola', 12, 250, 24, 3);

-- Cadena de conexion
Scaffold-DbContext "Server=DESKTOP-U0CTJAL\SQLEXPRESS;Database=libreria;Trust Server Certificate=true;User Id=sa;Password=12345;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -ContextDir "Context" -OutputDir "Models"
