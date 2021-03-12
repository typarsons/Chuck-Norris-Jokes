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
            //
            //
            //CHUCK chuck;
            //string catSelectedURL = "https://api.chucknorris.io/jokes/random?category={category}";
            string catURL = "https://api.chucknorris.io/jokes/categories";
            { using (var client = new HttpClient())
                {
                    string json = client.GetStringAsync(catURL).Result;
                    List<string> categories = JsonConvert.DeserializeObject<List<string>>(json);

                    foreach (string category in categories)
                    {
                        cboCat.Items.Add(category);
                    }
                          


                }


            }

        }
    }
}
