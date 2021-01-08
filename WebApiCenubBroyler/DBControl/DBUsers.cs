using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
                SqlDataAdapter da = new SqlDataAdapter(@"select * FROM Users", SqlConn);
                da.Fill(dt);

                List<Users> userlist = new List<Users>();
                userlist = (from DataRow dr in dt.Rows
                            select new Users()
                            {
                                UserID = Convert.ToInt32(dr["UserID"]),
                                Name = ConvertTypes.ToParseStr(dr["Name"]),
                                Sname = ConvertTypes.ToParseStr(dr["Sname"]),
                                Phone = ConvertTypes.ToParseStr(dr["Phone"]),
                                Email = ConvertTypes.ToParseStr(dr["Email"]),
                                Password = ConvertTypes.ToParseStr(dr["Password"]),
                                Gender = ConvertTypes.ToParseIntNull(dr["Gender"]),
                                Birthday = ConvertTypes.ConvertToDateTime
                                (ConvertTypes.ToParseStr(dr["Birthday"])),

                            }).ToList();

                da.Dispose();
              

                return userlist;
            }
            catch (Exception)
            {

                //LogInsert(Utils.Tables.v_Managers, Utils.LogType.select,
                //    String.Format("GetManagers()"), ex.Message, "", true);
                //List<Users> userlist = new List<Users>();
                //Users u = new Users();
                //u.Name = ex.Message;
                //userlist.Add(u);
                return null;
            }
            finally
            {
              
                SqlConn.Close();
                SqlConn.Dispose();
            }
        }
        public Users GetUser(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(@"select 
 * FROM Users where UserID=@UserID", SqlConn);
                da.SelectCommand.Parameters.AddWithValue("UserID", id);

                da.Fill(dt);

                Users user = new Users
                {
                    UserID = Convert.ToInt32(dt.Rows[0]["UserID"]),
                    Name = ConvertTypes.ToParseStr(dt.Rows[0]["Name"]),
                    Sname = ConvertTypes.ToParseStr(dt.Rows[0]["Sname"]),
                    Phone = ConvertTypes.ToParseStr(dt.Rows[0]["Phone"]),
                    Email = ConvertTypes.ToParseStr(dt.Rows[0]["Email"]),
                    Password = ConvertTypes.ToParseStr(dt.Rows[0]["Password"]),
                    Gender = ConvertTypes.ToParseIntNull(dt.Rows[0]["Gender"]),
                    Birthday = ConvertTypes.ConvertToDateTime
                                (ConvertTypes.ToParseStr(dt.Rows[0]["Birthday"]))

                };
                da.Dispose();
                return user;
            }
            catch (Exception)
            {

                //LogInsert(Utils.Tables.v_Managers, Utils.LogType.select,
                //    String.Format("GetManagers()"), ex.Message, "", true);
                //List<Users> userlist = new List<Users>();
                //Users u = new Users();
                //u.Name = ex.Message;
                //userlist.Add(u);
                return null;
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
        }
       
        public void AddUser(Users user)
        {
        
        SqlCommand cmd = new SqlCommand(@"insert into  Users  
                                              ( Name , Sname , Phone , Email , Password , Gender  )
                                         VALUES
			( @Name , @Sname , @Phone , @Email , @Password , @Gender )", SqlConn);
           
            cmd.Parameters.AddWithValue("@Name", ConvertTypes.DbNullObj(user.Name));
            cmd.Parameters.AddWithValue("@Sname", ConvertTypes.DbNullObj(user.Sname));
            cmd.Parameters.AddWithValue("@Phone", ConvertTypes.DbNullObj(user.Phone));
            cmd.Parameters.AddWithValue("@Email", ConvertTypes.DbNullObj(user.Email));
            cmd.Parameters.AddWithValue("@Password", ConvertTypes.DbNullObj(user.Password));
            cmd.Parameters.AddWithValue("@Gender", ConvertTypes.DbNullObj(user.Gender));

            try
            {

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                //return user;

            }
            catch (Exception )
            {
                //LogInsert(Utils.Tables.v_Managers, Utils.LogType.select,
                //    String.Format("GetManagers()"), ex.Message, "", true);
                //List<Users> userlist = new List<Users>();
                //Users u = new Users();
                //u.Name = ex.Message;
                //userlist.Add(u);
                //return null;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
                SqlConn.Close();
                SqlConn.Dispose();
            }
        }

        public void UpdateUser(Users user)
        {

            SqlCommand cmd = new SqlCommand(@"update Users set Name=@Name, Sname=@Sname, Phone=@Phone, 
Email=@Email , Password=@Password , Gender=@Gender where UserID=" + user.UserID, SqlConn);

            cmd.Parameters.AddWithValue("@Name", ConvertTypes.DbNullObj(user.Name));
            cmd.Parameters.AddWithValue("@Sname", ConvertTypes.DbNullObj(user.Sname));
            cmd.Parameters.AddWithValue("@Phone", ConvertTypes.DbNullObj(user.Phone));
            cmd.Parameters.AddWithValue("@Email", ConvertTypes.DbNullObj(user.Email));
            cmd.Parameters.AddWithValue("@Password", ConvertTypes.DbNullObj(user.Password));
            cmd.Parameters.AddWithValue("@Gender", ConvertTypes.DbNullObj(user.Gender));

            try
            {

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                //return user;

            }
            catch (Exception)
            {
                //LogInsert(Utils.Tables.v_Managers, Utils.LogType.select,
                //    String.Format("GetManagers()"), ex.Message, "", true);
                //List<Users> userlist = new List<Users>();
                //Users u = new Users();
                //u.Name = ex.Message;
                //userlist.Add(u);
                //return null;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
                SqlConn.Close();
                SqlConn.Dispose();
            }


        }


        public void DeleteUser(string userid)
        {
            SqlCommand cmd = new SqlCommand(@"Delete from Users where UserID="+ userid, SqlConn);
            try
            {

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();


            }
            catch (Exception)
            {
                //LogInsert(Utils.Tables.v_Managers, Utils.LogType.select,
                //    String.Format("GetManagers()"), ex.Message, "", true);
                //List<Users> userlist = new List<Users>();
                //Users u = new Users();
                //u.Name = ex.Message;
                //userlist.Add(u);
                //return null;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
                SqlConn.Close();
                SqlConn.Dispose();
            }
        }

    }
}