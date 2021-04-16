using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using ContractLayer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MovieManager_TeunBuis
{
    public class UserController : Controller
    {
        UserCollection userCollection = new UserCollection();
        public IActionResult Index(UserModel user)
        {
            if(user == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                return View(user);
            }
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
        [HttpPost]
        public IActionResult Login(UserModel userModel)
        {
            UserModel user = CreateUserModelFromUserBO(userCollection.GetUserByUName(CreateUserDTOFromVModel(userModel)));
            if(userModel.UName == user.UName && userModel.Password == user.Password)
            {
                return RedirectToAction("Index", "User", user);
            }
            else
            {
                ViewBag.LoginError = "Login Data is incorrect";
                return View();
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
            userModel.UName = user.UName;
            userModel.FName = user.LName;
            userModel.Admin = user.Admin;
            userModel.Password = user.Password;
            userModel.Id = user.Id;
            return userModel;
        }
        private void Authentication(UserModel userModel)
        {
            var claims = new List<Claim>();
            if(userModel.Admin == true)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                claims.Add(new Claim(ClaimTypes.Name, userModel.UName));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim(ClaimTypes.Name, userModel.UName));
            }
        }
    }
}
