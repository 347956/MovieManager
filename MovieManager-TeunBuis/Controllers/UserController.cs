using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using ContractLayer;
using Microsoft.AspNetCore.Authorization;

namespace MovieManager_TeunBuis
{
    public class UserController : Controller
    {
        UserCollection userCollection = new UserCollection();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult AllUsers()
        {
            List<UserModel> allusers = new List<UserModel>();
            foreach(User user in userCollection.GetAllUser())
            {
                UserModel userModel = CreateUserModelFromUserBO(user);
                allusers.Add(userModel);
            }
            return View(allusers);
        }
        [HttpPost]
        public IActionResult Register(UserModel userModel)
        {
            if(userCollection.CreateUser(CreateUserDTOFromVModel(userModel)) == false)
            {
                ViewBag.ErrorMessage = "This user name has already been taken";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }
        //Creates a UserDTO from A UserModel
        private UserDTO CreateUserDTOFromVModel(UserModel userModel)
        {
            UserDTO userDTO = new UserDTO();
            userDTO.UName = userModel.UName;
            userDTO.FName = userModel.FName;
            userDTO.LName = userModel.LName;
            userDTO.Admin = userModel.Admin;
            userDTO.Password = userModel.Password;
            userDTO.Id = userModel.Id;
            return userDTO;
        }
        private UserModel CreateUserModelFromUserBO(User user)
        {
            UserModel userModel = new UserModel();
            userModel.UName = userModel.UName;
            userModel.FName = userModel.FName;
            userModel.LName = userModel.LName;
            userModel.Admin = userModel.Admin;
            userModel.Password = userModel.Password;
            userModel.Id = userModel.Id;
            return userModel;
        }
    }
}
