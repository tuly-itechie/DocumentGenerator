using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace DocumentGenerator.Pages
{
    public class IndexModel : PageModel
    {
        // Holds the list of countries
        public List<CountryData> Countries { get; set; } = new();

        // This will hold the JSON-serialized data for JavaScript to use
        public string CountriesJson { get; set; } = "[]";

        public void OnGet()
        {
            try
            {
                // Seeding the data safely
                Countries = new List<CountryData>
                {
                    new() { CountryName = "Bangladesh", Area = "147,570 km²", Population = "173 Million", Currency = "BDT (Taka)", Language = "Bengali", NationalFlower = "Water Lily" },
                    new() { CountryName = "Canada", Area = "9.98 Million km²", Population = "40 Million", Currency = "CAD (Dollar)", Language = "English/French", NationalFlower = "Maple Leaf" },
                    new() { CountryName = "Japan", Area = "377,975 km²", Population = "124 Million", Currency = "JPY (Yen)", Language = "Japanese", NationalFlower = "Cherry Blossom" },
                    new() { CountryName = "UK", Area = "1077,975 km²", Population = "100 Million", Currency = "Doollar ", Language = "English", NationalFlower = "Cheery" },
                    new() { CountryName = "USA", Area = "577,975 km²", Population = "155 Million", Currency = "Doollar ", Language = "English", NationalFlower = "Lily" },


                };

                // Serialize with CamelCase for easier JavaScript formatting
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                CountriesJson = JsonSerializer.Serialize(Countries, options);
            }
            catch (Exception ex)
            {
                // Professional error fallback
                CountriesJson = "[]";
                ModelState.AddModelError(string.Empty, $"Error loading country data: {ex.Message}");
            }
        }
    }


    public class CountryData
    {
        public string CountryName { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string Population { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string NationalFlower { get; set; } = string.Empty;
    }
}
