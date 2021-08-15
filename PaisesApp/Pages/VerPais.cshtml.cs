using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PaisesApp.Models;

namespace PaisesApp.Pages
{
    public class VerPaisModel : PageModel
    {
        public PaisCompleto[] pais;
        public int res = 2;

        public async Task<IActionResult> OnGetAsync(string termino)
        {
            if (termino == null)
            {
                return Page();
            }

            try
            {
                HttpClient http = new HttpClient();
                string response = await http.GetStringAsync($"https://restcountries.eu/rest/v2/name/{termino}?fields=name;capital;borders;region;area;languages;translations;flag;population");

                pais = JsonConvert.DeserializeObject<PaisCompleto[]>(response);
                ViewData["respuesta"] = JsonConvert.SerializeObject(pais, Formatting.Indented);
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

