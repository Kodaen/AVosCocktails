using CocktailDB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        }

        protected virtual void OnAppearing ()
        {
            base.OnAppearing();
            foreach (var i in CocktailAPI.SearchByLetter('a'))
            {
                Debug.WriteLine(i.strDrink + " ;");
            }
        }

    }
}