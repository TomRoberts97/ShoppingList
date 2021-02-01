using ShoppingList.Models;
using ShoppingList.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoppingList.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }

        public List<Meal> MealList { get; set; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Shopping List";

            Items = new ObservableCollection<Item>();

            MealList = new List<Meal>();
            // testing meal/item grouping
            //CreateMealList();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand()); //  needed for Filling Items from the MockDataStore
            //LoadItemsCommand = new Command(CreateMealList); // testing loading meal data

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);

            
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }

               


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Item item)
        {

            Console.WriteLine("OnItemSelected Run!");

            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }

        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Description { get; set; }

        public void CreateMealList()
        {
            MealList.Add(

                new Meal("Chicken Curry", new List<Item>
                {
                    new Item { Name = "Chicken Breast", Description = "A breast of chicken", Quantity = 2},
                    new Item
                    {
                        Name = "Curry Paste",
                        Description = "Indian curry paste",
                        Quantity = 1
                    }

                }));

            MealList.Add(new Meal("Beef Noodles", new List<Item>
                {
                    new Item
                    {
                        Name = "Beef Strips",
                        Description = "A packet of Beef steak, cut into strips",
                        Quantity = 1
                    },
                    new Item
                    {
                        Name = "Rice Noodles",
                        Description = "Noodles made from Rice, Gluten free!",
                        Quantity = 2
                    },
                      new Item
                    {
                        Name = "Sweet and Sour sauce",
                        Description = "A Jar of branded Sweet and Sour sauce",
                        Quantity = 1
                    }

                }));
            
            Console.WriteLine("Test MealsList count:" + MealList.Count);

        }
    }
}