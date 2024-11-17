using FirstProje.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProje.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private static List<UserModel> _users = new List<UserModel>()
        {
            new UserModel{UserId = 1,UserName="Eren",UserUnvan=".Net Developer"},
            new UserModel{UserId = 2,UserName="Efe Esen",UserUnvan="PHP Developer"},
            new UserModel{UserId = 3,UserName="Kasım Hoca",UserUnvan="JavaScript Developer"} 
        };

        [HttpGet("List")]
        public IActionResult UserList()
        {
            return Ok(_users);
        }
        // burda id ye göre isim gösteriyoruz

        [HttpGet("GetByIdUser/{id}")]
        public IActionResult GetByIdUsers(int id)
        {
            var user = _users.FirstOrDefault(x => x.UserId == id);
            if (user == null)
            {
                return NotFound(new { Message = id + " id'sine Ait Kullanıcı bulunamadı" }); 
            }
            return Ok(user);
        }

        // burası ekleme yapmak için post işlemi yapar 
        [HttpPost("UserAdd")]

        public IActionResult UserAdd(UserModel newUser)
        {
            newUser.UserId = _users.Max(x => x.UserId) +1;
            _users.Add(newUser);
            return Ok(newUser);
        }



        // güncelleme verileri kısmı  
        [HttpPut("UserUpdate/{id}")]

        public IActionResult UpdateUser(int id,UserModel newUser)
        {
            var user = _users.FirstOrDefault(p => p.UserId == id);
            if (user == null)
            {
                return NotFound(new { Message = "Kullanıcı Bulunamadı" });
            }
            user.UserName = newUser.UserName;
            user.UserUnvan = newUser.UserUnvan;
            return Ok(_users);
        }


        // Silme İşlemi kısmı
        [HttpDelete("UserDelete/{id}")]
        public IActionResult UserDelete(int id)
        {
            var user = _users.FirstOrDefault(p=>p.UserId == id);
            if (user == null)
            {
                return NotFound(new { Message = "Kullanıcı Bulunamadı" });
            }
            _users.Remove(user);
            return Ok(_users);
            
        }




    }
}
