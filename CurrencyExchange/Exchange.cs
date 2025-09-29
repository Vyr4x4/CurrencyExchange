using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange
{
    //zamiast tego mamy teraz klasę w pliku Currency.cs
    //enum Currency
    //{
    //    PLN,
    //    EUR,
    //    USD,
    //    GBP
    //}
    internal class Exchange
    {
        //konstuktory - domyślny
        public Exchange() 
        {
            GetFromAPI();
        }
        //zamiast słownika zrobimy listę obiektów klasy Currency
        //Dictionary<Currency, double> rates = new Dictionary<Currency, double>()
        //{
        //    { Currency.PLN, 1.00 },
        //    { Currency.EUR, 4.19 },
        //    { Currency.USD, 3.62 },
        //    { Currency.GBP, 4.92 }
        //};
         public List<Currency> currencies = new List<Currency>()
        {
            new Currency("polski złoty", "PLN", 1.00),
            new Currency("euro", "EUR", 4.19),
            new Currency("dolar amerykański", "USD", 3.62),
            new Currency("funt brytyjski", "GBP", 4.92)
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
            return amount * from.Rate;
        }
        /// <summary>
        /// Metoda zwraca obiekt waluty na podstawie podanego kodu
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Obiekt klasy Currency z kodem pasującym do podanego argumentu</returns>
        /// <exception cref="Exception"></exception>
        public Currency? GetFromCode(string code)
        {
            //znajdź w liście currencies obiekt, którego code jest taki sam jak podany w argumencie
            Currency? currency = currencies.Find(c => c.Code == code);
            if (currency == null) throw new Exception("Nie znaleziono waluty o podanym kodzie");
            return currency;
        }
        public void GetFromAPI()
        {
            //zmienna do przechowywania surowej odpowiedzi z API
            string json;
            //blok using do automatycznego zwalniania zasobów - niszczy HttpClient jak nie jest już potrzebny
            using (HttpClient client = new HttpClient())
            {
                //wysyłamy zapytanie i czekamy na odpowiedź - zapisujemy ją do zmiennej json
                json = client.GetStringAsync("https://api.nbp.pl/api/exchangerates/tables/A/").Result;      
            }
            //stworz obiekt klasy APIResponse i zdeserializuj do niego odpowiedź z API
            //musimy użyć [0], ponieważ odpowiedź z API to tablica obiektów
            //mówimy jsonconvertowi, że chcemy zdeserializować _tablicę_ obiektów APIResponse
            APIResponse response = JsonConvert.DeserializeObject<APIResponse[]>(json)[0];

            //iterujemy po wszystkich kursach w odpowiedzi z API
            foreach (Rate rate in response.rates)
            {
                //sprawdzamy czy mamy już w swoim zbiorze walut taką walutę
                //znajdź w liście currencies obiekt, którego code jest taki sam jak rate.code z API
                //czytamy to jako: znajdź takie c (pozycja na liscie currecies),
                //że c.code (kod w naszym obiekcie) jest równe rate.code (code z API)
                Currency? currency = currencies.Find(c => c.Code == rate.code);
                //jeśli taki obiekt istnieje to zaktualizuj jego kurs
                if (currency != null)
                {
                    //jeśli znalazło walutę w naszej liście to aktualizujemy jej kurs
                    currency.Rate = rate.mid;
                }
                else
                {
                    //jeśli nie znalazło to dodajemy nową walutę do listy
                    currencies.Add(new Currency(rate.currency, rate.code, rate.mid));
                }
            }
            //po zakończeniu pętli w liście currencies mamy aktualne kursy wszystkich walut z API
        }
    }
}
