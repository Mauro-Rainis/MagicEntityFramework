using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPageEntityFrameworkMvc.Data;

namespace WebPageEntityFrameworkMvc.Controllers
{
    public class StudentiController : Controller
    {
        private readonly MagicContext _context;

        public StudentiController(MagicContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Studenti.Include(s => s.SportPraticato));
        }
    }
}