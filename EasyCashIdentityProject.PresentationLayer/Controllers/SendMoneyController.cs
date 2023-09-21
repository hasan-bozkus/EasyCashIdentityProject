﻿using EasyCashIdentityProject.BusinnesLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayerx.Concrete;
using EasyCashIdentityProject.DtoLayer.Dtos.CustomerAccountProcessDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
        }

        [HttpGet]
        public IActionResult Index(string mycurrency)
        {
            ViewBag.currency = mycurrency;
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcessDto)
        {
            Context context = new Context();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiveAccountNumberID = context.customerAccounts.Where(x => x.CustomerAccountNumber == sendMoneyForCustomerAccountProcessDto.ReceiveAccountNumber).Select(y => y.CustomerAccountID).FirstOrDefault();
            var senderAccountNumberID = context.customerAccounts.Where(x => x.AppUserID == user.Id).Where(y => y.CustomerAccountCurrency == "Türk Lirası").Select(z => z.CustomerAccountID).FirstOrDefault();

            var values = new CustomerAccountProcess();
            values.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            values.SenderID = senderAccountNumberID;
            values.ProcessType = "Havale";
            values.Amount = sendMoneyForCustomerAccountProcessDto.Amount;
            values.ReceiverID = receiveAccountNumberID;
            values.Description = sendMoneyForCustomerAccountProcessDto.Description;

            _customerAccountProcessService.TInsert(values);

            return RedirectToAction("Index", "deneme");
        }

        
    }
}
