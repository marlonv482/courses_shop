using courses_shop.Shared.Modelos;

namespace courses_shop.Server.Repositories
{
    public interface IRepositorioGeneral
    {
        public Task<Usuario> GuardarCursos(Usuario _usuario);

         public Task<Usuario> AltaUsuario(Usuario _usuario);
    }
}
