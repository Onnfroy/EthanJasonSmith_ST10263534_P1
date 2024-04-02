using CLDV6211_POE_P1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CLDV6211_POE_P1.Controllers
{
    public class UserController : Controller
    {
        private static string con_string = "Server=tcp:cldv-froy.database.windows.net,1433;Initial Catalog=onnfroy;Persist Security Info=False;User ID=onnfroy;Password=Lospolos1738;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private static SqlConnection con = new SqlConnection(con_string);

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult User(UserTable Users)
        {
            int result = insert_User(Users);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult User()
        {
            UserTable model = new UserTable();
            return View(model);

        }
        private int insert_User(UserTable n)
        {
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "INSERT INTO UserTable (userName, userSurname, userEmail) VALUES (@Name, @Surname, @Email); SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Name", n.Name);
                    cmd.Parameters.AddWithValue("@Surname", n.Surname);
                    cmd.Parameters.AddWithValue("@Email", n.Email);
                    con.Open();
                    object result = cmd.ExecuteScalar();

                    //Check result is DBNull.Value
                    int usersID = result == DBNull.Value ? -1 : Convert.ToInt32(result);

                    return usersID;

                }

            }
        }
    }
}



