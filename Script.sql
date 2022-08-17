CREATE DATABASE LEscogidoProgramacionNCapasAgosto

CREATE TABLE Alumno (
IdAlumno INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(50),
ApellidoPaterno VARCHAR(50),
ApellidoMaterno VARCHAR(50),
FechaNacimiento DATE,
Sexo CHAR
)

