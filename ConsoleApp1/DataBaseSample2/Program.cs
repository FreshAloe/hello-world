using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace DataBaseSample2
{
    class MemberInfo
    {
        public string Name;
        public DateTime Birth;
        public string Email;
        public byte Family;

        public override string ToString()
        {
            return string.Format("{0} : Birthday {1} : Mail-{2} : Family-{3}", Name, Birth, Email, Family);
        }
    }

    class MemberInfoDAC
    {
        SqlConnection _sqlconn;

        public MemberInfoDAC(SqlConnection sqlconn)
        {
            _sqlconn = sqlconn;
        }

        void FillParameters(SqlCommand cmd, MemberInfo memberInfo)
        {
            SqlParameter paramName = new SqlParameter("Name", SqlDbType.NVarChar, 20);
            paramName.Value = memberInfo.Name;

            SqlParameter paramBirth = new SqlParameter("Birth", SqlDbType.Date);
            paramBirth.Value = memberInfo.Birth;

            SqlParameter paramEmail = new SqlParameter("Email", SqlDbType.NVarChar, 100);
            paramEmail.Value = memberInfo.Email;

            SqlParameter paramFamily = new SqlParameter("Family", SqlDbType.TinyInt);
            paramFamily.Value = memberInfo.Family;

            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramBirth);
            cmd.Parameters.Add(paramEmail);
            cmd.Parameters.Add(paramFamily);
        }

        public void Insert(MemberInfo memberInfo)
        {
            string cmdText = "Insert into MemberInfo(Name, Birth, Email, Family) values (@Name, @Birth, @Email, @Family)";
            SqlCommand cmd = new SqlCommand(cmdText, _sqlconn);
            FillParameters(cmd, memberInfo);
            cmd.ExecuteNonQuery();
        }

        public void Update(MemberInfo memberInfo)
        {
            string cmdText = "Update MemberInfo set Name = @Name, Birth = @Birth, Family = @Family where Email = @Email";
            SqlCommand cmd = new SqlCommand(cmdText, _sqlconn);
            FillParameters(cmd, memberInfo);
            cmd.ExecuteNonQuery();
        }

        public void Delete(MemberInfo memberInfo)
        {
            string cmdText = "Delete from MemberInfo where Email = @Email";
            SqlCommand cmd = new SqlCommand(cmdText, _sqlconn);
            FillParameters(cmd, memberInfo);
            cmd.ExecuteNonQuery();
        }

        public MemberInfo[] SelectAll()
        {
            string cmdText = "Select * from MemberInfo";
            ArrayList arrayList = new ArrayList();

            SqlCommand cmd = new SqlCommand(cmdText, _sqlconn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    MemberInfo memberInfo = new MemberInfo();
                    memberInfo.Name = reader.GetString(0);
                    memberInfo.Birth = reader.GetDateTime(1);
                    memberInfo.Email = reader.GetString(2);
                    memberInfo.Family = reader.GetByte(3);

                    arrayList.Add(memberInfo);
                }
            }

            MemberInfo[] memList = arrayList.ToArray(typeof(MemberInfo)) as MemberInfo[];
            return memList;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
            MemberInfo memberInfo = new MemberInfo();
            memberInfo.Name = "Jennifer";
            memberInfo.Birth = new DateTime(1985, 5, 6);
            memberInfo.Email = "jeenifer@daum.net";
            memberInfo.Family = 0;

            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                MemberInfoDAC dac = new MemberInfoDAC(sqlcon);

                dac.Insert(memberInfo);
                memberInfo.Name = "Jenny";
                dac.Update(memberInfo);

                MemberInfo[] memlist = dac.SelectAll();
                foreach(MemberInfo item in memlist)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
