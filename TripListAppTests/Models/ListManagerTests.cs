using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripListApp.Models;
using Xunit;

namespace TripListAppTests.Models
{
    public class ListManagerTests
    {
        [Fact]
        public void GetTotalTripBudgetsForYear_ReturnsCorrectTotal()
        {
            var manager = new ListManager();

            manager.ListCollection.Add(new PackingList { ListName = "Beach Trip", TripBudget = 800, TripYear = 2026 });
            manager.ListCollection.Add(new PackingList { ListName = "NYC Trip", TripBudget = 1000, TripYear = 2026 });
            manager.ListCollection.Add(new PackingList { ListName = "Disney Trip", TripBudget = 2500, TripYear = 2027 });

            var result = manager.GetTotalTripBudgetsForYear(2026);
            Assert.Equal(1800, result);

        }

        [Fact]
        public void GetRemainingBudget_ReturnsCorrectAmount()
        {
            var manager = new ListManager();
            manager.YearlyTravelBudget = 5000;

            manager.ListCollection.Add(new PackingList { ListName = "Beach Trip", TripBudget = 800, TripYear = 2026 });

            var result = manager.GetRemainingYearlyBudget(2026);
            Assert.Equal(4200, result);

        }

        [Fact]
        public void CanPlanAnotherTrip_WhenEnoughBudgetRemains()
        {
            var manager = new ListManager();
            manager.YearlyTravelBudget = 5000;

            manager.ListCollection.Add(new PackingList { ListName = "Beach Trip", TripBudget = 800, TripYear = 2026 });
            var result = manager.CanPlanAnotherTrip(2026, 1000);

            Assert.True(result);
        }
        [Fact]
        public void CanPlanAnotherTrip_WhenNotEnoughBudgetRemains()
        {
            var manager = new ListManager();
            manager.YearlyTravelBudget = 5000;

            manager.ListCollection.Add(new PackingList { ListName = "Beach Trip", TripBudget = 4800, TripYear = 2026 });
            var result = manager.CanPlanAnotherTrip(2026, 1000);

            Assert.False(result);
        }

        [Fact]
        public void GetTravelStatus_ReturnsReadyToTravel_WhenPackedAndWithinBudget()
        {
            var manager = new ListManager();
            manager.YearlyTravelBudget = 5000;

            var list = new PackingList { ListName = "Beach Trip", TripBudget = 800, TripYear = 2026 };
            var item = new Item("Towel");
            item.MarkPacked();
            list.AddItem(item);

            manager.ListCollection.Add(list);

            var result = manager.GetTravelStatus(list);

            Assert.Equal("Ready to Travel", result);
        }

        [Fact]
        public void GetTravelStatus_ReturnsNotReadyToTravel_WhenNotPacked()
        {
            var manager = new ListManager();
            manager.YearlyTravelBudget = 5000;

            var list = new PackingList { ListName = "Beach Trip", TripBudget = 800, TripYear = 2026 };
            var item = new Item("Towel");
            list.AddItem(item);

            manager.ListCollection.Add(list);

            var result = manager.GetTravelStatus(list);

            Assert.Equal("Not Ready to Travel", result);
        }
    }
}
