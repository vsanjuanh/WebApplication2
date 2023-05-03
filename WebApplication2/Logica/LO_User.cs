using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using WebApplication2.Models;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication2.Logica
{
    public class LO_User
    {
        public Users EncontrarUruario(string user , string clave)
        {
            Users us = new Users();

            using (SqlConnection conexion = new SqlConnection("Data Source=(localdb)\\Servidor; Initial Catalog = autenticacion; Integrated Security=True;"))
            {
                string query = "select Nombre,Usuario,Clave,IdRol,Region from Users where Usuario = @pusuario and Clave = @pclave ";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@pusuario", user ?? " ");
                cmd.Parameters.AddWithValue("@pclave", clave  ?? " ");
                cmd.CommandType = CommandType.Text;

                conexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        us = new Users()
                        {
                            Nombre = dr["Nombre"].ToString(),
                            Usuario = dr["Usuario"].ToString(),
                            Clave = dr["Clave"].ToString(),
                            IdRol = dr["IdRol"].ToString(),
                            Region = dr["Region"].ToString(),
                        };
                    }
                }
            }
            return us;
        }
    }
}
