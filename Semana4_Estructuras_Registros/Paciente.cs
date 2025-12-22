// Registro que representa los datos de un paciente.
// Se usa record porque solo almacena información (registros).
public record Paciente(
    string Cedula,
    string Nombre,
    string Telefono
);
