using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAPI
{
    public class RespuestaAutenticacion
    {
        public string token { get; set; }
        public DateTime expiracion { get; set; }
        public IList<string>? roles { get; set; }
        public string errorResp { get; set; }

    }
}
