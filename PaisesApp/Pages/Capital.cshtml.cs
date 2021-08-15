using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaisesApp.Models;

namespace PaisesApp.Pages
{
    public class CapitalModel : PageModel
    {
        [BindProperty]
        public string termino { get; set; } = null;
        public Pais[] paises;
        public int res = 2;
        public async Task<IActionResult> OnPostAsync()
        {
            if (termino == null)
            {
                res = -1;
                return Page();
            }

            try
            {
                HttpClient http = new HttpClient();
                string response = await http.GetStringAsync($"https://restcountries.eu/rest/v2/capital/{termino}?fields=name;capital;alpha2Code;flag;population");

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
