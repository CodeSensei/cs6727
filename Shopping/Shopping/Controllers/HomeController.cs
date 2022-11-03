using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Shopping.Models;
using System.Diagnostics;
using RestSharp.Serializers;
using System.Threading;

using RestSharp.Authenticators;
using Microsoft.Extensions.Logging;

using Google.Api.Gax.ResourceNames;
using Google.Cloud.RecaptchaEnterprise.V1;
using Newtonsoft.Json;

using GoogleRecaptchaV3.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System.Net;
using Shopping.Data;
using Microsoft.EntityFrameworkCore;

namespace Shopping.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Shopping.Models.GoogleRecaptchaV3Model _recaptchV3Config;

        private readonly ShoppingContext _context;


        public HomeController(ILogger<HomeController> logger, IOptions<Shopping.Models.GoogleRecaptchaV3Model> recaptchV3Config, ShoppingContext context)
        {
            _logger = logger;
            _recaptchV3Config = recaptchV3Config.Value;
            _context = context;
        }

        //public async Task<IActionResult> PurchaseDemo()
        //{
        //    //if (id == null || _context.Product == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    var product = await _context.Product
        //        .FirstOrDefaultAsync(m => m.ID == 1);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        // GET: Products/Details/5
        public async Task<IActionResult> PurchaseDemo()
        {
            //if (id == null || _context.Product == null)
            //{
            //    return NotFound();
            //}

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ID == 1);
            if (product == null)
            {
                return NotFound();
            }

            var account = await _context.Account
            .FirstOrDefaultAsync(m => m.ID == 1);
            if (account == null)
            {
                return NotFound();
            }

            //return View(product);

            //Creating the View model
            AccountProductViewModel accountProductViewModel = new AccountProductViewModel()
            {
                Account = account,
                Product = product
            };
            //Pass the studentDetailsViewModel to the view
            return View(accountProductViewModel);

        }

        public IActionResult Index()
        {
            //createAssessment();
            return View();
        }

        //public IActionResult Privacy()
        //{

        //    return View();
        //}

        public IActionResult DataDome()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginMe(LoginModel model)
        {
            bool bCaptchValid = IsRecaptchV3Valid(model.CaptchaToken);

            if (bCaptchValid)
            {
                return RedirectToAction("GoogleStatus", "Home");
            }

            return View();
        }

        bool IsRecaptchV3Valid(string captchaResponseToken)
        {
            var reCaptchVerifyUri = $"{_recaptchV3Config.VerifyURL}?secret={_recaptchV3Config.SecretKey}&response={captchaResponseToken}";

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage responseMessage = httpClient.GetAsync(reCaptchVerifyUri).Result;

            string responseInJSON = responseMessage.Content.ReadAsStringAsync().Result;

            Shopping.Models.GoogleRecaptchaV3Response grcV3Response = JsonConvert.DeserializeObject<Shopping.Models.GoogleRecaptchaV3Response>(responseInJSON);

            return grcV3Response!.success;
        }

        public IActionResult Google()
        {
            return View();
        }

        public IActionResult GoogleStatus()
        {
            return View();
        }

        public IActionResult Perimeter()
        {
            return View();
        }

        public IActionResult PurchaseQuantity()
        {
            return View();
        }

        public IActionResult PurchaseAdmin()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}