using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Collections;

//Crear un campo que represente una lista de alumnos (List<>)
//Incluir un método para agregar alumnos a la lista
//Incluir un método para retornar la lista
//Incluir un método para buscar un alumno por nombre
//Incluir un método para eliminar un alumno (debe recibir un alumno)
//Incluir un método para eliminar un alumno en una determinada posición de la lista
public class CasoList
{
    // Campo privado para la lista de alumnos
    private readonly List<Alumno> _alumnos = new List<Alumno>();

    // Incluir un método para agregar alumnos a la lista
    public void AgregarAlumno(Alumno alumno)
    {
        _alumnos.Add(alumno);
    }

    // Incluir un método para retornar la lista
    public List<Alumno> ObtenerAlumnos()
    {
        return _alumnos;
    }

    // Incluir un método para buscar un alumno por nombre
    public Alumno? BuscarPorNombre(string nombre)
    {
        return _alumnos.Find(a => a.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
    }

    // Incluir un método para eliminar un alumno (debe recibir un alumno)
    public bool EliminarAlumno(Alumno alumno)
    {
        return _alumnos.Remove(alumno);
    }

    // Incluir un método para eliminar un alumno en una determinada posición de la lista
    public void EliminarEnPosicion(int posicion)
    {
        if (posicion >= 0 && posicion < _alumnos.Count)
        {
            _alumnos.RemoveAt(posicion);
        }
    }
}