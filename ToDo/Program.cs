using espacioTarea;

List<Tarea> TareasPendientes = new List<Tarea>();
List<Tarea> TareasRealizadas = new List<Tarea>(); 
string? ingreso, opcionMenu;
int n; //dur;

do
{
    Console.WriteLine("╔══════════════════════════════════════════╗");
    Console.WriteLine("║            EJERCICIO 1 - TP8             ║");
    Console.WriteLine("╚══════════════════════════════════════════╝");
    Console.WriteLine("Presione 1 para cargar tareas pendientes (PUNTO 2)");
    Console.WriteLine("Presione 2 para mover una tarea a 'realizadas' (PUNTO 3)");
    Console.WriteLine("Presione 3 para buscar una tarea por su descripcion (PUNTO 4)");
    Console.WriteLine("Presione 4 para mostrar un listado de todas las tareas (PUNTO 5)");
    Console.WriteLine("Presione 0 para salir");
    Console.WriteLine("--------------------------------------------");
    Console.Write("Ingrese: ");
    
    opcionMenu = Console.ReadLine();

    switch (opcionMenu)
    {
        case "1":
            // PUNTO 2
            Console.WriteLine("--- PROGRAMA 1: CARGA DE TAREAS PENDIENTES ---");
            bool nValido = false;
            
            do
            {
                Console.Write("Ingrese la cantidad de tareas pendientes a cargar: ");
                ingreso = Console.ReadLine();

                if (int.TryParse(ingreso, out n) && n > 0)
                {
                    nValido = true;
                }
                else
                {
                    Console.WriteLine("Incorrecto, ingrese un número válido mayor a 0.");
                }
            } while (!nValido);

            Random generador = new Random();

            for (int i = 0; i < n; i++)
            {
                
                // -- PROCESO PARA CARGA MANUAL DE DURACION (CON VERIFICACION)
                // Tarea tareaCargar = new Tarea(i+1,$"descripcion{i+1}",0);
                // do
                // {
                //     Console.Write("Ingrese la duracion: ");
                //     ingreso = Console.ReadLine();

                //     if (int.TryParse(ingreso, out dur))
                //     {
                //         if (tareaCargar.ValidarDuracion(dur))
                //         {
                //             tareaCargar.Duracion = dur;
                //         } else
                //         {
                //             Console.WriteLine("Incorrecto. Ingrese un numero entre 10 y 100");
                //         }
                //     } else
                //     {
                //        Console.WriteLine("Incorrecto. Ingrese un numero entre 10 y 100");
                //     }

                    
                // } while (int.TryParse(ingreso, out dur) == false || tareaCargar.ValidarDuracion(dur) == false);

                Tarea tareaCargar = new Tarea(i + 1, $"descripcion{i + 1}", generador.Next(10, 101));
                TareasPendientes.Add(tareaCargar);
            }
            Console.WriteLine($"Se cargaron {n} tareas exitosamente.");
            break;

        case "2":
            // PUNTO 3
            Console.WriteLine("--- PROGRAMA 2: MOVIMIENTO DE TAREAS ---");
            if (TareasPendientes.Count == 0)
            {
                Console.WriteLine("No hay tareas pendientes para mover.");
                break;
            }

            Console.WriteLine("Tareas disponibles para mover:");
            foreach (Tarea t in TareasPendientes)
            {
                t.MostrarDatos();
            }

            int idmover;
            bool idEncontrado = false;

            do
            {
                Console.Write("Ingrese el ID de la tarea a mover: ");
                ingreso = Console.ReadLine();

                if (int.TryParse(ingreso, out idmover))
                {

                    int indiceEncontrado = -1;
                    
                    // buscamos en cada iteracion el indice, ya que si se lo modifica mas de una vez, las posiciones cambian
                    for (int i = 0; i < TareasPendientes.Count; i++)
                    {
                        if (TareasPendientes[i].TareaID == idmover)
                        {
                            indiceEncontrado = i;
                            break;
                        }
                    }

                    if (indiceEncontrado != -1)
                    {
                        TareasRealizadas.Add(TareasPendientes[indiceEncontrado]);
                        TareasPendientes.RemoveAt(indiceEncontrado);
                        idEncontrado = true;
                        Console.WriteLine($"¡La Tarea {idmover} fue movida a Realizadas con éxito!");
                    }
                    else
                    {
                        Console.WriteLine("Error: El ID ingresado no coincide con ninguna tarea pendiente.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Ingrese un ID numérico válido.");
                }
            } while (!idEncontrado);
            break;

        case "3":
            // PUNTO 4
            Console.WriteLine("--- PROGRAMA 3: BUSQUEDA SEGUN DESCRIPCION ---");
            Console.Write("Ingrese la descripcion o parte de la misma para filtrar: ");
            ingreso = Console.ReadLine();

            MostrarTareaDescrip(TareasPendientes, ingreso);
            MostrarTareaDescrip(TareasRealizadas, ingreso);
            break;

        case "4":
            // PUNTO 5
            Console.WriteLine("_________TAREAS PENDIENTES________");
            foreach (Tarea t in TareasPendientes)
            {
                t.MostrarDatos();
            }

            Console.WriteLine("_________TAREAS REALIZADAS________");
            foreach (Tarea t in TareasRealizadas)
            {
                t.MostrarDatos();
            }
            break;

        case "0":
            Console.WriteLine("Saliendo...");
            break;

        default:
            Console.WriteLine("Opcion invalida. Ingrese nuevamente.");
            break;
    }

} while (opcionMenu != "0");

// PUNTO 4 (funcion)
void MostrarTareaDescrip(List<Tarea> lista, string comparar)
{
    foreach (var Tarea in lista)
    {
       if (Tarea.Descripcion.ToLower().Contains(comparar.ToLower()))
       {
         Console.WriteLine($"[Tarea {Tarea.TareaID}] - {Tarea.Descripcion} ({Tarea.Duracion} días)");                  
       }
    }
}