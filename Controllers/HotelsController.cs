using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using HotelAPI.Models;

namespace HotelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly string _dataFile = "./Data/Hotels.json";

        // GET /api/hotels
        [HttpGet]
        public IActionResult GetHotels()
        {
            var hotels = ReadHotelData();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public IActionResult GetHotelById(int id)
        {
            var hotels = ReadHotelData();
            var hotel = hotels.FirstOrDefault(h => h.Id == id);

            if (hotel == null)
            {
                // Return a 404 Not Found with an appropriate error message
                return NotFound(new { Message = "Hotel not found." });
            }

            return Ok(hotel); // Return the hotel if found
        }


       private List<Hotel> ReadHotelData()
        {
            try
            {
                // Read the JSON file content
                var json = System.IO.File.ReadAllText(_dataFile);
             

                // Deserialize the JSON into a list of Hotel objects
                var hotels = JsonSerializer.Deserialize<List<Hotel>>(json);
                if (hotels == null)
                {
                  
                    return new List<Hotel>();
                }

              
                return hotels;
            }
            catch (Exception ex)
            {
               
                return new List<Hotel>(); // Return an empty list to prevent further issues
            }
        }


    }
}
