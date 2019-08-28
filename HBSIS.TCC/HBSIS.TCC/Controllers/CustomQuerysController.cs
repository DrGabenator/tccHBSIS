using HBSIS.TCC.Enums;
using HBSIS.TCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HBSIS.TCC.Controllers
{
    public class CustomQuerysController : ApiController
    {
        private ContextDB db = new ContextDB();

        [Route("Api/TipoVeiculos")]
        [HttpGet]
        public List<KeyValuePair<string, int>> GettipoVeiculo()
        {
            var list = new List<KeyValuePair<string, int>>();

            foreach (var item in Enum.GetValues(typeof(TipoVeiculo)))
            {

                list.Add(new KeyValuePair<string, int>(item.ToString(), (int)item));
            }

            return list;
        }

        [Route("Api/Marcas/Veiculos/{id}")]
        [HttpGet]
        public IQueryable<Marca> MarcaByVeiculo(int id)
        {
            return db.marcas.Where(x => x.TipoVeiculo == (TipoVeiculo)id);
        }

        [Route("Api/Modelos/Marcas/{id}")]
        [HttpGet]
        public IQueryable<Modelo> ModeloByMarca(int id)
        {
            return db.modelos.Where(x => x.Marca.Codigo == id);
        }

    }
}
