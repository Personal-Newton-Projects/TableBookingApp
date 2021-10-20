using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TableBooking.Data;

namespace TableBooking.Pages
{
    public class BooktablesModel : PageModel
    {
        [BindProperty]
        public int TableNumber { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public int Seats { get; set; }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            TableManager.BookTable(TableNumber, FirstName, Seats);
        }
    }
}
