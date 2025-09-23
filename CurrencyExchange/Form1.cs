namespace CurrencyExchange
{
    public partial class Form1 : Form
    {
        //deklarujemy w ramach klasy obiekt klasy exchange 
        //do p�niejszego wykorzystania w programie
        Exchange exchange;
        public Form1()
        {
            InitializeComponent();
            //instancja klasy Exchange - wywo�anie konstruktora
            exchange = new Exchange();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //poprzednia metoda konwersji
            //double currency = double.Parse(textBox1.Text);
            //nowa metoda konwersji
            //sprawd� czy mo�na przekonwertowa�, je�li tak to zapisz w currency
            if (!double.TryParse(textBox1.Text, out double currency))
            {
                //nie uda�o si� przekonwertowa�
                textBox1.BackColor = Color.Red;
                return; //wyjd� z metody
            }
            else //uda�o si� przekonwertowa�
                textBox1.BackColor = Color.White;
            
            //zmienna na przeliczon� kwot�
            double result = 0.0;
            
            //sprawd� kt�ry radiobutton jest zaznaczony i wykonaj metod� z parametrem
            if (EurToPlnRadio.Checked)
                result = exchange.ToPLN(currency, Currency.EUR);
            if (UsdToPlnRadio.Checked)
                result = exchange.ToPLN(currency, Currency.USD);
            if (GbpToPlnRadio.Checked)
                result = exchange.ToPLN(currency, Currency.GBP);

            //wy�wietl wynik w textBox2 z dwoma miejscami po przecinku
            textBox2.Text = result.ToString("0.00");
        }
    }
}
