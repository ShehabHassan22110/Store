using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Helper;
using Store.BL.ViewModels;
using Store.DAL.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser>_UserManager, SignInManager<ApplicationUser>_SignInManager)
        {
            userManager = _UserManager;
            signInManager = _SignInManager;
        }
        #region Registration
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM model)
        {
            try
            {

                if(ModelState.IsValid)
                {
                    var user = new ApplicationUser()
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        IsAgree = model.IsAgree
                    };
                    var result = await userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }

                }
                return View(model);

            }

            catch(Exception)
            {
                return View(model);

            }
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    var user = await userManager.FindByEmailAsync(model.Email);

                    var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid UserName or Password");
                    }

                }

                return View(model);

            }
            catch (Exception)
            {
                return View(model);
            }



        }
        #endregion

        #region LogOut (Sign Out)

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }


        #endregion
        #region Forget Password

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM model)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    // Get User By Email
                    var user = await userManager.FindByEmailAsync(model.Email);

                    if (user != null)
                    {

                        // Generate Token
                        var token = await userManager.GeneratePasswordResetTokenAsync(user);

                        // Generate Reset Link
                        var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);

                        MailSender.SendMail(new MailVM() { Mail = model.Email, Title = "Reset Password - Route Academy", Message = passwordResetLink });

                        return RedirectToAction("Login");
                    }

                }

                return View(model);

            }
            catch (Exception)
            {
                return View(model);
            }

        }

        [HttpGet]
        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }



        #endregion

        #region ResetPassword
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }
        #endregion

    }
}
