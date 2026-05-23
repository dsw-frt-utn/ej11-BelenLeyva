using Dsw2026Ej11.Collections;
using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Tests;

internal class Ejemplos
{
    //Agregar 3 alumnos a la lista
    //Listar por consola los alumnos
    //Buscar por nombre un alumno que exista y mostrar por consola
    //Buscar por nombre un alumno que no exista y mostrar por consola el texto "No existe"
    //Eliminar un alumno y listar por consola los alumnos
    //Eliminar el primer elemento de la lista y listar por consola los alumnos
    public static void EjemploList()
    {
        Console.WriteLine("--- EJEMPLO LIST ---");
        CasoList casoList = new CasoList();

        var alu1 = new Alumno(23541, "Belén Leyva", 9.2);
        var alu2 = new Alumno(23542, "Juan Pérez", 6.5);
        var alu3 = new Alumno(23543, "María Sol", 8.0);

        casoList.AgregarAlumno(alu1);
        casoList.AgregarAlumno(alu2);
        casoList.AgregarAlumno(alu3);

        Console.WriteLine("Lista Inicial:");
        casoList.ObtenerAlumnos().ForEach(a => Console.WriteLine(a));

        Console.WriteLine("\nBuscando a 'Belén Leyva':");
        var buscado1 = casoList.BuscarPorNombre("Belén Leyva");
        Console.WriteLine(buscado1 != null ? buscado1.ToString() : "No existe");

        Console.WriteLine("\nBuscando a 'Carlos':");
        var buscado2 = casoList.BuscarPorNombre("Carlos");
        Console.WriteLine(buscado2 != null ? buscado2.ToString() : "No existe");

        Console.WriteLine("\nEliminando a 'Juan Pérez' de la lista:");
        casoList.EliminarAlumno(alu2);
        casoList.ObtenerAlumnos().ForEach(a => Console.WriteLine(a));

        Console.WriteLine("\nEliminando el primer elemento de la lista:");
        casoList.EliminarEnPosicion(0);
        casoList.ObtenerAlumnos().ForEach(a => Console.WriteLine(a));
    }

    //Agregar 3 alumnos al diccionario
    //Listar por consola los alumnos
    //Buscar un alumno por clave y mostrar por consola
    //Buscar un alumno por clave, pero que no exista, y mostrar por consola el texto "No existe"
    //Eliminar un alumno por clave y listar por consola los alumnos
    public static void EjemploDictionary()
    {
        Console.WriteLine("\n--- EJEMPLO DICTIONARY ---");
        CasoDictionary casoDict = new CasoDictionary();

        var alu1 = new Alumno(23541, "Belén Leyva", 9.2);
        var alu2 = new Alumno(23542, "Juan Pérez", 6.5);
        var alu3 = new Alumno(23543, "María Sol", 8.0);

        casoDict.AgregarAlumno(alu1);
        casoDict.AgregarAlumno(alu2);
        casoDict.AgregarAlumno(alu3);

        Console.WriteLine("Diccionario Inicial:");
        foreach (var kvp in casoDict.ObtenerDiccionario())
        {
            Console.WriteLine($"Clave [Legajo]: {kvp.Key} -> Alumno: {kvp.Value}");
        }

        Console.WriteLine("\nBuscar Legajo 23541:");
        var aluBuscado = casoDict.BuscarPorLegajo(23541);
        Console.WriteLine(aluBuscado != null ? aluBuscado.ToString() : "No existe");

        Console.WriteLine("\nBuscar Legajo 99999:");
        var aluInexistente = casoDict.BuscarPorLegajo(99999);
        Console.WriteLine(aluInexistente != null ? aluInexistente.ToString() : "No existe");

        Console.WriteLine("\nEliminando Legajo 23542:");
        casoDict.EliminarPorLegajo(23542);
        foreach (var kvp in casoDict.ObtenerDiccionario())
        {
            Console.WriteLine($"Clave [Legajo]: {kvp.Key} -> Alumno: {kvp.Value}");
        }
    }

    //Realizar una llamada a cada método definido en CasoLinq y mostrar por consola según corresponda
    public static void EjemploLinq()
    {
        Console.WriteLine("\n--- EJEMPLO LINQ ---");
        CasoLinq casoLinq = new CasoLinq();

        // Definimos la cultura de Argentina de forma local para corregir el error de "XDR"
        var culturaArg = new System.Globalization.CultureInfo("es-AR");

        Console.WriteLine($"1. Primer libro: {casoLinq.GetPrimero()?.Titulo ?? "No hay libros"}");
        Console.WriteLine($"2. Último libro: {casoLinq.GetUltimo()?.Titulo ?? "No hay libros"}");

        // Corregido: Aplicamos la cultura argentina en el ToString("C")
        Console.WriteLine($"3. Total de precios: {casoLinq.GetTotalPrecios().ToString("C", culturaArg)}");
        Console.WriteLine($"4. Promedio de precios: {casoLinq.GetPromedioPrecios().ToString("C", culturaArg)}");

        Console.WriteLine("\n5. Libros con ID > 15:");
        foreach (var libro in casoLinq.GetListById())
        {
            Console.WriteLine($"   ID: {libro.Id} - {libro.Titulo}");
        }

        Console.WriteLine("\n6. Lista de libros formateados (primeros 5):");
        int contLibros = 0;
        foreach (var libroFormateado in casoLinq.GetLibros())
        {
            if (contLibros >= 5) break;
            Console.WriteLine($"   {libroFormateado}");
            contLibros++;
        }
        Console.WriteLine("   ...");

        // Corregido: Formateo seguro para el libro más caro
        var masCaro = casoLinq.GetMayorPrecio();
        string precioMasCaro = masCaro != null ? masCaro.Precio.ToString("C", culturaArg) : "$0,00";
        Console.WriteLine($"\n7. Libro más caro: {masCaro?.Titulo ?? "N/C"} ({precioMasCaro})");

        // Corregido: Formateo seguro para el libro más barato
        var masBarato = casoLinq.GetMenorPrecio();
        string precioMasBarato = masBarato != null ? masBarato.Precio.ToString("C", culturaArg) : "$0,00";
        Console.WriteLine($"8. Libro más barato: {masBarato?.Titulo ?? "N/C"} ({precioMasBarato})");

        Console.WriteLine("\n9. Libros con precio mayor al promedio (primeros 3):");
        int contPromedio = 0;
        foreach (var libro in casoLinq.GetMayorPromedio())
        {
            if (contPromedio >= 3) break;
            // Corregido: Añadida la cultura argentina dentro del bucle
            Console.WriteLine($"   {libro.Titulo} ({libro.Precio.ToString("C", culturaArg)})");
            contPromedio++;
        }
        Console.WriteLine("   ...");

        Console.WriteLine("\n10. Libros ordenados por título desc (primeros 3):");
        int contOrden = 0;
        foreach (var libro in casoLinq.GetLibrosOrdenadosPorTituloDesc())
        {
            if (contOrden >= 3) break;
            Console.WriteLine($"   {libro.Titulo}");
            contOrden++;
        }
    }