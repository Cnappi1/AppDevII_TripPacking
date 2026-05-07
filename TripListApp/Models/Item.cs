using System;
using System.Collections.Generic;
using System.Text;

namespace TripListApp.Models
{
    /// <summary>
    /// Represents a single item in a packing list.
    /// Each item has a name and a packed/unpacked status.
    /// </summary>
    public class Item
    {
    
        public int ItemId { get; set; }
        public int PackingListId { get; set; }

        public string Name { get; set; } = string.Empty;
        public bool PackedStatus { get; set; }

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public Item()
        {

        }

        /// <summary>
        /// Creates a new Item with the given name.
        /// Items are unpacked by default.
        /// </summary>
        /// <param name="name">The name of the item.</param>
        public Item(string name)
        {
            Name = name;
            PackedStatus = false;
        }

        /// <summary>
        /// Marks the item as packed.
        /// </summary>
        public void MarkPacked()
        {
            PackedStatus = true;
        }

        /// <summary>
        /// Marks the item as unpacked.
        /// </summary>
        public void MarkUnpacked()
        {
            PackedStatus = false;
        }

        public override string ToString()
        {
            return $"{Name} (Packed: {PackedStatus})";
        }
    }
}
