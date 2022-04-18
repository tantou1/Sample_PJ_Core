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
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(Tantousha tan)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        _context.Add(tan);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(tan);
        //}
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind] Tantousha tantousha)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.CreateTantousha(tantousha);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }

        public ActionResult Edit(string id)
        {
            return View(_context.GetAllTantousha().Find(Tantousha => Tantousha.cTANTOUSHA == id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Tantousha tantousha)
        {
            try
            {
                _context.EditTantousha(tantousha);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }//chanlayedit

        [HttpGet]        public IActionResult Delete(string id)        {            return View(_context.GetAllTantousha().Find(Tantousha => Tantousha.cTANTOUSHA == id));        }        [HttpPost, ActionName("Delete")]        [ValidateAntiForgeryToken]        public IActionResult Delete(string id, Tantousha tantousha)        {            try            {                _context.DeleteTantousha(id);                ViewBag.AlertMsg = "Deleted Successfully";                return RedirectToAction("Index");            }            catch            {                return View();            }        }
    }
}
