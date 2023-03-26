using ClinicaDentariaFinalWork.Data;
using ClinicaDentariaFinalWork.Models;
using ClinicaDentariaFinalWork.Models.PositionViewModels;
using ClinicaDentariaFinalWork.Models.ProfessionalsViewModels;
using ClinicaDentariaFinalWork.Models.SpecialtyViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicaDentariaFinalWork.Controllers
{
    public class ProfessionalTeamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfessionalTeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProfessionalTeams
        public async Task<IActionResult> Index()
        {
              return _context.ProfessionalTeams != null ? 
                          View(await _context.ProfessionalTeams.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ProfessionalTeams'  is null.");
        }

          

        // GET: ProfessionalTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProfessionalTeams == null)
            {
                return NotFound();
            }

            var professionalTeam = await _context.ProfessionalTeams
                .FirstOrDefaultAsync(m => m.ID == id);
            if (professionalTeam == null)
            {
                return NotFound();
            }

            return View(professionalTeam);
        }

        //GETs CASCADING

        public JsonResult GetPositions()
        {
            var positions = _context.Positions.OrderBy(x => x.Name).ToList();
            return new JsonResult(positions);
        }
        public JsonResult GetSpecialties(int id)
        {
            var specialties = _context.Specialties.Where(x => x.Position.ID == id).OrderBy(x => x.Name).ToList();
            return new JsonResult(specialties);
        }

        // GET: ProfessionalTeams/Create
        public IActionResult Create()
        {
            //ViewBag.SelectedPositionID = new SelectList(new SelectedPosition().PositionList(),
            //                            "PositionID",
            //                            "NamePosition");
            //ViewBag.SelectedPositionID = new List<SelectListItem>
            //{
            //         new SelectListItem { Value = "", Text = "Selecione", Selected=true},
            //        new SelectListItem { Value = "1", Text = "Assistente"},
            //        new SelectListItem { Value = "2", Text = "Médico"},
            //        new SelectListItem { Value = "3", Text = "Recepcionista"}
            //};


            ViewData["PositionIDs"] = new MultiSelectList(_context.Positions, "ID", "Name");
            ViewData["SpecialtyIDs"] = new MultiSelectList(_context.Specialties, "ID", "Name");
            return View();
        }

        // POST: ProfessionalTeams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,Name,Birthday,Address,Locality,ZipCode,TaxPayerNumber,Position,Specialty")] ProfessionalTeam professionalTeam)
        public async Task<IActionResult> Create([Bind("ID,Name,Birthday,Address,Locality,ZipCode,TaxPayerNumber,Position,Specialty, PositionID,SpecialtyID,PositionIDs,SpecialtyIDs")] ProfessionalViewModel professionalViewModel)
        {
            if (ModelState.IsValid)
            {
                

                //foreach (var select in professionalViewModel.SPositions)

                //{
                //    if (select.Selected == true)
                //    {
                //        SelectedPosition equipa = teamsPosition.Find(select.ID);
                //        if (select != null)
                //        {
                //            teams.Add(equipa);
                //        }


                //            //if (selectPosition.Equals("Assistente"))
                //            //{
                //            //    teams = (string)selectPosition;
                //            //}
                //            //if (selectPosition.Equals("Médico"))
                //            //{
                //            //    teams = (string)selectPosition;
                //            //}
                //            //if (selectPosition.Equals("Recepcionista"))
                //            //{
                //            //    teams = (string)selectPosition;
                //            //}
                //        }

                //}

                List<Position> positions = new List<Position>();
                List<Specialty> specialties = new List<Specialty>();

                //if (professionalViewModel.PositionID >= 0)
                //{
                //    //for (int i = 0; i <1; i++)
                //    //{
                //    //    professionalViewModel.PositionIDs[i] = professionalViewModel.PositionID;
                        for (int j = 0; j < professionalViewModel.PositionID; j++)
                        {
                            int positionID = professionalViewModel.PositionID;
                            Position? position = _context.Positions.Find(positionID);
                            if (position != null)
                            {
                                positions.Add(position);
                            }
                        }

                    //}

               // }
                //if (professionalViewModel.SpecialtyID >= 0)
                //{

                    //for (int i = 0; i < 1; i++)
                    //{
                    //    professionalViewModel.SpecialtyIDs[i] = professionalViewModel.SpecialtyID;
                        for (int j = 0; j < professionalViewModel.SpecialtyID; j++)
                        {
                            int specialtyID = professionalViewModel.SpecialtyID;
                            Specialty? specialty = _context.Specialties.Find(specialtyID);
                            if (specialty != null)
                            {
                                specialties.Add(specialty);
                            }
                        }
                    //}
                //}





                ProfessionalTeam team = new ProfessionalTeam
                {
                    Name = professionalViewModel.Name,
                    Birthday = professionalViewModel.Birthday,
                    Address = professionalViewModel.Address,
                    Locality = professionalViewModel.Locality,
                    ZipCode = professionalViewModel.ZipCode,
                    TaxPayerNumber = professionalViewModel.TaxPayerNumber,
                    PositionSelect = positions,
                    SpecialtiesSelect = specialties

                };


                _context.Add(team);
                await _context.SaveChangesAsync();



                return RedirectToAction(nameof(Index));
            }
            //ViewBag.SelectedPositionID = new List<SelectListItem>
            //{
            //         new SelectListItem { Value = "", Text = "Selecione", Selected=true},
            //        new SelectListItem { Value = "1", Text = "Assistente"},
            //        new SelectListItem { Value = "2", Text = "Médico"},
            //        new SelectListItem { Value = "3", Text = "Recepcionista"}
            //};
            return View(professionalViewModel);
        }

        // GET: ProfessionalTeams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProfessionalTeams == null)
            {
                return NotFound();
            }

            var professionalTeam = await _context.ProfessionalTeams.FindAsync(id);
            if (professionalTeam == null)
            {
                return NotFound();
            }
            return View(professionalTeam);
        }

        // POST: ProfessionalTeams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Birthday,Address,Locality,ZipCode,TaxPayerNumber,Position,Specialty")] ProfessionalTeam professionalTeam)
        {
            if (id != professionalTeam.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professionalTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessionalTeamExists(professionalTeam.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(professionalTeam);
        }

        // GET: ProfessionalTeams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProfessionalTeams == null)
            {
                return NotFound();
            }

            var professionalTeam = await _context.ProfessionalTeams
                .FirstOrDefaultAsync(m => m.ID == id);
            if (professionalTeam == null)
            {
                return NotFound();
            }

            return View(professionalTeam);
        }

        // POST: ProfessionalTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProfessionalTeams == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProfessionalTeams'  is null.");
            }
            var professionalTeam = await _context.ProfessionalTeams.FindAsync(id);
            if (professionalTeam != null)
            {
                _context.ProfessionalTeams.Remove(professionalTeam);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessionalTeamExists(int id)
        {
          return (_context.ProfessionalTeams?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }

    
}
