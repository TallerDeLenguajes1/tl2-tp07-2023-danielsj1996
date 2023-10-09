using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApi;

public class ManejodeTareas
{
    public static int generdador = 0;
    private AccesoADatos AccesoaDatos;

    public Tarea NuevaTarea(Tarea nuevaTarea)
    {
        AccesoaDatos = new AccesoADatos();
        var tareas = AccesoaDatos.ObtenerListaTarea();
        var id = tareas.Count;
        nuevaTarea.Id = id+generdador++;
        tareas.Add(nuevaTarea);
        AccesoaDatos.GuardarLista(tareas);
        return nuevaTarea;
    }


    public Tarea ObtenerTareaId(int idTarea)
    {
        AccesoaDatos = new AccesoADatos();
        var listadeTareas = AccesoaDatos.ObtenerListaTarea();
        Tarea tarea = listadeTareas.FirstOrDefault(tar => tar.Id == idTarea);
        return tarea;
    }

    public void ActualizarTarea(Tarea actualizarTarea)
    {
        AccesoaDatos = new AccesoADatos();
        List<Tarea> listadeTareas = AccesoaDatos.ObtenerListaTarea();
        int indice = listadeTareas.FindIndex(t => t.Id == actualizarTarea.Id);

        if (indice >= 0)
        {
            listadeTareas[indice] = actualizarTarea;
            AccesoaDatos.GuardarLista(listadeTareas);
        }
    }
    public void EliminarTarea(Tarea tareaAEliminar)
    {
        AccesoaDatos = new AccesoADatos();
        var listadeTareas = AccesoaDatos.ObtenerListaTarea();
        Tarea tarea = listadeTareas.FirstOrDefault(tar => tar.Id == tareaAEliminar.Id);
        if (tarea != null)
        {
            listadeTareas.Remove(tarea);
            AccesoaDatos.GuardarLista(listadeTareas);
        }

    }

    public List<Tarea> ObtenerListaTareas()
    {

        return AccesoaDatos.ObtenerListaTarea();
    }

    public List<Tarea> ObtenerListaTareasCompletadas()
    {
        AccesoaDatos = new AccesoADatos();
        var listadeTareas = AccesoaDatos.ObtenerListaTarea();
        return listadeTareas.Where(tar => tar.Estado == Estado.Completada).ToList();
    }
}

