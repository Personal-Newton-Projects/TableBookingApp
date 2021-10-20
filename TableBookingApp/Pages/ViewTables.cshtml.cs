using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TableBooking.Data;
using TableBooking.Models;

namespace TableBooking.Pages
{
    public class ViewTablesModel : PageModel
    {
        public string Message { get; set; }
        public void OnGet(bool add, bool remove)
        {
            Message = BooktableModel.Message;

            if(add)
            {
                Message = TableManager.AddTable(new TableModel() { Seats = 4 });
            }
            if (remove)
            {
                Message = TableManager.DeleteTable(TableManager.Tables.Count);
            }

        }
    }
}
