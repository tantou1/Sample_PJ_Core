using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample_PJ_Core.Models.Context;
using Sample_PJ_Core.Models.Editdata;

namespace Sample_PJ_Core.Controllers
{
    public class TantoushaController : Controller
    {
        private readonly Context _context;
        public TantoushaController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //_context.GetAllTantousha();
            //return View();

            Context context = HttpContext.RequestServices.GetService(typeof(Sample_PJ_Core.Models.Context.Context)) as Context;

            var list_tan = context.GetAllTantousha();

            return View(list_tan);
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    var cnt = new Context();
        //    return View(cnt);
        //}

    }
}