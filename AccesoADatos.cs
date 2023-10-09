using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApi;


public class AccesoADatos
{

   public List<Tarea> ObtenerListaTarea()
    {
        
        var listadeTareas = new List<Tarea>();
        if (File.Exists("ListadeTareas.json"))
        {
        var infoTareas = File.ReadAllText("ListadeTareas.json");
        listadeTareas = JsonSerializer.Deserialize<List<Tarea>>(infoTareas);
        }
            
        return listadeTareas;
    }


    public void GuardarLista(List<Tarea> Tarea)
    {
        string rutaDatosTarea = "ListadeTareas.json";
        string infoLista = JsonSerializer.Serialize(Tarea);
        File.WriteAllText(rutaDatosTarea, infoLista);
    }
}


