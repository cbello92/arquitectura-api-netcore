using Arquitectura.Core.Exceptions;
using Arquitectura.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace ArquitecturaAPI.Users.Data
{
    public class UserRepository
    {
        private readonly DbAccessContext _context;

        public UserRepository(DbAccessContext context)
        {
            _context = context;
        }

        public List<UserModel> All()
        {
            List<UserModel> usersList = new List<UserModel>();
            DbAccessContext context = null;

            try
            {
                context = _context.Create();
                context.Database.OpenConnection();

                DbCommand cmd = context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "SELECT * FROM users";
                using var reader = cmd.ExecuteReader();

                //throw new KeyNotFoundException("error");

                while (reader.Read())
                {
                    UserModel UserDTO = new UserModel
                    {
                        Id = Convert.ToInt32(reader["id"].ToString()),
                        Name = reader["name"].ToString(),
                        Lastnames = reader["lastnames"].ToString(),
                        Email = reader["email"].ToString()
                    };

                    usersList.Add(UserDTO);
                }
                reader.Close();

                return usersList;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                context.Database.CloseConnection();
            }      
        }
    }
}
