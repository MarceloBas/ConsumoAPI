using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAPI
{
    public class RespuestaAutenticacion
    {
        public string accessToken { get; set; }
        public DateTime AccessExpiracion { get; set; }
        public IList<Menu>? Menu { get; set; }
        public string errorResp { get; set; }

    }
    public class Menu
    {
        public int Id { get; set; }

        public string? titulo { get; set; }

        public string Descripcion { get; set; }

        public string Recurso { get; set; }
        public string [] submenu { get; set; }

    }

}

