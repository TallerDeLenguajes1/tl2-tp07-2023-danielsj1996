using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApi;


public class AccesoAJson
{


    public List<Tarea> ObtenerListaTarea(string rutaDatosCadete)
    {

        string infoTareas = File.ReadAllText(rutaDatosCadete);
        List<Tarea> listadeTareas = JsonSerializer.Deserialize<List<Tarea>>(infoTareas);
        return listadeTareas;
    }


    public void GuardarLista(List<Tarea> Tarea)
    {
        string rutaDatosTarea = "Tareas.json";
        string infoLista = JsonSerializer.Serialize(Tarea);
        File.WriteAllText(rutaDatosTarea, infoLista);
    }
}