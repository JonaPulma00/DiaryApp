using DiaryApp.Data;
using DiaryApp.Models;
using DiaryApp.Services;
using DiaryApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace DiaryApp.Controllers
{
    public class DiaryEntriesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly DiaryEntryService _diaryService;

        //constructor
        public DiaryEntriesController(ApplicationDbContext db, DiaryEntryService diaryService)
        {
            _db = db;
            _diaryService = diaryService;
        }

        public IActionResult Index()
        {
            List<DiaryEntry> objDiaryEntryList = _diaryService.GetAll();
            return View(objDiaryEntryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DiaryEntryViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            _diaryService.Create(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(Guid id) {

            if(id == null || id == Guid.Empty)
            {
                return NotFound();
            }
            DiaryEntry? diaryEntry = _diaryService.GetById(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }
            return View(diaryEntry);
        }

        [HttpPost]
        public IActionResult Edit(DiaryEntryViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            _diaryService.Update(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {

            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }
            DiaryEntry? diaryEntry = _diaryService.GetById(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }
            return View(diaryEntry);
        }

        [HttpPost]
        public IActionResult Delete(DiaryEntry obj)
        {


                _diaryService.Delete(obj);
                return RedirectToAction("Index");
        }
     }
 }
