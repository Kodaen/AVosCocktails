using CocktailDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace AVosCocktails.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class CocktailListPage : ContentPage
    {
        public CocktailListPage()
        {
            InitializeComponent();
            test();
        }

        public void test()
        {
            foreach (var i in CocktailAPI.Search("Vodka"))
            {
                Console.Write(i.idDrink + " ;");
                Console.WriteLine(i.strDrink);
            }
        }
    }
}