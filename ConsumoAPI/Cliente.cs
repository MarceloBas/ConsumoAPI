using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsumoAPI.Cliente;

namespace ConsumoAPI
{
    internal class Cliente
    {

            private string _baseUrl = "http://oliauto.dyndns.org:2088";

            private string _bearerTokenJWT = string.Empty;

            private HttpClient _httpClient;

            public Cliente(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            public string BaseUrl
            {
                get { return _baseUrl; }
                set { _baseUrl = value; }
            }

            public string BearerTokenJWT
            {
                get { return _bearerTokenJWT; }
                set { _bearerTokenJWT = value; }
            }


        }
    }
