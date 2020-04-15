using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnSum_Click(object sender, RoutedEventArgs e)
        {
            int ris = 0;
            int a = Convert.ToInt32(txtNumber1.Text);
            int b = Convert.ToInt32(txtNumber2.Text);

            HttpClient Client = new HttpClient();
            string uri = $"https://localhost:44330/api/Operations/GetSum?a={a}&b={b}";
            HttpResponseMessage response = await Client.GetAsync(uri);
            string content = await response.Content.ReadAsStringAsync();

            ris = JsonConvert.DeserializeObject<int>(content);
            Dispatcher.Invoke(() => lblRisultato.Content = ris);
        }
    }
}
