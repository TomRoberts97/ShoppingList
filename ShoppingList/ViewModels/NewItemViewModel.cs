using ShoppingList.Models;
using ShoppingList.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShoppingList.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string name;
        private string description;
        private int quantity;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(description);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public int Quantity 
        {
            get => quantity;
            set => SetProperty(ref quantity, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Description = Description,
                Quantity = Quantity
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }



        //public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        //public ICommand PerformSearch => new Command<string>((string query) =>
        //{
        //    SearchResults = DataService.GetSearchResults(query);
        //});

        private List<string> searchResults;
            //= DataService.Fruits;
        public List<string> SearchResults
        {
            get
            {
                return searchResults;
            }
           set
            {
                searchResults = value;
                //NotifyPropertyChanged();
            }
        }

        public void OnTextChanged(object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            searchResults = DataService.GetSearchResults(searchBar.Text);
            
        }

    }
}
