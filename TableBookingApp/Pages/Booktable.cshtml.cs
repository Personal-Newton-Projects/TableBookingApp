using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TableBooking.Data;

namespace TableBooking.Pages
{
    public class BooktableModel : PageModel
    {
        [BindProperty]
        [Required]
        public int TableNumber { get; set; }
        [BindProperty]
        [Required]
        public string FirstName { get; set; }
        [BindProperty]
        [Required]
        public int Seats { get; set; }

        public DateTime Time { get; set; }

        public static string Message { get; set; }

        public void OnGet(int number)
        {
            TableNumber = number;
        }
        public ActionResult OnPost()
        {
            Message = TableManager.BookTable(TableNumber, FirstName, Seats, Time);
            return RedirectToPage("/ViewTables");
        }
    }
}
