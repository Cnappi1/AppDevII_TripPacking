using System;
using System.Collections.Generic;
using System.Text;

namespace TripListApp.Models
{

    using System.Collections.Generic;

    /// <summary>
    /// Represents a packing list for a specific trip.
    /// A packing list contains a name and a collection of items.
    /// </summary>
    public class PackingList
    {
        public int PackingListId { get; set; }
        public string ListName { get; set; } = string.Empty;
        public List<Item> Items { get; private set; } = new List<Item>();


        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public PackingList()
        {
        }

        /// <summary>
        /// Creates a new packing list with the given name.
        /// </summary>
        /// <param name="listName">The name of the packing list.</param>
        public PackingList(string listName)
        {
            ListName = listName;
        }

        /// <summary>
        /// Adds an item to the packing list.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        /// <summary>
        /// Removes an item from the packing list by name.
        /// </summary>
        /// <param name="itemName">The name of the item to remove.</param>
        public void RemoveItem(string itemName)
        {
            Items.RemoveAll(i => i.Name.Equals(itemName, System.StringComparison.OrdinalIgnoreCase));
        }

        public override string ToString()
        {
            return $"Packing List: {ListName} ({Items.Count} items)";
        }


    }
}
