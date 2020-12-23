using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApiCenubBroyler.DBControl;
using WebApiCenubBroyler.Models;



namespace WebApiCenubBroyler.Controllers
{
    public class UsersController : ApiController
    {
        
        DBUsers dbusers = new DBUsers();
        //select all
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
        //Select 1 row
        public MobilResult Get(int id)
        {
            MobilResult result = new MobilResult();
            result.Result = true;
            try
            {
                Users userslist = dbusers.GetUser(id);

                result.Data = userslist;
                result.Result = true;
                result.Message = "Succesfull get user";
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
            }
            return result;
        }

        //Insert
        public MobilResult Post(Users user)
        {
            MobilResult result = new MobilResult();
            result.Result = true;

            try
            {
                Users us = dbusers.AddUser(user);

                result.Data = us;
                result.Result = true;
                result.Message = "Succesfull inserted user";
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
            }
            return result;
             
        }
        //Update
        public MobilResult Put(int id, Users user)
        {
            MobilResult result = new MobilResult();
            result.Result = true;

            try
            {
                Users us = dbusers.UpdateUser(id,user);

                result.Data = us;
                result.Result = true;
                result.Message = "Succesfull updated user";
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
            }
            return result;
        }
        //Delete
        public MobilResult Delete(int id)
        {
            MobilResult result = new MobilResult();
            result.Result = true;

            try
            {
                List<Users> us = dbusers.DeleteUser(id);

                result.Data = us;
                result.Result = true;
                result.Message = "Succesfull deleted user";
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
