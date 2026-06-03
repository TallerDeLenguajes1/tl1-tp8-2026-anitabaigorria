using espacioCalculadora;

string ?eleccion, operar;
double numero;
Calculadora pruebaC = new Calculadora();

do
{
    Console.WriteLine("");
    Console.WriteLine("-------- CALCULADORA --------");
    Console.WriteLine($"¿Qué operación desea realizarle a dato? Actualmente tiene el valor {pruebaC.Resultado}");
    Console.WriteLine("1 = Sumarle un valor ingresado");
    Console.WriteLine("2 = Restarle un valor ingresado");
    Console.WriteLine("3 = Multiplicar un valor ingresado");
    Console.WriteLine("4 = Dividir un valor ingresado");
    Console.WriteLine("5 = Limpiar dato (resetear a 0)");
    Console.WriteLine("6 = Ver historial de operaciones");
    Console.WriteLine("0 = SALIR");
    Console.WriteLine("------------------------------");
    Console.WriteLine("");
    
    Console.Write("Ingrese: ");
    eleccion = Console.ReadLine();

    switch (eleccion)
    {
        case "1":
            Console.Write("Ingrese el numero a sumar: ");
            operar = Console.ReadLine();
            
            if (double.TryParse(operar, out numero))
            {
                pruebaC.Sumar(numero);
                Console.WriteLine($"Suma realizada! Resultado = {pruebaC.Resultado}");                
            } else
            {
                Console.WriteLine("Por favor, ingrese un numero. Intente nuevamente");
            }
            break;
        
        case "2":

            Console.Write("Ingrese el numero a restar: ");
            operar = Console.ReadLine();
            
            if (double.TryParse(operar, out numero))
            {
                pruebaC.Restar(numero);
                Console.WriteLine($"Resta realizada! Resultado = {pruebaC.Resultado}");                
            } else
            {
                Console.WriteLine("Por favor, ingrese un numero. Intente nuevamente");
            }
            break;
        
        case "3":

            Console.Write("Ingrese el numero a multiplicar: ");
            operar = Console.ReadLine();
            
            if (double.TryParse(operar, out numero))
            {
                pruebaC.Multiplicar(numero);
                Console.WriteLine($"Multiplicacion realizada! Resultado = {pruebaC.Resultado}");                
            } else
            {
                Console.WriteLine("Por favor, ingrese un numero. Intente nuevamente");
            }
            break;
        
        case "4":
            
            Console.Write("Ingrese el numero a dividir: ");
            operar = Console.ReadLine();
            
            if (double.TryParse(operar, out numero))
            {
                pruebaC.Dividir(numero);
                Console.WriteLine($"Division realizada! Resultado = {pruebaC.Resultado}");                
            } else
            {
                Console.WriteLine("Por favor, ingrese un numero. Intente nuevamente");
            }
        
            break;
        
        case "5":
            
            pruebaC.Limpiar();
            Console.WriteLine("Variable reiniciada correctamente");
            break;
        
        case "6":
            Console.WriteLine("--- HISTORIAL DE OPERACIONES ---");
            foreach (Operacion op in pruebaC.Historial)
            {
                Console.WriteLine($"Anterior: {op.ResultadoAnterior} | Valor: {op.NuevoValor} | Operación: {op.OPeracion} | Resultado: {op.Resultado}");
            }
            break;
        
        case "0":
            Console.WriteLine("Saliendo de la calculadora...");
            break;
        
        default:
            // ingresa un valor no admitido
            Console.WriteLine("Error: Opción no válida. Intente nuevamente"); 
            break;
    }

} while (eleccion != "0");