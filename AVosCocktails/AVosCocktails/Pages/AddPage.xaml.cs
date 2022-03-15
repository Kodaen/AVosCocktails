using Plugin.Media;
using Plugin.Media.Abstractions;
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

            var numberOfIngredients = new List<string>();
            for (int i = 1; i < 14; i++)
            {
                numberOfIngredients.Add(i.ToString());
            }

            picker.ItemsSource = numberOfIngredients;

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

        async void SelectImage(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if(!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Not supported", "Your device does not support this functionnality", "Ok");
                return;
            }
            var mediaOptions = new PickMediaOptions(){PhotoSize = PhotoSize.Medium};

            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

            if(selectedImage == null)
            {
                await DisplayAlert("Error", "Could not get the image, please try again.", "Ok");
                return;
            }
            selectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
        }
    }
}