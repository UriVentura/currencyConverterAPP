using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace FixerSharpCore
{
    public class Fixer
    {

        private const string BasePaisesUri = "https://restcountries.eu/rest/v2/all";

        private const string BaseUri = "http://data.fixer.io/api/";

        private static string _apiKey;

        private static string ApiKey
        {
            get => !string.IsNullOrWhiteSpace(_apiKey)
                ? _apiKey
                : throw new InvalidOperationException(
                    "Fixer.io now requires an API key! Call .SetApiKey(\"key\") first");
            set => _apiKey = value;
        }

        public static double Convert(string from, string to, double amount, DateTime? date = null)
        {
            return GetRate(from, to, date).Convert(amount);
        }

        public static async Task<double> ConvertAsync(string from, string to, double amount, DateTime? date = null)
        {
            return (await GetRateAsync(from, to, date)).Convert(amount);
        }

        public static ExchangeRate Rate(string from, string to, DateTime? date = null)
        {
            return GetRate(from, to, date);
        }

        public static async Task<ExchangeRate> RateAsync(string from, string to, DateTime? date = null)
        {
            return await GetRateAsync(from, to, date);
        }

        public static void SetApiKey(string apiKey)
        {
            ApiKey = apiKey;
        }

        public static RootPais[] GetPaises()
        {
            using (var client = new HttpClient()) //variable client de un solo uso
            {
                var response = client.GetAsync(BasePaisesUri).Result;
                response.EnsureSuccessStatusCode();

                string jsonResult = response.Content.ReadAsStringAsync().Result;
                RootPais[] bsObj = JsonConvert.DeserializeObject<RootPais[]>(jsonResult);

                return bsObj;
            }

        }
        public static RootObject GetLatest(DateTime? date = null) //DateTime? date = null
        {

            var url = GetFixerUrl(date);

            using (var client = new HttpClient()) //variable client de un solo uso
            {
                var response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();

                string jsonResult = response.Content.ReadAsStringAsync().Result;
                RootObject bsObj = JsonConvert.DeserializeObject<RootObject>(jsonResult);

                return bsObj;
            }
        }


        public static List<string> GetLatestCodes()
        {
            var latest = GetLatest();
            List<string> monedas = new List<string>();
            PropertyInfo[] properties = latest.rates.GetType().GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                monedas.Add(pi.Name);
            }

            return monedas;
        }


        public static List<FxRate> GetLatestCodesAndValues()
        {
            var latest = GetLatest();
            List<FxRate> monedas = new List<FxRate>();
            PropertyInfo[] properties = latest.rates.GetType().GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                if (pi.Name == "EUR")
                {
                    //Debugger.Break();
                }

                var valor = GetPropValue(latest.rates, pi.Name).ToString();
                double doble;
                Double.TryParse(valor, out doble);
                monedas.Add(new FxRate
                {
                    Base = "EUR",
                    Target = pi.Name,
                    Rate = doble
                });
            }

            return monedas;
        }


        public static List<Factor> GetFactors()
        {
            var listaFxRate = GetLatestCodesAndValues();
            var listaFactores = new List<Factor>();
            foreach (var fxRate in listaFxRate)
            {
                // EURO a Destino
                var factorOrigen = new Factor
                {
                    MonedaOrigen = fxRate.Base,
                    MonedaDestino = fxRate.Target,
                    Rate = fxRate.Rate
                };
                listaFactores.Add(factorOrigen);

                // Destino a EURO
                var factorDestino = new Factor
                {
                    MonedaOrigen = fxRate.Base,
                    MonedaDestino = fxRate.Target,
                    Rate = 1 / fxRate.Rate
                };
                listaFactores.Add(factorDestino);

            }

            return listaFactores;
        }


        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }


        private static ExchangeRate GetRate(string from, string to, DateTime? date = null)
        {
            from = from.ToUpper();
            to = to.ToUpper();

            if (!Symbols.IsValid(from))
                throw new ArgumentException("Symbol not found for provided currency", "from");

            if (!Symbols.IsValid(to))
                throw new ArgumentException("Symbol not found for provided currency", "to");

            var url = GetFixerUrl(date);

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();

                return ParseData(response.Content.ReadAsStringAsync().Result, from, to);
            }
        }


        private static async Task<ExchangeRate> GetRateAsync(string from, string to, DateTime? date = null)
        {
            from = from.ToUpper();
            to = to.ToUpper();

            if (!Symbols.IsValid(from))
                throw new ArgumentException("Symbol not found for provided currency", "from");

            if (!Symbols.IsValid(to))
                throw new ArgumentException("Symbol not found for provided currency", "to");

            var url = GetFixerUrl(date);

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                return ParseData(await response.Content.ReadAsStringAsync(), from, to);
            }
        }

        private static ExchangeRate ParseData(string data, string from, string to)
        {
            // Parse JSON
            var root = JObject.Parse(data);

            var rates = root.Value<JObject>("rates");
            var fromRate = rates.Value<double>(from);
            var toRate = rates.Value<double>(to);

            var rate = toRate / fromRate;

            // Parse returned date
            // Note: This may be different to the requested date as Fixer will return the closest available
            var returnedDate = DateTime.ParseExact(root.Value<string>("date"), "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture);

            return new ExchangeRate(from, to, rate, returnedDate);
        }

        private static string GetFixerUrl(DateTime? date = null)
        {
            var dateString = date.HasValue ? date.Value.ToString("yyyy-MM-dd") : "latest";

            return $"{BaseUri}{dateString}?access_key={ApiKey}";
        }
    }
    public class Factor
    {
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
        public double Rate { get; set; }
    }
}