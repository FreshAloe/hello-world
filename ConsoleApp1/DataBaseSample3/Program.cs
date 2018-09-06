using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace DataBaseSample3
{
    class MemberInfoDAC
    {
        SqlConnection _sqlconn;
        DataTable _table;

        public MemberInfoDAC(SqlConnection sqlconn)
        {
            _sqlconn = sqlconn;
            _table = new DataTable("MemberInfo");
            DataColumn colName = new DataColumn("Name", typeof(string));
            DataColumn colBirth = new DataColumn("Birth", typeof(DateTime));
            DataColumn colEmail = new DataColumn("Email", typeof(string));
            DataColumn colFamily = new DataColumn("Family", typeof(byte));

            _table.Columns.Add(colName);
            _table.Columns.Add(colBirth);
            _table.Columns.Add(colEmail);
            _table.Columns.Add(colFamily);
        }

        public DataRow NewRow()
        {
            return _table.NewRow();
        }

        void FillParameters(SqlCommand cmd, DataRow row)
        {
            SqlParameter paramName = new SqlParameter("Name", SqlDbType.NVarChar, 20);
            paramName.Value = row["Name"];

            SqlParameter paramBirth = new SqlParameter("Birth", SqlDbType.Date);
            paramBirth.Value = row["Birth"];

            SqlParameter paramEmail = new SqlParameter("Email", SqlDbType.NVarChar, 100);
            paramEmail.Value = row["Email"];

            SqlParameter paramFamily = new SqlParameter("Family", SqlDbType.TinyInt);
            paramFamily.Value = row["Family"];

            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramBirth);
            cmd.Parameters.Add(paramEmail);
            cmd.Parameters.Add(paramFamily);
        }

        public void Insert(DataRow row)
        {
            string cmdText = "Insert into MemberInfo(Name, Birth, Email, Family) values (@Name, @Birth, @Email, @Family)";
            SqlCommand cmd = new SqlCommand(cmdText, _sqlconn);
            FillParameters(cmd, row);
            cmd.ExecuteNonQuery();
        }

        public void Update(DataRow row)
        {
            string cmdText = "Update MemberInfo set Name = @Name, Birth = @Birth, Family = @Family where Email = @Email";
            SqlCommand cmd = new SqlCommand(cmdText, _sqlconn);
            FillParameters(cmd, row);
            cmd.ExecuteNonQuery();
        }

        public void Delete(DataRow row)
        {
            string cmdText = "Delete from MemberInfo where Email = @Email";
            SqlCommand cmd = new SqlCommand(cmdText, _sqlconn);
            FillParameters(cmd, row);
            cmd.ExecuteNonQuery();
        }

        public DataSet SelectAll()
        {
            string cmdText = "Select * from MemberInfo";
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmdText, _sqlconn);
            sda.Fill(ds, "MemberInfo");

            return ds;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                MemberInfoDAC dac = new MemberInfoDAC(sqlcon);

                DataRow row = dac.NewRow();
                row["Name"] = "captine";
                row["Birth"] = new DateTime(1970, 1, 27);
                row["Email"] = "captine@daum.net";
                row["Family"] = 0;

                //dac.Insert(row);
                row["Name"] = "cap";
                dac.Update(row);

                DataSet ds = dac.SelectAll();
                foreach (DataRow item in ds.Tables["MemberInfo"].Rows)
                {
                    Console.WriteLine(item["name"]);
                }
            }
        }
    }
}
