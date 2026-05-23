using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Collections;

//Crear un diccionario donde la clave sea el legajo y el valor el alumno
//Incluir un método para agregar un alumno al diccionario
//Incluir un método para buscar un alumno utilizando la clave
//Incluir un método para retornar el diccionario
//Incluir un método para eliminar un alumno utilizando la clave
public class CasoDictionary
{
    // Campo privado para el diccionario (clave: int [legajo], valor: Alumno)
    private readonly Dictionary<int, Alumno> _diccionarioAlumnos = new Dictionary<int, Alumno>();

    // Incluir un método para agregar un alumno al diccionario
    public void AgregarAlumno(Alumno alumno)
    {
        if (!_diccionarioAlumnos.ContainsKey(alumno.Id))
        {
            _diccionarioAlumnos.Add(alumno.Id, alumno);
        }
    }

    // Incluir un método para buscar un alumno utilizando la clave
    public Alumno? BuscarPorLegajo(int legajo)
    {
        _diccionarioAlumnos.TryGetValue(legajo, out var alumno);
        return alumno;
    }

    // Incluir un método para retornar el diccionario
    public Dictionary<int, Alumno> ObtenerDiccionario()
    {
        return _diccionarioAlumnos;
    }

    // Incluir un método para eliminar un alumno utilizando la clave
    public bool EliminarPorLegajo(int legajo)
    {
        return _diccionarioAlumnos.Remove(legajo);
    }
}