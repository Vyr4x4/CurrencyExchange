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
            //przygotuj dwa obiekty typu bindingSource
            BindingSource inputCurrentcyBinding = new BindingSource();
            inputCurrentcyBinding.DataSource = exchange.currencies;
            BindingSource outputCurrentcyBinding = new BindingSource();
            outputCurrentcyBinding.DataSource = exchange.currencies;

            InputCurrencyComboBox.DataSource = inputCurrentcyBinding;
            InputCurrencyComboBox.DisplayMember = "Name"; //co ma by� wy�wietlane
            InputCurrencyComboBox.ValueMember = "Code"; //co ma by� warto�ci�
            OutputCurrencyComboBox.DataSource = outputCurrentcyBinding;
            OutputCurrencyComboBox.DisplayMember = "Name"; //co ma by� wy�wietlane
            OutputCurrencyComboBox.ValueMember = "Code"; //co ma by� warto�ci�
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //poprzednia metoda konwersji
            //double currency = double.Parse(textBox1.Text);
            //nowa metoda konwersji
            //sprawd� czy mo�na przekonwertowa�, je�li tak to zapisz w currency
            if (!double.TryParse(textBox1.Text, out double inputAmmount))
            {
                //nie uda�o si� przekonwertowa�
                textBox1.BackColor = Color.Red;
                return; //wyjd� z metody
            }
            else //uda�o si� przekonwertowa�
                textBox1.BackColor = Color.White;

            //zmienna na przeliczon� kwot�
            double outputAmmount = 0.0;

            //pobieramy symbol pierwszej waluty
            //najpierw pobieramy _obiekt_ waluty z inputCurrencyComboBox - rzutujemy wybrany elelement na obiekt klasy Currency
            Currency inputCurrency = (Currency)InputCurrencyComboBox.SelectedItem;
            //wyci�gamy sobie kod z obiektu
            string inputCurrencyCode = inputCurrency.Code;

            // gdy zamieniamy zot�wki na walut� docelow� to kurs podwyzszony o 2%
            if (inputCurrencyCode == "PLN" && OutputCurrencyComboBox.SelectedItem is Currency outputCurrency1)
            {
                string outputCurrencyCode = outputCurrency1.Code;
                double outputRate = exchange.GetFromCode(outputCurrencyCode).Rate * 1.02; //kurs podwy�szony o 2%
                outputAmmount = inputAmmount / outputRate;
            }
            //gdy zamieniamy inna walute na zlotowki kurs obni�ony o 2%
            else if (OutputCurrencyComboBox.SelectedItem is Currency outputCurrency2 && outputCurrency2.Code == "PLN")
            {
                double inputRate = exchange.GetFromCode(inputCurrencyCode).Rate * 0.98; //kurs obni�ony o 2%
                outputAmmount = inputAmmount * inputRate;
            }

            ////najpierw przeliczamy na z�ot�wki
            ////dzielimy kwot� z pierwszego inputa przez kurs waluty wybranej w pierwszym comboboxie
            //double ammountInPLN = exchange.ToPLN(inputAmmount, exchange.GetFromCode(inputCurrencyCode));

            ////nast�pnie zamieniamy ze z�ot�wek na walut� docelow�
            ////pobieramy symbol waluty docelowej
            //Currency outputCurrency = (Currency)OutputCurrencyComboBox.SelectedItem;
            //string outputCurrencyCode = outputCurrency.Code;
            ////pobieramy kurs waluty docelowej
            //double outputRate = exchange.GetFromCode(outputCurrencyCode).Rate;
            ////mno�ymy
            //outputAmmount = ammountInPLN / outputRate;




            //wy�wietl wynik w textBox2 z dwoma miejscami po przecinku
            textBox2.Text = outputAmmount.ToString("0.00");
        }
    }
}
