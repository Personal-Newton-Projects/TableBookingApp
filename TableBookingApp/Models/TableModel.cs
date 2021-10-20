using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TableBooking.Models
{
	public class TableModel
	{
		public int Number { get; set; }
		public string Name { get; set; }
		public int Seats { get; set; }
		public int SeatsOccupied { get; set; }
		public bool Booked { get; set; }
	}
}
