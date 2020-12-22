using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiCenubBroyler.Models;


namespace WebApiCenubBroyler.DBControl
{
    public class DBUsers
    {
        public static SqlConnection SqlConn
        {
            get { return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString); }
        }

        public List<Users> GetAllUsers()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(@"select  
 * FROM Users", SqlConn);
                da.Fill(dt);

                List<Users> userlist = new List<Users>();
                userlist = (from DataRow dr in dt.Rows
                            select new Users()
                            {
                                UserID = Convert.ToInt32(dr["UserID"]),
                                Name = dr["Name"].ToString(),
                                Sname = dr["Sname"].ToString(),
                                Phone = dr["Phone"].ToString(),
                                Email = dr["Email"].ToString(),
                                Password = dr["Password"].ToString(),
                                Gender = int.Parse(dr["Gender"].ToString()),
                                Birthday = DateTime.Parse(dr["Birthday"].ToString()),

                            }).ToList();



                return userlist;
            }
            catch (Exception ex)
            {

                //LogInsert(Utils.Tables.v_Managers, Utils.LogType.select,
                //    String.Format("GetManagers()"), ex.Message, "", true);
                //List<Users> userlist = new List<Users>();
                //Users u = new Users();
                //u.Name = ex.Message;
                //userlist.Add(u);
                return null;
            }
        }
        public Users GetUser(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(@"select 
 * FROM Users where UserID="+id, SqlConn);
                da.Fill(dt);

                Users user = new Users{
                                            UserID = Convert.ToInt32(dt.Rows[0]["UserID"].ToString()),
                                            Name = dt.Rows[0]["Name"].ToString(),
                                            Sname = dt.Rows[0]["Sname"].ToString(),
                                            Phone = dt.Rows[0]["Phone"].ToString(),
                                            Email = dt.Rows[0]["Email"].ToString(),
                                            Password = dt.Rows[0]["Password"].ToString(),
                                            Gender = int.Parse(dt.Rows[0]["Gender"].ToString()),
                                            Birthday = DateTime.Parse(dt.Rows[0]["Birthday"].ToString())

                                        };
                return user;
            }
            catch (Exception ex)
            {

                //LogInsert(Utils.Tables.v_Managers, Utils.LogType.select,
                //    String.Format("GetManagers()"), ex.Message, "", true);
                //List<Users> userlist = new List<Users>();
                //Users u = new Users();
                //u.Name = ex.Message;
                //userlist.Add(u);
                return null;
            }
        }
    }
}