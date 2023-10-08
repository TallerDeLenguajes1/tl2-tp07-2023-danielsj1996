using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApi;

public class ManejodeTareas
{
    private AccesoAJson AccesoaDatos;
    public static int generdador = 0;

    public void NuevaTarea(Tarea tarea)
    {
        var nuevaTarea = new Tarea();
        nuevaTarea.Id = generdador++;
        List<Tarea> tareas = AccesoaDatos.ObtenerListaTarea("ListadeTareas.json");
        tareas.Add(nuevaTarea);
        AccesoaDatos.GuardarLista(tareas);
    }


    public Tarea ObtenerTareaId(int idTarea)
    {
        var listadeTareas = AccesoaDatos.ObtenerListaTarea("ListadeTareas.json");
        Tarea tarea = listadeTareas.FirstOrDefault(tar => tar.Id == idTarea);
        return tarea;
    }

    public void ActualizarTarea(Tarea actualizarTarea)
    {
        List<Tarea> listadeTareas = AccesoaDatos.ObtenerListaTarea("ListadeTareas.json");
        int indice = listadeTareas.FindIndex(t => t.Id == actualizarTarea.Id);

        if (indice >= 0)
        {
            listadeTareas[indice] = actualizarTarea;
            AccesoaDatos.GuardarLista(listadeTareas);
        }
    }
    public void EliminarTarea(Tarea tareaAEliminar)
    {
        var listadeTareas = AccesoaDatos.ObtenerListaTarea("ListadeTareas.json");
        Tarea tarea = listadeTareas.FirstOrDefault(tar => tar.Id == tareaAEliminar.Id);
        if (tarea != null)
        {
            listadeTareas.Remove(tarea);
            AccesoaDatos.GuardarLista(listadeTareas);
        }

    }

    public List<Tarea> ObtenerListaTareas()
    {

        return AccesoaDatos.ObtenerListaTarea("ListadeTareas.json");
    }

    public List<Tarea> ObtenerListaTareasCompletadas()
    {
        var listadeTareas = AccesoaDatos.ObtenerListaTarea("ListadeTareas.json");
        return listadeTareas.Where(tar => tar.Estado == Estado.Completada).ToList();
    }
}

