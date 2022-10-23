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

namespace Shopping.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Shopping.Models.GoogleRecaptchaV3Model _recaptchV3Config;

        public HomeController(ILogger<HomeController> logger, IOptions<Shopping.Models.GoogleRecaptchaV3Model> recaptchV3Config)
        {
            _logger = logger;

            _recaptchV3Config = recaptchV3Config.Value;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}