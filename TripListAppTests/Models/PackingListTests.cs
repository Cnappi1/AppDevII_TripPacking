using TripListApp.Models;
using Xunit;

namespace TripListAppTests.Models
{
    public class PackingListTests
    {
        [Fact]
        public void NewPackingList_HasCorrectNameAndNoItems()
        {
            var list = new PackingList("Beach Trip");

            Assert.Equal("Beach Trip", list.ListName);
            Assert.Empty(list.Items);
        }

        [Fact]
        public void AddItem_AddsItemToPackingList()
        {
            var list = new PackingList("Beach Trip");
            var item = new Item("Towel");

            list.AddItem(item);

            Assert.Single(list.Items);
        }

        [Fact]
        public void RemoveItem_RemovesItemByName()
        {
            var list = new PackingList("Beach Trip");
            var item = new Item("Towel");

            list.AddItem(item);
            list.RemoveItem("Towel");

            Assert.Empty(list.Items);
        }
    }
}