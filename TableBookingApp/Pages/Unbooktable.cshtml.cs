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
    public class UnbookooktablesModel : PageModel
    {
        [BindProperty]
        [Required]
        public int TableNumber { get; set; }

        public static string Message { get; set; }


        public void OnGet(int number)
        {
            TableNumber = number;

        }
        public ActionResult OnPost()
        {
            Message = TableManager.UnbookTable(TableNumber);
            return RedirectToPage("/ViewTables");
        }
    }
}
