using courses_shop.Shared.Modelos;

namespace courses_shop.Server.Repositories
{
    public interface IRepositorioMasivo
    {
        public Task<IEnumerable<Curso>> PrimerVolcadoDatos();

        public Task<IEnumerable<Curso>> DameCursos();
       
    }
}
