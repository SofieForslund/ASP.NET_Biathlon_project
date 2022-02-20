using Microsoft.Extensions.Logging;
﻿using BiathlonSuccess.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiathlonSuccess.Repositories;
using BiathlonSuccess.Models;

namespace BiathlonSuccess.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IAimtrackerRepo _aimtrackerRepo;
        private readonly IDbRepository _dbRepository;

        public AccountController(UserManager<ApplicationUser> userManager, 
                                SignInManager<ApplicationUser> signInManager,
                                ILogger<AccountController> logger, 
                                IAimtrackerRepo aimtrackerRepo, 
                                IDbRepository dbRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _aimtrackerRepo = aimtrackerRepo;
            _dbRepository = dbRepository;
        }

        #region RemoteValidation
        [HttpPost]
        public JsonResult IbuIdTaken(string ChosenAthleteIbuID, RegisterViewModel model)
        {
            var chosenAthlete = _dbRepository.GetShooter(model.ChosenAthleteIbuID); 
            if (chosenAthlete == null)
            {
                return Json(false);

            }
            else
            {
                return Json(!_dbRepository.IsIfIdTaken(chosenAthlete.IbuId));
            }
        }

        #endregion
        
        #region Register
        public async Task<IActionResult> Register()
        {
            var athletes = await _aimtrackerRepo.GetAthletes(); //när vi kommer till denna sida vet vi redan vilka athletes som finns i DB. OK
            var savedAthletes = await _dbRepository.AddAthletesAsync(athletes);
            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {

                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    IbuID = model.ChosenAthleteIbuID
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("dashboard", "home", new { id = user.IbuID }); // Om det gick så renderas index sidan. 
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                ModelState.AddModelError(string.Empty, "Registrering har misslyckats");

            }
            model = new RegisterViewModel();
            return View(model);
        }
        #endregion

        #region Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email, 
                };

                var result = await _signInManager.PasswordSignInAsync(model.Email,
                           model.Password, isPersistent: false, lockoutOnFailure: false);


                if (result.Succeeded)
                {
                    var userFromDb = _dbRepository.GetUser(user.Email);
                     return RedirectToAction("dashboard", "home", new { id = userFromDb.IbuID });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Inloggningen misslyckades");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        #endregion



        #region Logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("login", "account");
        }
        #endregion

        #region Password Reset

        /// <summary>
        /// Vy för ForgotPassword
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        /// <summary>
        /// Letar efter användare i databasen mha email och skapar sedan en token för användaren och genererar en url får återställning av lösenord. 
        /// Denna url läggs in vymodellen och användaren skickas sedan till ForgotPasswordConfirmation. 
        /// </summary>
        /// <param name="model">Vymodell</param>
        /// <returns>Redirect to ForgotPasswordConfirmation</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user); // Genererar en token
            var url = Url.Action(nameof(ResetPassword), "Account", new { token, email = user.Email }, Request.Scheme); // Skapar en länk till ResetPassword sidan
            model.Link = url;

            return RedirectToAction("ForgotPasswordConfirmation", "account", model);
        }

        /// <summary>
        /// Visar vyn ForgotPasswordConfirmation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ForgotPasswordConfirmation(ForgotPasswordViewModel model)
        {
            return View(model);
        }

        /// <summary>
        /// Vy för ResetPassword, hämtar in token och password från Resetpassword vyn och skickar sedan in dessa till ResetPasswordViewModel
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="email">email</param>
        /// <returns>View</returns>
        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordViewModel { Token = token, Email = email };
            return View(model);
        }

        /// <summary>
        /// Nollställer lösenord mha email om token och lösenord stämmer. 
        /// </summary>
        /// <param name="model">Vymodell</param>
        /// <returns>Redirect to ResetPasswordConfirmation </returns>
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                RedirectToAction(nameof(ResetPasswordConfirmation));
            }

            var resetPassResult = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View();
            }
            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }

        /// <summary>
        /// Vy för ResetPasswordConfirmation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        #endregion
    }
}
