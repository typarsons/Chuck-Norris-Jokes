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

namespace Chuck_Norris_Jokes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string catURL = "https://api.chucknorris.io/jokes/categories";
            {
                using (var client = new HttpClient())
                {
                    string json = client.GetStringAsync(catURL).Result;
                    List<string> categories = JsonConvert.DeserializeObject<List<string>>(json);
                        cboCat.Items.Add("All");
                        cboCat.SelectedIndex = 0;
                    foreach (string category in categories)
                    {
                        
                        cboCat.Items.Add(category);
                        
                    }
                }
            }
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            lblCat.Content = cboCat.SelectedIndex;

            CHUCK api;

            var selectedCat = cboCat.SelectedItem.ToString();
            
            string catSelectedURL = "https://api.chucknorris.io/jokes/random?category=" + selectedCat ;          
            {
                using (var client = new HttpClient())
                {
                    string json = client.GetStringAsync(catSelectedURL).Result;
                    api = JsonConvert.DeserializeObject<CHUCK>(json);
                    
                    lblJoke.Content = api.value;

                }
            }
        }

    }
}
