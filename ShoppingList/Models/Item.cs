using System;

namespace ShoppingList.Models
{

    //design custom ControllerView rows using;    Webpage for similar design
    // image of an item/meal (each class will need an image field),
    // Largest Text = Items name
    

    //How can i display a Meal in ControllerView?
    // Is there an ability to 'Expand' like the arrows in the Solution Explorer
    // A Meal can be 'Expanded' into its Items
    // Can this be done in the ControllerView (Prefered option) (need working delete on Items, On LongClick) or will I need 

    //ShoppingList Main ControllerView;
    // click - Show EditItem/EditMeal Page
    // LongClick - Delete Item
    // Details for items another way, Could have details page in flyout thing 


    // look into search feature on a controller view, or a way a user can search for a Meal or Item by Name, ItemType ect
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; } // this can be seen as Name (change after seeing functionality of variable)
        public string Description { get; set; }

        // how to save images, do items need images or Just Meals?
        public int Quantity { get; set; }
        
        // ItemType (Fruit, Veg , ect)(go over shop categories)(Use a drop down list for user input)

        // measurement (ml,grams ect)(drop down list for user to choose) 

       




        // ideas
        // Price Estimate? (needs shop data , or some sort of API )
        //


    }
}