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
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("clické");
            //if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(ageEntry.Text))
            //{
            //    await MainPage.Database.SavePersonAsync(new Person
            //    {
            //        Name = nameEntry.Text,
            //        Age = int.Parse(ageEntry.Text)
            //    });

            //    nameEntry.Text = ageEntry.Text = string.Empty;
            //    collectionView.ItemsSource = await App.Database.GetPeopleAsync();
            //}
        }
    }
}