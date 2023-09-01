// See https://aka.ms/new-console-template for more information
using ConsumoAPI;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Ejemplo WebAPI");
Console.WriteLine("Introduzca un catalogo");
string catalogo;
catalogo = Console.ReadLine();

Console.WriteLine("Stock: " + await GetstockxCatalogo(await GetToken(), catalogo));// "G  -052-545-K9"));
Console.ReadKey();


    static async Task<string> GetToken()
{
    
    var url = $"http://oliauto.dyndns.info:2088/api/Acceso/Acceso";
    CredencialesUsuarioDTO credenciales = new CredencialesUsuarioDTO() { email = "UserTest@Test.com.ar", password = "Aa1234!" };
    try
    {
        using (var client_ = new HttpClient())
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Content = new StringContent(JsonSerializer.Serialize(credenciales));
                request_.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                request_.Method = new HttpMethod("POST");
                request_.RequestUri = new Uri(url);
                request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                var responseText_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (response_.StatusCode == System.Net.HttpStatusCode.OK) // 200
                {

                    var responseBody_ = JsonSerializer.Deserialize<RespuestaAutenticacion>(responseText_);

                    return responseBody_.token.ToString();
                }
                else
                {
                    return response_.RequestMessage.ToString();
                }
            }
        }
    }
    catch (WebException ex)
    {
        return "ERROR : " + ex.Message;
    }
    #region "metodo obsoleto para net 6
    //Ejemplo con WebRequest(a partir de net 6 esta marcada como obsoleto)
    //var request = (HttpWebRequest)WebRequest.Create(url);
    //string json = $"{{\"email\":\"UserTest@Test.com.ar\",\"password\":\"Aa1234!\"}}";
    //request.Method = "POST";
    //request.ContentType = "application/json";
    //request.Accept = "application/json";

    //using (var streamWriter = new StreamWriter(request.GetRequestStream()))
    //{
    //    streamWriter.Write(json);
    //    streamWriter.Flush();
    //    streamWriter.Close();
    //}

    //try
    //{
    //    using (WebResponse response = request.GetResponse())
    //    {
    //        using (Stream strReader = response.GetResponseStream())
    //        {
    //            if (strReader == null) return "";
    //            using (StreamReader objReader = new StreamReader(strReader))
    //            {
    //                string responseBody = objReader.ReadToEnd();

    //                RespuestaAutenticacion? respuesta = JsonSerializer.Deserialize<RespuestaAutenticacion>(responseBody);

    //                //Console.WriteLine("Token = " + respuesta.token);
    //                //Console.WriteLine("Expiracion = " + respuesta.expiracion);
    //                //Console.WriteLine("");

    //                return respuesta.token;
    //            }
    //        }
    //    }
    //}
    //catch (WebException ex)
    //{
    //    return "ERROR : " + ex.Message;
    //}
    #endregion
}

static async Task<string>  GetstockxCatalogo(string token, string catalogo)
{
    var url = $"http://oliauto.dyndns.info:2088/api/Encuesta/StockxCatalogo";

    DateTime localDate = DateTime.Now;
    string dia = localDate.ToString();
    ParametroEncuesta param = new ParametroEncuesta() { Catalogo = catalogo, Fecha= localDate };

     try
    {

        using (var client_ = new HttpClient())
        {
            using (var request_ = new HttpRequestMessage())
            {

                request_.Content = new StringContent(JsonSerializer.Serialize(param));
                request_.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                request_.Method = new HttpMethod("POST");
                request_.RequestUri = new Uri(url);
                request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                client_.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer", token);
                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                var responseText_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (response_.StatusCode == System.Net.HttpStatusCode.OK) // 200
                {

                    var responseBody_ = JsonSerializer.Deserialize<RespStockRepuesto>(responseText_);

                    return responseBody_.stock.ToString();
                }

                return "Error " + response_.StatusCode.ToString();

            }
        }

   
       
    }
    catch (WebException ex)
    {
        return "ERROR : " + ex.Message;

    }
}