using System.Collections.Generic;
using System.Linq;
using TableBooking.Models;

namespace TableBooking.Data
{
	public static class TableManager
	{
		public static List<TableModel> Tables { get; set; } = GetAllTables();
		public static int RestaurantSpace { get; set; } = 20;

		public static List<TableModel> GetAllTables()
		{
			if(Tables == null || !Tables.Any())
			{
				Tables = new List<TableModel>()
				{
					new TableModel()
					{
						Number = 1,
						Seats = 2
					},
					new TableModel()
					{
						Number = 2,
						Seats = 2
					},
					new TableModel()
					{
						Number = 3,
						Seats = 4
					},
					new TableModel()
					{
						Number = 4,
						Seats = 4
					},
					new TableModel()
					{
						Number = 5,
						Seats = 4
					},
					new TableModel()
					{
						Number = 6,
						Seats = 4
					},
					new TableModel()
					{
						Number = 7,
						Seats = 6
					},
					new TableModel()
					{
						Number = 8,
						Seats = 6
					},
				}; // Create new tables and put in Tables property
			}

			return Tables;
		} // Return list of tables

		public static string BookTable(int number, string name, int requestedSeats)
		{
			TableModel table = Tables.Where(table => table.Number == number).FirstOrDefault();

			if (table != null) // Check if table exists
			{
				if (table.Booked) // Table is already booked
				{
					return "Table is already booked!";
				}
				else if (table.Seats < requestedSeats) // Table doesn't have enough seats
				{
					return "Table doesn't have enough seats!";
				}
				else  // Book table!
				{
					int index = Tables.FindIndex(table => table.Number == number);

					Tables[index].Number = table.Number;
					Tables[index].Name = name;
					Tables[index].SeatsOccupied = requestedSeats;
					Tables[index].Booked = true;

					return "Table successfully booked!";
				}
			}
			else // Table doesn't exist
			{
				return "The table doesn't exist!";
			}
		} // Change property Booked of table to true

		public static string UnbookTable(int number)
		{
			TableModel table = Tables.Where(table => table.Number == number).FirstOrDefault();

			if (table != null) // Check if table exists
			{
				int index = Tables.FindIndex(table => table.Number == number);

				Tables[index] = new TableModel()
				{
					Number = table.Number,
					SeatsOccupied = 0,
					Booked = false
				};

				return "Table successfully unbooked!";
			}
			else // Table doesn't exist
			{
				return "The table doesn't exist!";
			}
		} // Change property Booked of table to false

		public static string AddTable(TableModel tableToAdd)
		{
			for (int i = 1; i <= RestaurantSpace; i++) // Loop over potential restaurant space
			{
				TableModel table = Tables.Where(table => table.Number == i).FirstOrDefault();

				if (table == null) // Found empty spot in restaurant
				{
					tableToAdd.Number = i;

					Tables.Add(tableToAdd);

					return $"Table successfully created! Its number is {i}";
				}
			}

			return "Not enough restaurant space!";
		} // Add a new table to the restaurant

		public static string DeleteTable(int number)
		{
			TableModel table = Tables.Where(table => table.Number == number).FirstOrDefault();

			if (table != null) // Check if table exists
			{
				Tables.Remove(table);

				return "Table successfully removed!";
			}
			else // Table doesn't exist
			{
				return "The table doesn't exist!";
			}
		}  // Delete a table from the restaurant

		public static string RebuildRestaurant(int expansion)
		{
			RestaurantSpace += expansion;

			return "Restaurant successfully rebuilt!";
		} // Create more restaurant space
	}
}