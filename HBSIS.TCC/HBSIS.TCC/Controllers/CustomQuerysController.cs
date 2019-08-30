using HBSIS.TCC.Enums;
using HBSIS.TCC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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

        //
        [Route("Api/usuarios/CSV")]
        [HttpPost]
        public IQueryable<Usuario> PostCSV(Usuario usuario)
        {
            var list = File.ReadAllLines(@"C:\Users\hbsis\Desktop\usuario.csv")
            .Select(a => a.Split(';'))
            .Select(c => new Usuario()
            {
                IdRegistration = Convert.ToInt32(c[0]),
                Email = c[1],
                PCD = Convert.ToBoolean(c[2]),
                TrabalhoNoturno = Convert.ToBoolean(c[3])
            }).ToList();

            foreach (var item in list)
            {
                db.usuarios.Add(item);
            }

            db.SaveChanges();

            return db.usuarios;
        }

        [Route("Api/Periodo/Tipo/{id}")]
        [HttpGet]
        public IQueryable<Periodo> PeriodoPorTipo(int id)
        {
            return db.periodos.Where(x => x.TipoVeiculo == (TipoVeiculo)id && (DateTime.Compare(x.DataFinal, DateTime.Now)>=0));
        }
    }
}
