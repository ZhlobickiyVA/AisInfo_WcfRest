using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Configuration;

namespace AisInfo_Rest.Model
{
    [DataContract]
    public class Dou
    {
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string BrDate { get; set; }
        [DataMember]
        public string NumDou { get; set; }
        [DataMember]
        public string Razmer { get; set; }

    }
    
    



    public class ModelDou
    {
        public List<Dou> item { get; set; }

        public ModelDou(string LastName = "", string FirstName = "", string BrDate = "", string MiddleName = "", string idDou = "")
        {
            item = new List<Dou>();
            GetList(LastName,FirstName,MiddleName,BrDate, idDou);
        }

        public void GetList(string LastName="%",string FirstName="%",string MiddleName="%",string BrDate="%",string idDou="%")
        {
            string SQL = 
                string.Format(
                "SELECT TOP 10 [FMR],[IMR],[OTR],CONVERT(date, [DTR] ,104 ) as DTRda,[NUMDOU],[RAZML] FROM [mfc_out].[dbo].[dou_lg] "+
                "Where FMR Like '{0}%' and IMR Like '{1}%' and OTR Like '{2}%' and NUMDOU like '{3}%'",
                LastName,FirstName,MiddleName,idDou
                
                
                );
            string Connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(Connection))
            {
                connect.Open();
                SqlCommand command = new SqlCommand(SQL, connect);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Dou it = new Dou();
                        //[FMR],[IMR],[OTR],[DTR],[NUMDOU],[RAZML]
                        it.LastName = reader["FMR"].ToString();
                        it.FirstName = reader["IMR"].ToString();
                        it.MiddleName = reader["OTR"].ToString();
                        it.BrDate = ((DateTime)reader["DTRda"]).ToShortDateString();
                        it.NumDou = reader["NUMDOU"].ToString();
                        it.Razmer = reader["RAZML"].ToString();
                        item.Add(it);
                    }

                }
            }
        }



        public static List<string> ListDouNumber()
        {
            List<string> list = new List<string>();
            string SQL = "select isnull(case when Cast(numdou as int)<10 then '0'+numdou else numdou end,'Нет') as Name from [mfc_out].[dbo].[dou_lg]  group by numdou  order by Name";

            string Connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(Connection))
            {
                connect.Open();
                SqlCommand command = new SqlCommand(SQL, connect);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(reader["Name"].ToString());
                    }

                }
            }

            return list;
        }


    }
}