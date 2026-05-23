using Dsw2026Ej11.Domain;
using System.Globalization;

namespace Dsw2026Ej11.Collections;

/*
 * Para cada punto crear un método que permita:
 * 1. Obtener el primer libro (GetPrimero)
 * 2. Obtener el último libro (GetUltimo)
 * 3. Obtener la suma de precios (GetTotalPrecios)
 * 4. Obtener el promedio de precios (GetPromedioPrecios)
 * 5. Obtener la lista de libros con Id mayor a 15 (GetListById)
 * 6. Obtener una lista de cada libro con su título y precio en formato moneda (GetLibros) (debe retornar una lista de string)
 * 7. Obtener el libro con el precio más alto (GetMayorPrecio)
 * 8. Obtener el libro con el precio más bajo (GetMenorPrecio)
 * 9. Obtener los libros cuyo precio sea mayor al promedio (GetMayorPromedio)
 * 10. Obtener los libros ordenados por título de forma descendente
 * En todos los casos debe aplicarse LINQ
 */
public class CasoLinq
{
    private readonly List<Libro> _libros = Libro.CrearLista();

    // 1. Obtener el primer libro (Uso seguro de FirstOrDefault)
    public Libro? GetPrimero()
    {
        return _libros.FirstOrDefault();
    }

    // 2. Obtener el último libro
    public Libro? GetUltimo()
    {
        return _libros.LastOrDefault();
    }

    // 3. Obtener la suma de precios
    public decimal GetTotalPrecios()
    {
        return _libros.Sum(l => l.Precio);
    }

    // 4. Obtener el promedio de precios
    public decimal GetPromedioPrecios()
    {
        return (decimal)_libros.Average(l => (double)l.Precio);
    }

    // 5. Obtener los libros con Id mayor a 15 (Usa IEnumerable evitando ToList interno)
    public IEnumerable<Libro> GetListById()
    {
        return _libros.Where(l => l.Id > 15);
    }

    // 6. Obtener títulos y precios formateados (Usa IEnumerable evitando ToList interno)
    public IEnumerable<string> GetLibros()
    {
        var culturaArg = new CultureInfo("es-AR");
        return _libros.Select(l => $"{l.Titulo} - {l.Precio.ToString("C", culturaArg)}");
    }

    // 7. Obtener el libro con el precio más alto
    public Libro? GetMayorPrecio()
    {
        return _libros.MaxBy(l => l.Precio);
    }

    // 8. Obtener el libro con el precio más bajo
    public Libro? GetMenorPrecio()
    {
        return _libros.MinBy(l => l.Precio);
    }

    // 9. Obtener los libros cuyo precio sea mayor al promedio
    public IEnumerable<Libro> GetMayorPromedio()
    {
        decimal promedio = GetPromedioPrecios();
        return _libros.Where(l => l.Precio > promedio);
    }

    // 10. Obtener los libros ordenados por título de forma descendente
    public IEnumerable<Libro> GetLibrosOrdenadosPorTituloDesc()
    {
        return _libros.OrderByDescending(l => l.Titulo);
    }
}