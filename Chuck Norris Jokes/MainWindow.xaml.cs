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
            //string catURL = "https://api.chucknorris.io/jokes/random?category={category}";
            string catURL = "https://api.chucknorris.io/jokes/categories";
            {
                using (var client = new HttpClient())
                {
                    string json = client.GetStringAsync(catURL).Result;
                    List<string> categories = JsonConvert.DeserializeObject<List<string>>(json);

                    foreach (string category in categories)
                    {
                        //cboCat.Items.Add("All");
                        //cboCat.SelectedIndex = 0;
                        cboCat.Items.Add(category);
                        //combo box working, now add button
                        //cbo.selindex = url"cat" ?
                    }
                    


                }


            }

        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            lblCat.Content = cboCat.SelectedItem;
            //CHUCK api;
            var selectedCat = cboCat.SelectedIndex;
            string catSelectedURL = "https://api.chucknorris.io/jokes/random";
            //string catSelectedURL = "https://api.chucknorris.io/jokes/random?category={animal}";
            //string catSelectedURL = "https://api.chucknorris.io/jokes/random?category={" + selectedCat + "}"; 
            //string catSelectedURL = "https://api.chucknorris.io/jokes/random?category={category}";
            {
                using (var client = new HttpClient())
                {
                    string json = client.GetStringAsync(catSelectedURL).Result;
                    CHUCK api = JsonConvert.DeserializeObject<CHUCK>(json);
                    //foreach( var obj in api.value)
                    //{
                    //    lblJoke.Content = obj;
                    //}
                    lblJoke.Content = api.value;

                }
               

            }
        }

    }
}
