using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DataBaseSample1
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
            Console.WriteLine(connectionString);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                //
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                string name = "Cooper";
                DateTime birth = new DateTime(1990, 2, 7);
                string email = "cooper@hotmail.com";
                int family = 5;

                SqlParameter paramName = new SqlParameter("Name", System.Data.SqlDbType.NVarChar, 20);
                paramName.Value = name;

                SqlParameter paramBirth = new SqlParameter("Birth", System.Data.SqlDbType.Date);
                paramBirth.Value = birth;

                SqlParameter paramEmail = new SqlParameter("Email", System.Data.SqlDbType.NVarChar, 100);
                paramEmail.Value = email;

                SqlParameter paramFamily = new SqlParameter("Family", System.Data.SqlDbType.TinyInt);
                paramFamily.Value = family;

                cmd.Parameters.Add(paramName);
                cmd.Parameters.Add(paramBirth);
                cmd.Parameters.Add(paramEmail);
                cmd.Parameters.Add(paramFamily);

                cmd.CommandText = 
                    "Insert into MemberInfo(Name, Birth, Email, Family) values (@Name, @Birth, @Email, @Family)";
                int affectedCount = cmd.ExecuteNonQuery();

                Console.WriteLine(affectedCount);
                Console.WriteLine();

                //
                cmd.CommandText = "select * from MemberInfo";
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    name = reader.GetString(0);
                    birth = reader.GetDateTime(1);
                    email = reader.GetString(2);
                    family = reader.GetByte(3);

                    Console.WriteLine("{0}, {1}, {2}, {3}", name, birth, email, family);
                }
                reader.Close();
                Console.WriteLine();

                //
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter("Select * from MemberInfo", conn);
                sda.Fill(ds, "MemberInfo");
                ds.WriteXml(Console.Out);
            }
        }
    }
}
