using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Conecta.Controllers
{
    public class LanguageController : Controller
    {
        //Set Language
        private string _currentLanguage = "es";
        private string _returnUrl = "";

        private string CurrentLanguage
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentLanguage))
                    return _currentLanguage;

                if (string.IsNullOrEmpty(_currentLanguage))
                {
                    var feature = HttpContext.Features.Get<IRequestCultureFeature>();
                    _currentLanguage = feature.RequestCulture.Culture.TwoLetterISOLanguageName.ToLower();
                }

                return _currentLanguage;
            }
        }

        public void SetLanguage(string culture, string returnUrl)
        {
            _currentLanguage = culture;
            _returnUrl = returnUrl;
            RedirectToDefaultLanguage();
        }
        
        public ActionResult RedirectToDefaultLanguage()
        {
            var culture = CurrentLanguage;
            var returnUrl = _returnUrl;
            if (culture != "es")
                culture = "es";
            if (returnUrl == "")
            {
                returnUrl = "Index";
            }

            Response.Cookies.Append(
               CookieRequestCultureProvider.DefaultCookieName,
               CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
               new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
           );
            return RedirectToAction(returnUrl, new { culture });
        }
    }
}