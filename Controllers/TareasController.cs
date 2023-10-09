using Microsoft.AspNetCore.Mvc;
using WebApi;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TareasController : ControllerBase
{

    private ManejodeTareas manejodeTareas;
    private readonly ILogger<TareasController> _logger;
  
    public TareasController(ILogger<TareasController> logger)
    {
        _logger = logger;
        AccesoADatos acceso=new AccesoADatos();
        manejodeTareas = new ManejodeTareas();


    }

    [HttpPost("Nueva Tarea")]
    public ActionResult<Tarea> AgregarTarea(Tarea tarea)
    {
        var t=manejodeTareas.NuevaTarea(tarea);
        if (t == null)
        {
            return BadRequest("No se pudo tomar el pedido");
        }
        else
        {
            return Ok("Tarea Agregado Exitosamente");
        }

    }

    [HttpGet("Buscar Tarea por ID")]
    public ActionResult<Tarea> ObtenerTareaID(int id)
    {
        var tarea = manejodeTareas.ObtenerTareaId(id);
        if (tarea != null)
        {
            return Ok(tarea);
        }
        else
        {
            return BadRequest("No se encontró la tarea Buscada");
        }
    }

    [HttpPut("Actualizar Tarea")]
    public ActionResult<Tarea> ActualizarTarea(Tarea TareaActulizada)
    {
        var tarea = manejodeTareas.ObtenerTareaId(TareaActulizada.Id);
        if (tarea != null)
        {
            manejodeTareas.ActualizarTarea(TareaActulizada);
            return Ok();
        }
        else
        {
            return BadRequest("No se encontró la tarea Buscada");
        }
    }
    [HttpDelete("Eliminar Tarea")]
    public ActionResult<Tarea> EliminarTarea(Tarea tareaAEliminar)
    {
        var tarea = manejodeTareas.ObtenerTareaId(tareaAEliminar.Id);
        if (tarea != null)
        {
            manejodeTareas.EliminarTarea(tareaAEliminar);
            return Ok(tarea);
        }
        else
        {
            return BadRequest("No se encontró la tarea Buscada");
        }
    }
    [HttpGet("Mostrar todas las Tareas")]
    public ActionResult<Tarea> MostrarTareas()
    {
        var tarea = manejodeTareas.ObtenerListaTareas();
        if (tarea != null)
        {

            return Ok(tarea);
        }
        else
        {
            return BadRequest("No hay ninguna tarea Cargada");
        }
    }
    [HttpGet("Mostrar todas las Tareas Terminadas")]
    public ActionResult<Tarea> MostrarTareasTerminadas()
    {
        var tareaCompletadas = manejodeTareas.ObtenerListaTareasCompletadas();
        if (tareaCompletadas != null)
        {

            return Ok(tareaCompletadas);
        }
        else
        {
            return BadRequest("No hay ninguna tarea Cargada");
        }
    }
}

