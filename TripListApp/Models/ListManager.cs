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

        public ListManager(List<PackingList> lists, decimal yearlyTravelBudget)
        { 
            ListCollection = lists;
            YearlyTravelBudget = yearlyTravelBudget;
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
        /// <summary>
        /// Yearly Travel Budget
        /// </summary>
        public decimal YearlyTravelBudget { get; set; }

        /// <summary>
        /// Total of all the trips budgets for the year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public decimal GetTotalTripBudgetsForYear(int year)
        {
            return ListCollection
                .Where(list => list.TripYear == year)
                .Sum(list => list.TripBudget);
        }
        /// <summary>
        /// Determines how much money is left in the users yearly budget
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public decimal GetRemainingYearlyBudget(int year)
        {
            return YearlyTravelBudget - GetTotalTripBudgetsForYear(year);
        }

        /// <summary>
        /// Calculates if there is enough money left in the yearly budget to plan another trip
        /// </summary>
        /// <param name="year"></param>
        /// <param name="estimatedTripBudget"></param>
        /// <returns></returns>
        public bool CanPlanAnotherTrip(int year, decimal estimatedTripBudget)
        {
            return estimatedTripBudget <= GetRemainingYearlyBudget(year);
        }

        /// <summary>
        /// Determines if a trip is ready to travel based on budget and items packed
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool IsReadyToTravel(PackingList list)
        {
            bool hasItems = list.Items.Any();
            bool allItemsPacked = list.Items.All(item => item.PackedStatus);
            bool withinBudget = GetTotalTripBudgetsForYear(list.TripYear) <= YearlyTravelBudget;

            return hasItems && allItemsPacked && withinBudget;
        }
        /// <summary>
        /// Returns if a trip is ready to travel based on budget and if all items are packed
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string GetTravelStatus(PackingList list)
        {
            if (IsReadyToTravel(list))
            {
                return "Ready to Travel";
            }

            return "Not Ready to Travel";
        }
    }

}
