using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Q2.Data;
using Q2.Model;

namespace Q2.Pages.student
{
    public class IndexModel : PageModel
    {
        private readonly Q2.Data.Q2Context _context;

        public IndexModel(Q2.Data.Q2Context context)
        {
            _context = context;
        }

        public IList<Student> Students { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Students = await _context.Student
                .Include(x=>x.course)
                .ToListAsync();
        }
    }
}