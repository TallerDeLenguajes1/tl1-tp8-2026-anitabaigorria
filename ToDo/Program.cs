using espacioTarea;

List<Tarea> TareasPendientes = new List<Tarea>();
string ?ingreso;
int n, dur;

Console.Write("Ingrese la cantidad de tareas pendientes a cargar: ");
ingreso = Console.ReadLine();

if(int.TryParse(ingreso, out n))
{
    Random generador = new Random();
    for (int i = 0; i < n; i++)
    {
        Tarea tareaCargar = new Tarea(i+1,$"descripcion{i+1}",0);
        do
        {
            Console.Write("Ingrese la duracion: ");
            ingreso = Console.ReadLine();

            if (int.TryParse(ingreso, out dur))
            {
                if (tareaCargar.ValidarDuracion(dur))
                {
                    tareaCargar.Duracion = dur;
                } else
                {
                    Console.WriteLine("Incorrecto. Ingrese un numero entre 10 y 100");
                }
            } else
            {
               Console.WriteLine("Incorrecto. Ingrese un numero entre 10 y 100");
            }

            
        } while (int.TryParse(ingreso, out dur) == false || tareaCargar.ValidarDuracion(dur) == false);

        TareasPendientes.Add(tareaCargar); // en este caso ya generamos valores entre 10 y 100, no hace falta validar
        // new Tarea { TareaID = i+1, Descripcion = $"descripcion{i+1}" , Duracion = generador.Next(10, 101)}
    }

} else
{
    Console.WriteLine("Incorrecto, ingrese un numero");
}

foreach (Tarea t in TareasPendientes)
{
   Console.WriteLine($"{t.TareaID} - {t.Descripcion} - {t.Duracion}");
}


