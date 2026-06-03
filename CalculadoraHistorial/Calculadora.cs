public enum TipoOperacion{ 
       Suma, 
       Resta, 
       Multiplicacion, 
       Division, 
       Limpiar  // Representa la acción de borrar el resultado actual o el historial 
   }

namespace espacioCalculadora
{
    public class Calculadora
    {
        double dato;

        public void Sumar(double valor)
        {
            double valorPrevio = dato;
            dato += valor;
            Operacion nuevaOp = new Operacion(valorPrevio,valor,TipoOperacion.Suma);
            historial.Add(nuevaOp);
        }

        public void Restar(double valor)
        {
            double valorPrevio = dato;
            dato -= valor;
            Operacion nuevaOp = new Operacion(valorPrevio,valor,TipoOperacion.Resta);
            historial.Add(nuevaOp);
        }

        public void Multiplicar(double valor)
        {
            double valorPrevio = dato;
            dato *= valor;
            Operacion nuevaOp = new Operacion(valorPrevio,valor,TipoOperacion.Multiplicacion);
            historial.Add(nuevaOp);
        }

        public void Dividir(double valor)
        {
            double valorPrevio = dato;
            dato /= valor;
            Operacion nuevaOp = new Operacion(valorPrevio,valor,TipoOperacion.Division);
            historial.Add(nuevaOp);
        }

        public void Limpiar()
        {
            double valorPrevio = dato;
            dato = 0;
            Operacion nuevaOp = new Operacion(valorPrevio,dato,TipoOperacion.Limpiar);
            historial.Add(nuevaOp);
        }

        private List<Operacion> historial = new List<Operacion>();
        
        //creo una copia publica exclusiva para que se pueda acceder a la lista privada desde el program sin visualizar su implementacion 
        public List<Operacion> Historial 
        {
            get => historial; 
        }

        // variable publica con primera en mayuscula (privadas todo minuscula) generalmente tienen el mismo nombre y se diferencian en eso 
        public double Resultado
        {
            get => dato;
        }

    }
    
    // incorporar clase OPERACION
    public class Operacion{ 
        private double resultadoAnterior; // Almacena el resultado previo al cálculo actual 
        private double nuevoValor; //El valor con el que se opera sobre el resultadoAnterior 
        private TipoOperacion operacion;// El tipo de operación realizada 
        public double Resultado
        {
            get {
                switch (operacion) 
                {
                    case TipoOperacion.Suma:
                        return resultadoAnterior + nuevoValor;
                        
                    case TipoOperacion.Resta:
                        return resultadoAnterior - nuevoValor;

                    case TipoOperacion.Multiplicacion:
                        return resultadoAnterior * nuevoValor;

                    case TipoOperacion.Division:
                        return resultadoAnterior / nuevoValor;
                    case TipoOperacion.Limpiar:
                        return 0;
                        
                    default:
                        return 0;
                }
            }
        } 

        // Propiedad pública para acceder al nuevo valor utilizado en la operación 
        public double NuevoValor{ 
            get => nuevoValor;
        } 

        public double ResultadoAnterior{ 
            get => resultadoAnterior;
        } 

        public TipoOperacion OPeracion
        {
            get => operacion;  
        }

        public Operacion(double anterior, double nuevo, TipoOperacion tipoOp)
        {
            resultadoAnterior = anterior;
            nuevoValor = nuevo;
            operacion = tipoOp;
        }
        
    } 
}