using ToDo;

Tarea claseTarea = new Tarea();
List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();

bool success = false;

int opcion = 0;
do
{
    Console.WriteLine("----------M E N U----------");
    Console.WriteLine("1- Cargar NUEVAS tareas pendientes"); //crea nuevas tareas y borra las tareas realizadas anteriores
    Console.WriteLine("2- Mostrar tareas pendientes");
    Console.WriteLine("3- Mostrar tareas realizadas");
    Console.WriteLine("4- Marcar tarea como realizada");
    Console.WriteLine("5-Salir");
    do{
        Console.WriteLine("Ingrese una opcion");
        success = int.TryParse(Console.ReadLine(), out opcion);
    }while(!success);

    switch (opcion)
    {
        case 1:
               Random random = new Random();
                int totalTareas = random.Next(1,20); //entre 1 y 20 exclusive

                for (int i = 0; i < totalTareas; i++)
                {
                    tareasPendientes.Add(claseTarea.nuevaTarea(i));
                }
            break;
        case 2:
            Tarea.MostrarTareas(tareasPendientes); //podria definir los metodos como estaticos y asi no requiero de una instancia de la clase para acceder a este metodo
            break;
        case 3:
            Tarea.MostrarTareas(tareasRealizadas);
            break;
        case 4:
            claseTarea.MoverTarea(tareasPendientes,tareasRealizadas);
            break;
        case 5:
            Console.WriteLine("Saliendo... FIN.");
            break;
        default:
            Console.WriteLine("Opcion no valida...");
            break;
    }
} while (opcion!=5);
