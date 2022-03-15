using AVosCocktails.Model;
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
    public partial class DetailPage : ContentPage
    {
        public DetailPage(LocalCocktail Cocktail )
        {
            InitializeComponent();
            BindingContext = Cocktail;
        }

        private void c_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}