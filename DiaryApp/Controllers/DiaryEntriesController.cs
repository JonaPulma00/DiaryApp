using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace DiaryApp.Controllers
{
    public class DiaryEntriesController : Controller
    {
        private readonly ApplicationDbContext _db;

        //constructor
        public DiaryEntriesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
            //DiaryEntries = sql server table name
        {
            List<DiaryEntry> objDiaryEntryList = _db.DiaryEntries
                .OrderByDescending(e => e.Created)
                .ToList();
            return View(objDiaryEntryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DiaryEntry obj)
        {
            //Server side validations
            if (obj != null && obj.Title.Length < 3) {
                ModelState.AddModelError("Title", "The title lengh is too short!");
            }

            if (ModelState.IsValid)
            {
                _db.DiaryEntries.Add(obj); //Adding the new diary entry to the db
                _db.SaveChanges(); //saving changes
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(Guid? id) {

            if(id == null || id == Guid.Empty)
            {
                return NotFound();
            }
            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }
            return View(diaryEntry);
        }

        [HttpPost]
        public IActionResult Edit(DiaryEntry obj)
        {
            //Server side validations
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "The title lengh is too short!");
            }

            if (ModelState.IsValid)
            {
                _db.DiaryEntries.Update(obj); //Updating entry in db
                _db.SaveChanges(); //saving changes
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(Guid? id)
        {

            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }
            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }
            return View(diaryEntry);
        }

        [HttpPost]
        public IActionResult Delete(DiaryEntry obj)
        {


                _db.DiaryEntries.Remove(obj); //Remove entry from db
                _db.SaveChanges(); //saving changes
                return RedirectToAction("Index");
        }
     }
 }
