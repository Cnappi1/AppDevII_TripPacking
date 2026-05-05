using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TripListApp.Models
{

    /// <summary>
    /// Manages a collection of packing lists.
    /// Provides functionality to create, delete, and retrieve lists.
    /// </summary>
    public class ListManager
    {
        public List<PackingList> ListCollection { get; private set; }

        /// <summary>
        /// Creates a new ListManager with an empty list collection.
        /// </summary>
        public ListManager()
        {
            ListCollection = new List<PackingList>();
        }

        /// <summary>
        /// Creates a new packing list and adds it to the collection.
        /// </summary>
        /// <param name="listName">The name of the new packing list.</param>
        public void CreateList(string listName)
        {
            ListCollection.Add(new PackingList(listName));
        }

        /// <summary>
        /// Deletes a packing list by name.
        /// </summary>
        /// <param name="listName">The name of the list to delete.</param>
        public void DeleteList(string listName)
        {
            ListCollection.RemoveAll(l => l.ListName.Equals(listName, System.StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Retrieves all packing lists.
        /// </summary>
        /// <returns>A list of packing lists.</returns>
        public List<PackingList> GetLists()
        {
            return ListCollection;
        }

        /// <summary>
        /// Retrieves a specific packing list by name.
        /// Returns null if no matching list is found.
        /// </summary>
        /// <param name="listName">The name of the list to retrieve.</param>
        /// <returns>The matching PackingList, or null if not found.</returns>
        public PackingList? GetListByName(string listName)
        {
            return ListCollection
                .FirstOrDefault(l => l.ListName.Equals(listName, StringComparison.OrdinalIgnoreCase));
        }
    }

}
