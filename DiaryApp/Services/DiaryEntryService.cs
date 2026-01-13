using DiaryApp.Data;
using DiaryApp.Models;

namespace DiaryApp.Services
{
    public class DiaryEntryService
    {
        private readonly ApplicationDbContext _db;

        public DiaryEntryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<DiaryEntry> GetAll()
        {
            var objDiaryEntryList = _db.DiaryEntries
                .OrderByDescending(e => e.Created)
                .ToList();

            return objDiaryEntryList;   
        }
    }
}
