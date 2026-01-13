using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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

        public DiaryEntry? GetById(Guid id)
        {
            return _db.DiaryEntries.Find(id);
        }

        public void Create(DiaryEntry entry)
        {
            _db.DiaryEntries.Add(entry);
            _db.SaveChanges();
        }

        public void Update(DiaryEntry entry)
        {
            _db.DiaryEntries.Update(entry);
            _db.SaveChanges();
        }

        public void Delete(DiaryEntry entry)
        {
            _db.DiaryEntries?.Remove(entry);
            _db.SaveChanges();
        }
    }
}