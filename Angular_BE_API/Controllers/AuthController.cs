using Angular_BE_API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Angular_BE_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<LoginResultViewModel> Login([FromBody] LoginViewModel form)
        {
            Console.WriteLine(form);
            return new LoginResultViewModel(true, "TEST");
        }
    }
}
