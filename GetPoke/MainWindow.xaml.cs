using PokeLib;
using System;
using System.Collections.Generic;
using System.Linq;
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
using static PokeLib.PokeModel;

namespace GetPoke
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow  
    {

        PokeProcessor processor = new PokeProcessor();

        public MainWindow()
        {
            InitializeComponent();
            //Initial our API Help
            ApiHelper.initClient();
        }

        public async void button_Click(object sender, RoutedEventArgs e)
        {
            await LoadPoke();
        }

        public async Task LoadPoke()
        {
            int result;
            string Pokenum = textBox.Text.Trim();
            bool validInput = Int32.TryParse(Pokenum, out result);
                             
            //Check if the input was successfully converted to a number
            if (validInput)
            {
                //Makes the call to the API returning the pokemon with the indicated PokeNumber
                try
                {
                    var Pokemon = await processor.LoadPokemon(Pokenum);
                    GetInfo(Pokemon);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }                      
            }
            else //If the input is a string versus a number search for the string
            {
                try
                {
                    var Poke = await processor.LoadPokemon(Pokenum.ToLower());
                    GetInfo(Poke);
                }
                catch(Exception e)
                {
                   MessageBox.Show(e.Message);
                }
            }            
        }

        
        public void GetInfo(PokeModel Pokemon)
        {
            //String builder object to display attibutes and stats information 
            StringBuilder pokeInfo = new StringBuilder();
            pokeInfo.AppendLine("Name: " + Pokemon.name);
            pokeInfo.AppendLine("Number: " + Pokemon.id);
            pokeInfo.AppendLine("Type(s): ");

            //Grab each pokemon type the pokemon has 
            foreach (Types t in Pokemon.types)
                pokeInfo.AppendLine(t.type.name);

            pokeInfo.AppendLine("Abilities: ");

            //Grab each ability in the abilities list and add it to the output 
            foreach (Abilities a in Pokemon.abilities)
                pokeInfo.AppendLine(a.ability.name);


            //Place the output in the textbox containg all the pokemon information
            AttributesBox.Text = pokeInfo.ToString();

            
            //Places the image in the UI
            var uriSource = new Uri(Pokemon.sprites["front_default"], UriKind.Absolute);
            image1.Source = new BitmapImage(uriSource);
         
        }
    }
}
