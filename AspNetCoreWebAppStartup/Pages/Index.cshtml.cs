using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAppStartup.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly SingletonClass _singletonClass;

        public IndexModel(ILogger<IndexModel> logger, SingletonClass singletonClass)
        {
            _logger = logger;
            _singletonClass = singletonClass;
        }

        public void OnGet()
        {
            StaticClass.MethodTwo();
        }
    }
}
