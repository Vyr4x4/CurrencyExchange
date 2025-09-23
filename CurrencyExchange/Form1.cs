namespace CurrencyExchange
{
    public partial class Form1 : Form
    {
        //deklarujemy w ramach klasy obiekt klasy exchange 
        //do póŸniejszego wykorzystania w programie
        Exchange exchange;
        public Form1()
        {
            InitializeComponent();
            //instancja klasy Exchange - wywo³anie konstruktora
            exchange = new Exchange();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //poprzednia metoda konwersji
            //double currency = double.Parse(textBox1.Text);
            //nowa metoda konwersji
            //sprawdŸ czy mo¿na przekonwertowaæ, jeœli tak to zapisz w currency
            if (!double.TryParse(textBox1.Text, out double currency))
            {
                //nie uda³o siê przekonwertowaæ
                textBox1.BackColor = Color.Red;
                return; //wyjdŸ z metody
            }
            else //uda³o siê przekonwertowaæ
                textBox1.BackColor = Color.White;
            
            //zmienna na przeliczon¹ kwotê
            double result = 0.0;
            
            //sprawdŸ który radiobutton jest zaznaczony i wykonaj metodê z parametrem
            if (EurToPlnRadio.Checked)
                result = exchange.ToPLN(currency, Currency.EUR);
            if (UsdToPlnRadio.Checked)
                result = exchange.ToPLN(currency, Currency.USD);
            if (GbpToPlnRadio.Checked)
                result = exchange.ToPLN(currency, Currency.GBP);

            //wyœwietl wynik w textBox2 z dwoma miejscami po przecinku
            textBox2.Text = result.ToString("0.00");
        }
    }
}
