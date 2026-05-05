using TripListApp.Models;
using Xunit;

namespace TripListAppTests.Models
{
    public class ItemTests
    {
        [Fact]
        public void NewItem_IsUnpackedByDefault()
        {
            var item = new Item("Towel");

            Assert.Equal("Towel", item.Name);
            Assert.False(item.PackedStatus);
        }

        [Fact]
        public void MarkPacked_ChangesPackedStatusToTrue()
        {
            var item = new Item("Towel");

            item.MarkPacked();

            Assert.True(item.PackedStatus);
        }

        [Fact]
        public void MarkUnpacked_ChangesPackedStatusToFalse()
        {
            var item = new Item("Towel");
            item.MarkPacked();

            item.MarkUnpacked();

            Assert.False(item.PackedStatus);
        }
    }
}