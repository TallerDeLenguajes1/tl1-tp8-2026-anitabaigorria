// PUNTO 1
namespace espacioTarea
{
    public class Tarea { 
        public int TareaID { get; set; } 
        public string Descripcion { get; set; } 
        public int Duracion { get; set ; } // Validar que esté entre 10 y 100 

        public bool ValidarDuracion(int duracion)
        {
            if (duracion >= 10 && duracion <= 100)
            {
                return true;
            } 
            return false;           
        }
        public void MostrarDatos()
        {
            Console.WriteLine($"[Tarea {TareaID}] - {Descripcion} ({Duracion} días)");
        }
        
        public Tarea()
        {
            this.TareaID = 0;
            this.Descripcion = "";
            this.Duracion = 0;
        }
        
        public Tarea(int id, string descripcion,int dur)
        {
            this.TareaID = id;
            this.Descripcion = descripcion;
            if (ValidarDuracion(dur) == true)
            {
                this.Duracion = dur;            
            } else
            {
                this.Duracion = -99;
            }
        }
}
}