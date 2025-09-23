using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange
{
    enum Currency
    {
        PLN,
        EUR,
        USD,
        GBP,
        CHF
    }
    internal class Exchange
    {
        //konstuktory - domyślny
        public Exchange() 
        {
            GetFromAPI();
        }

        Dictionary<Currency, double> rates = new Dictionary<Currency, double>()
        {
            { Currency.PLN, 1.00 },
            { Currency.EUR, 4.19 },
            { Currency.USD, 3.62 },
            { Currency.GBP, 4.92 },
                        { Currency.CHF, 4.02 }
        };
        /// <summary>
        /// Metoda pobiera kwotę w PLN i przelicza na inną walutę
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="from"></param>
        /// <returns>Kwota w PLN</returns>
        public double ToPLN(double amount, Currency from)
        {
            //mnożymy otrzymaną ilość razy kurs waluty pobrany ze słownika
            return amount * rates[from];
        }
        public void GetFromAPI()
        {
            string json;
            using (HttpClient client = new HttpClient())
            {
                json = client.GetStringAsync("https://api.nbp.pl/api/exchangerates/tables/A/").Result;
            }

            var responses = JsonConvert.DeserializeObject<APIResponse[]>(json);
            if (responses == null || responses.Length == 0)
                throw new InvalidOperationException("Nie udało się pobrać kursów walut z API.");

            APIResponse response = responses[0];

            // przechodzimy po wszystkich walutach z enum
            foreach (Currency c in Enum.GetValues(typeof(Currency)))
            {
                if (c == Currency.PLN) continue; // PLN ma zawsze kurs 1.00

                // szukamy kursu w odpowiedzi API
                var rate = response.rates?.FirstOrDefault(r => r.code == c.ToString());
                if (rate != null)
                {
                    rates[c] = rate.mid; // aktualizujemy słownik
                }
            }
        }

    }
}
