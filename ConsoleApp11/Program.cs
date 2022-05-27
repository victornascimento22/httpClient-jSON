using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;


namespace ConsoleApp11
{
    class Program
    {

        static async Task Main(string[] args)
        {
            string url = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/33/distritos";
            //http client para enviar um request
            HttpClient httpClient = new HttpClient();

            try
            {          
                var httpResponseMessage = await httpClient.GetAsync(url);
                string JsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(JsonResponse);

                Console.WriteLine(myDeserializedClass);
;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        

            // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
            public class Mesorregiao
            {
                [JsonProperty("id")]
                public int Id;

                [JsonProperty("nome")]
                public string Nome;

                [JsonProperty("UF")]
                public UF UF;
            }

            public class Microrregiao
            {
                [JsonProperty("id")]
                public int Id;

                [JsonProperty("nome")]
                public string Nome;

                [JsonProperty("mesorregiao")]
                public Mesorregiao Mesorregiao;
            }

            public class Municipio
            {
                [JsonProperty("id")]
                public string Id;

                [JsonProperty("nome")]
                public string Nome;

                [JsonProperty("microrregiao")]
                public Microrregiao Microrregiao;

                [JsonProperty("regiao-imediata")]
                public RegiaoImediata RegiaoImediata;
            }

            public class Regiao
            {
                [JsonProperty("id")]
                public int Id;

                [JsonProperty("sigla")]
                public string Sigla;

                [JsonProperty("nome")]
                public string Nome;
            }

            public class RegiaoImediata
            {
                [JsonProperty("id")]
                public int Id;

                [JsonProperty("nome")]
                public string Nome;

                [JsonProperty("regiao-intermediaria")]
                public RegiaoIntermediaria RegiaoIntermediaria;
            }

            public class RegiaoIntermediaria
            {
                [JsonProperty("id")]
                public int Id;

                [JsonProperty("nome")]
                public string Nome;

                [JsonProperty("UF")]
                public UF UF;
            }

            public class Root
            {
                [JsonProperty("id")]
                public string Id;

                [JsonProperty("nome")]
                public string Nome;

                [JsonProperty("municipio")]
                public Municipio Municipio;
            }

            public class UF
            {
                [JsonProperty("id")]
                public int Id;

                [JsonProperty("sigla")]
                public string Sigla;

                [JsonProperty("nome")]
                public string Nome;

                [JsonProperty("regiao")]
                public Regiao Regiao;
            }






        

    }
}
