using Microsoft.AspNetCore.Mvc;

namespace JsonPropertyNameInValidation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        public IActionResult Index(User user)
        {
            if(ModelState.IsValid)
            {
                return Ok("User created successfully!");
            }

            return UnprocessableEntity(ModelState);
        }
    }
}
