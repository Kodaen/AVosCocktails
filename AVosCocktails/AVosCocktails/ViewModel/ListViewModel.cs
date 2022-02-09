using CocktailDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AVosCocktails.ViewModel
{
    class ListViewModel: BaseViewModel 
    {
        private static ListViewModel _instance = new ListViewModel();

        public static ListViewModel Instance {
            get { return _instance; }
        }

        public ObservableCollection<CocktailAPI> ListOfCocktail
        {
            get => GetValue(ObservableCollection<CocktailAPI>)();

            set => SetValue(value);
        }
    }
}
