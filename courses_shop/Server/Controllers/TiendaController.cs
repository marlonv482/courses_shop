using courses_shop.Server.Repositories;
using courses_shop.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace courses_shop.Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : ControllerBase
    {
        private readonly IRepositorioMasivo masivoRepositorio;

        public TiendaController(IRepositorioMasivo masivoRepositorio) { 
            this.masivoRepositorio= masivoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Curso>>> CargaInicial()
        {
            List<Curso> listaCursos = new List<Curso>();
            try
            {
                listaCursos = (List<Curso>)await masivoRepositorio.DameCursos();

            }catch(Exception ex)
            {
                throw new Exception(ex.ToString()); 
            }
            return listaCursos;
        }
    }
}
