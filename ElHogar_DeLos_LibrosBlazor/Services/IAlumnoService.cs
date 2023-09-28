namespace ElHogar_DeLos_LibrosBlazor.Services
{
    public interface IAlumnoService
    {
        Task<IEnumerable<Alumno>> GetAll();
    }
}
