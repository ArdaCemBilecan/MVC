using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IdentityOlaylari.Models;
using Microsoft.AspNetCore.Identity;
using IdentityOlaylari.Identity;
using System.Net.Mail;
using System.Net;

namespace IdentityOlaylari.Controllers
{
    public class HomeController : Controller
    {
        UserManager<AppIdentityUser> _userManager;
        SignInManager<AppIdentityUser> _signInManager;

        public HomeController(UserManager<AppIdentityUser>UserManager, SignInManager<AppIdentityUser>SignInManager)
        {
            _userManager = UserManager;
            _signInManager = SignInManager;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View (model);
            }
            var user = await _userManager.FindByNameAsync(model.UserName);

            if(user !=null)
            {
                if(!await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(String.Empty, "Confirm your E-Mail");
                    return View(model);
                }

            }

            var result = await _signInManager.PasswordSignInAsync(model.UserName,model.Password,false,false);
            // Beni hatırla false , Belli bir lock koduk bir de

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(String.Empty, "Login Failed");
            return View(model);

        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new AppIdentityUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user,model.Password);

            if (result.Succeeded)
            {
                // Her şey doğru ise kullanıcıya E Mail doğrulaması gönderiyoruz

                // Code ile gidecek kodu oluşturuoruz
                var confirmationCode = _userManager.GenerateEmailConfirmationTokenAsync(user);
                // Giden koda tıklayan kişinin url aksiyonlarını yazıyoruz
                var callBackUrl = Url.Action("ConfirmEmail","Home",new { userId=user.Id,code = confirmationCode.Result}); // Confirm email aksiyonuna gidecek bunlar

                // Send E Mail
                var email = user.Email;
                SendMail(email, callBackUrl);

                return RedirectToAction("Login");
            }
            return View(model);
        }



        public async Task<IActionResult> ConfirmEmail(string userId , string code)
        {
            if(userId== null || code == null)
            {
                ModelState.AddModelError(String.Empty, "Code could not send");
                return RedirectToAction("Login");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if(user== null)
            {
                throw new ApplicationException("Unable to find user");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return View("ConfirmEmail");
            }

            return RedirectToAction("Login");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                return View();
            }

            var user = await _userManager.FindByEmailAsync(Email);
            if(user == null)
            {
                return View();
            }

            var confirmationCode = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callBackUrl = Url.Action("ResetPassword", "Home", new{ userId = user.Id, code = confirmationCode });
            // ResetPassword aksiyonuna göndereceğiz

            // Send Call Back URL with 
            var email = user.Email;

            SendMail(email, callBackUrl);

            return RedirectToAction("ForgotPasswordEmailSend");
        
        }



        public IActionResult ForgotPasswordEmailSend()
        {
            return View();
        }
         


        public IActionResult ResetPassword(string userId , string code)
        {
            if(userId == null || code == null)
            {
                throw new ApplicationException("Code can not find");
            }

            var model =new ResetPasswordViewModel{Code=code };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(resetViewModel);
            }

            var user = await _userManager.FindByEmailAsync(resetViewModel.Email);
            if(user == null)
            {
                throw new ApplicationException("User not found");
            }

            var result = await _userManager.ResetPasswordAsync(user, resetViewModel.Code, resetViewModel.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirm");
            }

            return View();

        }


        public IActionResult ResetPasswordConfirm()
        {
            return View();
        }


        public void SendMail(string email, string code)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress("ardadeneme99@gmail.com");
            mail.Subject = "Kullanıcı Onaylama Formu";
            mail.Body = "Sayın kullanıcı, gelen mesajınızın içeriği aşağıdaki gibidir. <br>" + code;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("ardadeneme99@gmail.com", "ardacem99");
            smtp.Send(mail);
        }

    }

}
