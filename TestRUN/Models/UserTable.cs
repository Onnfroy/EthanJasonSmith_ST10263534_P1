using System.Data.SqlClient;

namespace CLDV6211_POE_P1.Models
{
    public class UserTable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public int insert_User()
        {
            string con_string = "Server=tcp:cldv-froy.database.windows.net,1433;Initial Catalog=onnfroy;Persist Security Info=False;User ID=onnfroy;Password=Lospolos1738;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    string sql = "INSERT INTO UserTable (userName, userSurname, userEmail) VALUES (@Name, @Surname, @Email)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Surname", Surname);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected;
                    }
                }
            }
            catch (Exception ex)
            {
                //Handle the exception, log it, throw it further
                Console.WriteLine($"An error occurred: {ex.Message}");
                return -1; // Or throw exception
            }

        }
    }
}


