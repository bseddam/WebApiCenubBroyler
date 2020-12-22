using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCenubBroyler.DBControl;
using WebApiCenubBroyler.Models;



namespace WebApiCenubBroyler.Controllers
{
    public class UsersController : ApiController
    {
        //private string[] shehirler = new string[] { "1a","2a","3a"};
        //public string[] Get()
        //{
        //    return shehirler;
        //}
        //public string Get(int id)
        //{
        //    return shehirler[id];
        //}
        DBUsers dbusers = new DBUsers();
        public MobilResult Get()
        {
            MobilResult result = new MobilResult();
            result.Result = true;
            try
            {
                List<Users> userslist = dbusers.GetAllUsers();

                result.Data = userslist;
                result.Result = true;
                result.Message = "Succesfull get users";
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
            }
            return result;
        }
        public MobilResult Get(int id)
        {
            MobilResult result = new MobilResult();
            result.Result = true;
            try
            {
                Users userslist = dbusers.GetUser(id);

                result.Data = userslist;
                result.Result = true;
                result.Message = "Succesfull get users";
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
            }
            return result;
        }



    }
}
