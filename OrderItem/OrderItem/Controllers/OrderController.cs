using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderItem.Models;

namespace OrderItem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,POC")]
    public class OrderController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetCartById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44350/api/");
                var responseTask = client.GetAsync("MenuItem");
                responseTask.Wait();
                var result = responseTask.Result;
                List<Cart> Items = new List<Cart>();
                if (result.IsSuccessStatusCode)
                {
                    string jsonData = result.Content.ReadAsStringAsync().Result;
                    Items = JsonConvert.DeserializeObject<List<Cart>>(jsonData);
                    Cart obj1 = Items.SingleOrDefault(x => x.Id == id);

                    obj1.MenuItemId = 1;
                    obj1.UserId = 1;
                    return Ok(obj1);
                }
                else
                {
                    return BadRequest();
                }
            } 
        }
    }
}
