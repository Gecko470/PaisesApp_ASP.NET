using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using PaisesApp.Models;
using System.Text.Json;

namespace PaisesApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string termino { get; set; } = null;
        public Pais[] paises;
        public int res = 2;
        public async Task<IActionResult> OnPostAsync()
        {
            if(termino == null)
            {
                res= -1;
                return Page();
            }

            try
            {
            HttpClient http = new HttpClient();
            string response = await http.GetStringAsync($"https://restcountries.eu/rest/v2/name/{termino}?fields=name;capital;flag;population");

            paises = JsonSerializer.Deserialize<Pais[]>(response);

                res = 1;
                return Page();
            }
            catch (Exception ex)
            {
                res = 0;
                return Page();
            }
        }
    }
}
