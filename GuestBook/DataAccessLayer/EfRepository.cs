using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GuestBook.Models;

namespace GuestBook.DataAccessLayer
{
    public class EfRepository : IRepository
    {
        private GuestBookContext _context = new GuestBookContext();

        public void CreateRecord(Record record)
        {
            _context.Records.Add(record);
            _context.SaveChanges();
        }

        public void DeleteRecord(int id)
        {
            _context.Records.Remove(GetRecord(id));
            _context.SaveChanges();
        }

        public Record GetRecord(int id)
        {
            return _context.Records.First(r => r.Id == id);
        }

        public List<Record> GetRecords()
        {
            return _context.Records.ToList<Record>();
        }

        public void UpdateRecord(Record record)
        {
            Record dbRecord = GetRecord(record.Id);
            dbRecord.Message = record.Message;
            _context.SaveChanges();
        }
    }
}