using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange
{
    internal class Currency
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Rate { get; set; }
        /// <summary>
        /// Konstruktor klasy Currency - tworzy obiekt waluty
        /// </summary>
        /// <param name="name">Nazwa, np. dolar amerykański</param>
        /// <param name="code">Kod, np. USD</param>
        /// <param name="rate">Kurs względem złotego, np. 4.33 (4,33 złotego za dolara)</param>
        public Currency(string name, string code, double rate)
        {
            this.Name = name;
            this.Code = code;
            this.Rate = rate;
        }
    }
}
