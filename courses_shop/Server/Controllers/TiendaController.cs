using Microsoft.AspNetCore.Mvc;
using courses_shop.Server.Repositories;
using courses_shop.Shared.Modelos;

namespace courses_shop.Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : ControllerBase
    {
        private readonly IRepositorioMasivo masivoRepositorio;
        private readonly IRepositorioGeneral generalRepositorio;
        public TiendaController( IRepositorioMasivo masivoRepositorio,IRepositorioGeneral  generalRepositorio )
        {
            this.masivoRepositorio = masivoRepositorio;
            this.generalRepositorio = generalRepositorio;
        }
       
        [HttpGet]
        [Route("DameCursos")]
        public async Task<ActionResult<List<Curso>>> CargaInicial()
        {
            List<Curso> listaCursos = new List<Curso>();
            try
            {
                listaCursos = (List<Curso>)await masivoRepositorio.DameCursos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return listaCursos;
        }

       
        [HttpPost]
        [Route("GuardarCursos")]
        public async Task<ActionResult<Usuario>> GuardarCursos(Usuario _usuario)
        {
            Usuario usuario = null;
            try
            {
                if (_usuario.ListaCursos == null)
                {
                    return BadRequest();

                }
                usuario = await generalRepositorio.GuardarCursos(_usuario);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            return usuario;

        }
       
        [HttpPost]
        [Route("AltaUsuario")]
        public async Task<ActionResult<Usuario>> AltaUsuario(Usuario _user)
        {
           
           
            Usuario usuario = null;
            try
            {
                if (_user == null)
                {
                    return BadRequest();

                }
               
                usuario = await generalRepositorio.AltaUsuario(_user);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            return usuario;

        }
    }
}
