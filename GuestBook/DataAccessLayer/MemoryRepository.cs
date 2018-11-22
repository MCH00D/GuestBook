using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GuestBook.Models;

namespace GuestBook.DataAccessLayer
{
    public class MemoryRepository : IRepository
    {
        private static List<Record> _records = new List<Record>();

        private static object _objLock = new object();

        public void CreateRecord(Record record)
        {
            if (_records.Count == 0)
            {
                record.Id = 1;
            }
            else
            {
                record.Id = _records.Last().Id + 1;
            }

            lock (_objLock)
            {
                _records.Add(record);
            }
        }

        public Record GetRecord(int id)
        {
            return _records.First(r => r.Id == id);
        }

        public List<Record> GetRecords()
        {
            return _records;
        }

        public void DeleteRecord(int id)
        {
            _records.Remove(GetRecord(id));
        }

        public void UpdateRecord(Record record)
        {
            Record foundRecord = GetRecord(record.Id);
            foundRecord.Message = record.Message;
        }
    }
}