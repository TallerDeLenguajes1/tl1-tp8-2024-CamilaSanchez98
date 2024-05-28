using EnumTarea;

namespace ToDo
{
    public class Tarea{

        //CAMPOS O DATOS
        private int idTarea;
        private string descripcion;
        private int duracion;

        //CONSTRUCTORES
        public Tarea(){}
        public Tarea(int idTarea, string descripcion, int duracion){
            this.idTarea=idTarea;
            this.descripcion=descripcion;
            this.duracion=duracion;
        }
        //GETTERS Y SETTERS
        public int IdTarea{
            get=> idTarea;
            set=> idTarea = value;
        }
        public int Duracion{
            get=> duracion;
            set=> duracion = value;
        }
        public string Descripcion{
            get=> descripcion;
            set=> descripcion = value;
        }
        
        //METODOS DE LA CLASE
        public Tarea nuevaTarea(int i){
            Random random = new Random();
            int idAleatorio = i;

            int descripcionInt = random.Next(6); //aleatorio entre 0 y 5 inclusive, 6 exclusive
            string tipoDescripcion = Enum.GetName(typeof(DescripcionTarea), descripcionInt);
            string[] arregloDescripcion = tipoDescripcion.Split('_');
            string descripcionAleatoria="";
            for (int j = 0; j < arregloDescripcion.Length; j++)
            {
                descripcionAleatoria = string.Concat(descripcionAleatoria,' ');
                descripcionAleatoria = string.Concat(descripcion,arregloDescripcion[j]);
            }

            int duracionIngresada = random.Next(10,101); //entre10 y 100

            Tarea nuevaTarea = new Tarea(idAleatorio,descripcionAleatoria,duracionIngresada);
            return nuevaTarea;
        }
        public static void MostrarTareas(List<Tarea> lista){
            Console.WriteLine("---------- MOSTRAR LISTA ----------");
            if(lista.Count() >0){
                foreach (Tarea tarea in lista)
                {
                    Console.WriteLine("---");
                    Console.WriteLine($"TAREA DE ID: {tarea.idTarea}");
                    Console.WriteLine($"DURACION: {tarea.duracion}");
                    Console.WriteLine($"DESCRIPCION: {tarea.descripcion}");
                    Console.WriteLine("---");
                }
            }else{
                Console.WriteLine("La lista es vacía.");
            }
        }
        private Tarea BuscarTarea(int idBuscado, List<Tarea> lista){
            foreach (Tarea tarea in lista)
            {
                if(tarea.idTarea == idBuscado){
                    return tarea;
                }
            }
            return null;
        }
        public void MoverTarea(List<Tarea> listaPendientes, List<Tarea> listaRealizadas){
            Console.WriteLine("---------- MOVER TAREA DE LA LISTA ----------");
            bool success = false;
            int idBuscado;
            Tarea tareaEncontrada = null;

            if(listaPendientes.Count()>0){
                do
                {   
                    Console.WriteLine("Ingrese un ID a buscar:");
                    success = int.TryParse(Console.ReadLine(),out idBuscado);
                } while (!success);

                tareaEncontrada = BuscarTarea(idBuscado,listaPendientes);
                if(tareaEncontrada!=null){
                    listaPendientes.Remove(tareaEncontrada);
                    listaRealizadas.Add(tareaEncontrada);
                    Console.WriteLine("¡Tarea movida!");
                }else{
                    Console.WriteLine("La tarea no fue encontrada. Tarea no removida.");
                }
            }else{
                Console.WriteLine("La lista es vacía.");
            }
        }
    }
}