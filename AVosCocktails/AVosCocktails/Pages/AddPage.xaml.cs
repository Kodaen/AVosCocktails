using AVosCocktails.Model;
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

            var photoMode = new List<string>();
            photoMode.Add("Depuis une URL");
            photoMode.Add("Depuis la galerie");

            picker.ItemsSource = photoMode;
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            var imageURL = "";
            
            if (!string.IsNullOrWhiteSpace(nameEntry.Text)
                    && !string.IsNullOrWhiteSpace(instructionsEntry.Text)
                    && !string.IsNullOrWhiteSpace(ingredientsEntry.Text)
                    && !string.IsNullOrWhiteSpace(imageEntry.Text)
                    && !string.IsNullOrWhiteSpace(tagsEntry.Text))
            {
                await App.Database.SaveCocktailAsync(new LocalCocktail() {
                    Name = nameEntry.Text,
                    Instructions = instructionsEntry.Text,
                    Ingredients = ingredientsEntry.Text,
                    Image = imageEntry.Text,
                    Tags = tagsEntry.Text
                });
            }
            
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

            string test = selectedImageFile.Path;
            //selectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
            //selectedImage.Source = test;
            imageEntry.Text = test;
        }

        private void picker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (picker.SelectedItem == "Depuis une URL") {
                imageEntry.IsVisible = true;
                imageEntryGalery.IsVisible = false;
            } else
            {
                imageEntry.IsVisible = false;
                imageEntryGalery.IsVisible = true;
            }
        }

        private void imageEntry_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            selectedImage.Source = imageEntry.Text;
        }
    }
}