
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RegisterUser.Data
{
    public class UserRepository: IUserRepository
    {
        private readonly MySqlConnection _connection;
        public UserRepository()
        {
            _connection = new MySqlConnection("Server=10.222.3.178;Database=DBUser;Uid=root;Pwd=admin");

        }
        public Users GetUser(Guid Id)
        {
            try
            {
                try
                {
                    _connection.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM TbUser where Id=@Id", _connection);
                    cmd.Parameters.Add("@Id",MySqlDbType.String);
                    cmd.Parameters["@Id"].Value = Id.ToString();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if(reader.HasRows)
                    {
                        return new Users
                        {
                            Id = Guid.Parse(reader["Id"].ToString()),
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            WebSite = reader["WebSite"].ToString()
                        };
                    }else
                    {
                        return new Users();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return new Users();
                }
            }
            finally
            {
                _connection.Close();
            }
        }


        public List<Users> GetAllUsers()
        {

            List<Users> lstusers = new List<Users>();

            try
            {
                try
                {
                    _connection.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM TbUser", _connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lstusers.Add(
                            new Users
                            {
                                Id = Guid.Parse(reader["Id"].ToString()),
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString(),
                                WebSite = reader["WebSite"].ToString()
                            }
                        );
                    }
                    return lstusers;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return new List<Users>();
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        public PostUser PostUser(Users body)
        {
            try
            {
                try
                {
                    string sql = "Insert into TbUser (Id, Name, Email, WebSite) values (@Id, @Name, @Email, @WebSite)";

                    _connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, _connection);
                    cmd.Parameters.AddWithValue("@Id", body.Id.ToString());
                    cmd.Parameters.AddWithValue("@Name", body.Name);
                    cmd.Parameters.AddWithValue("@Email", body.Email);
                    cmd.Parameters.AddWithValue("@WebSite", body.WebSite);

                    bool result = (cmd.ExecuteNonQuery()==1);
                    return new PostUser{ Success=result, Message=(result?"": "Erro ao processar") };
                }
                catch(Exception ex)
                {
                    return new PostUser{ Success=false, Message=ex.Message };
                }
            }
            finally
            {
               _connection.Close();
            }

        }

        public PostUser PutUser(Guid Id, Users body)
        {
            try
            {
                try
                {
                    string sql = "Update TbUser set Name=@Name, Email=@Email, WebSite=@WebSite where Id=@Id";

                    _connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, _connection);
                    cmd.Parameters.AddWithValue("@Id", Id.ToString());
                    cmd.Parameters.AddWithValue("@Name", body.Name);
                    cmd.Parameters.AddWithValue("@Email", body.Email);
                    cmd.Parameters.AddWithValue("@WebSite", body.WebSite);

                    bool result = (cmd.ExecuteNonQuery()==1);
                    return new PostUser{ Success=result, Message=(result?"": "Erro ao processar") };
                }
                catch(Exception ex)
                {
                    return new PostUser{ Success=false, Message=ex.Message };
                }
            }
            finally
            {
               _connection.Close();
            }

        }

        public bool DeleteUser(Guid Id)
        {
            try
            {
                try
                {
                    string sql = "Delete from TbUser where Id=@Id";

                    _connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, _connection);
                    cmd.Parameters.AddWithValue("@Id", Id.ToString());
                    return (cmd.ExecuteNonQuery()==1);
                }
                catch(Exception ex)
                {
                    Console.Write(ex.Message);
                    throw new Exception();
                }
            }
            finally
            {
               _connection.Close();
            }
        }
    }
}

