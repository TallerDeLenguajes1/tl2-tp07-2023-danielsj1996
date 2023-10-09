namespace WebApi;
public enum Estado
{
     Pendiente,
    En_Progreso,
    Completada

}
public class Tarea
{
    private int id;
    private string? titulo;
    private string? descripcion;
    private Estado estado;

    public int Id { get => id; set => id = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public Estado Estado { get => estado; set => estado = value; }
}
