﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApiCenubBroyler.DBControl;
using WebApiCenubBroyler.Models;



namespace WebApiCenubBroyler.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        
        DBUsers dbusers = new DBUsers();
        //select all
        [Route("getallusers")]
        [HttpGet]
        public MobileResult AllUsers()
        {
            MobileResult result = new MobileResult();
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
        [HttpGet]
        [Route("getuser/{id}")]
        public MobileResult Get(int id)
        {
            MobileResult result = new MobileResult();
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
        [HttpPost]
        [Route("insert")]
        public MobileResult Post(Users user)
        {
            MobileResult result = new MobileResult();
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
        [HttpPost]
        [Route("update")]
        public MobileResult Put(Users user)
        {
            MobileResult result = new MobileResult();
            result.Result = true;

            try
            {
                Users us = dbusers.UpdateUser(user);

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
        [HttpPost]
        [Route("delete")]
        public MobileResult Delete(Users user)
        {
            MobileResult result = new MobileResult();
            result.Result = true;

            try
            {
                Users us = dbusers.DeleteUser(user);

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
