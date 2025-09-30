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
            //przygotuj dwa obiekty typu bindingSource
            BindingSource inputCurrentcyBinding = new BindingSource();
            inputCurrentcyBinding.DataSource = exchange.currencies;
            BindingSource outputCurrentcyBinding = new BindingSource();
            outputCurrentcyBinding.DataSource = exchange.currencies;

            InputCurrencyComboBox.DataSource = inputCurrentcyBinding;
            InputCurrencyComboBox.DisplayMember = "Name"; //co ma byæ wyœwietlane
            InputCurrencyComboBox.ValueMember = "Code"; //co ma byæ wartoœci¹
            OutputCurrencyComboBox.DataSource = outputCurrentcyBinding;
            OutputCurrencyComboBox.DisplayMember = "Name"; //co ma byæ wyœwietlane
            OutputCurrencyComboBox.ValueMember = "Code"; //co ma byæ wartoœci¹
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //poprzednia metoda konwersji
            //double currency = double.Parse(textBox1.Text);
            //nowa metoda konwersji
            //sprawdŸ czy mo¿na przekonwertowaæ, jeœli tak to zapisz w currency
            if (!double.TryParse(textBox1.Text, out double inputAmmount))
            {
                //nie uda³o siê przekonwertowaæ
                textBox1.BackColor = Color.Red;
                return; //wyjdŸ z metody
            }
            else //uda³o siê przekonwertowaæ
                textBox1.BackColor = Color.White;

            //zmienna na przeliczon¹ kwotê
            double outputAmmount = 0.0;

            //pobieramy symbol pierwszej waluty
            //najpierw pobieramy _obiekt_ waluty z inputCurrencyComboBox - rzutujemy wybrany elelement na obiekt klasy Currency
            Currency inputCurrency = (Currency)InputCurrencyComboBox.SelectedItem;
            //wyci¹gamy sobie kod z obiektu
            string inputCurrencyCode = inputCurrency.Code;

            // gdy zamieniamy zotówki na walutê docelow¹ to kurs podwyzszony o 2%
            if (inputCurrencyCode == "PLN" && OutputCurrencyComboBox.SelectedItem is Currency outputCurrency1)
            {
                string outputCurrencyCode = outputCurrency1.Code;
                double outputRate = exchange.GetFromCode(outputCurrencyCode).Rate * 1.02; //kurs podwy¿szony o 2%
                outputAmmount = inputAmmount / outputRate;
            }
            //gdy zamieniamy inna walute na zlotowki kurs obni¿ony o 2%
            else if (OutputCurrencyComboBox.SelectedItem is Currency outputCurrency2 && outputCurrency2.Code == "PLN")
            {
                double inputRate = exchange.GetFromCode(inputCurrencyCode).Rate * 0.98; //kurs obni¿ony o 2%
                outputAmmount = inputAmmount * inputRate;
            }

            ////najpierw przeliczamy na z³otówki
            ////dzielimy kwotê z pierwszego inputa przez kurs waluty wybranej w pierwszym comboboxie
            //double ammountInPLN = exchange.ToPLN(inputAmmount, exchange.GetFromCode(inputCurrencyCode));

            ////nastêpnie zamieniamy ze z³otówek na walutê docelow¹
            ////pobieramy symbol waluty docelowej
            //Currency outputCurrency = (Currency)OutputCurrencyComboBox.SelectedItem;
            //string outputCurrencyCode = outputCurrency.Code;
            ////pobieramy kurs waluty docelowej
            //double outputRate = exchange.GetFromCode(outputCurrencyCode).Rate;
            ////mno¿ymy
            //outputAmmount = ammountInPLN / outputRate;




            //wyœwietl wynik w textBox2 z dwoma miejscami po przecinku
            textBox2.Text = outputAmmount.ToString("0.00");
        }
    }
}
