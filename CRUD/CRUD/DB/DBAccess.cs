using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using CRUD.Models;
using System.Data;

namespace CRUD.DB
{
    public class DBAccess
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString);

        public List<Emp> GetEmp()
        {
            List<Emp> Emps = new List<Emp>();

            SqlCommand cmd = new SqlCommand("GetEmps", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader sdr= cmd.ExecuteReader();
            
            while (sdr.HasRows)
            {
                Emp e = new Emp();
                e.EmpID = Convert.ToInt32( sdr[0].ToString());
                e.Name = sdr[1].ToString();
                e.DOB = Convert.ToDateTime(sdr[2].ToString());
                e.Image = sdr[3].ToString();
                e.Gender = sdr[4].ToString();
                e.State = Convert.ToInt32(sdr[5].ToString());
                e.City = Convert.ToInt32(sdr[6].ToString());
                e.Pin = sdr[7].ToString();
                Emps.Add(e);
            }
            con.Close();

            return Emps;


        }

        public Boolean AddEmp(Emp emp)
        {
            SqlCommand cmd = new SqlCommand("AddEmp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            Boolean Status = false;
            if (i > 0)
            {
                Status = true;
            }
            else
            {
                Status = false;
            }
            return Status;
        }
        public List<State> GetState()
        {
            List<State> li = new List<State>();
            SqlCommand cmd = new SqlCommand("select * from TblState",con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                State st = new State();
                st.StateID = Convert.ToInt32(sdr[0].ToString());
                st.Name = sdr[1].ToString();
                li.Add(st);
            }
            con.Close();
            li.Insert(0,new State { StateID = -1, Name = "Select State" });
            return li;
        }
        
    }
}