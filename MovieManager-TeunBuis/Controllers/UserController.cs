using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using ContractLayer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace MovieManager_TeunBuis
{
    public class UserController : Controller
    {
        UserCollection userCollection = new UserCollection();
        public IActionResult Index(string userName)
        {
            if(userName == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                UserModel userModel = CreateUserModelFromUserBO(userCollection.GetUserByUName(userName));
                return View(userModel);
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
        public IActionResult EditUser(int Id)
        {
            UserModel userModel = CreateUserModelFromUserBO(userCollection.GetUser(Id));
            return View(userModel);
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
            UserModel user = CreateUserModelFromUserBO(userCollection.GetUserByUName(userModel.UName));
            if(userModel.UName == user.UName && userModel.Password == user.Password)
            {
                UserAuthentication(user);
                return RedirectToAction("Index", "User", new { userName = user.UName });
            }
            else
            {
                ViewBag.LoginError = "Login Data is incorrect";
                return View();
            }        
        }
        [HttpPost]
        public IActionResult EditUser(UserModel userModel)
        {
            User user = new User(CreateUserDTOFromVModel(userModel));
            user.UpdateUser(CreateUserDTOFromVModel(userModel));
            UserModel userModelEdited = CreateUserModelFromUserBO(user);
            return View(userModelEdited);
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
        private void UserAuthentication(UserModel userModel)
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
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authPorperties = new AuthenticationProperties();
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authPorperties);
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
