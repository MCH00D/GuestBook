using GuestBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.DataAccessLayer
{
    public interface IRepository
    {
        List<Record> GetRecords();

        Record GetRecord(int id);

        void CreateRecord(Record record);

        void UpdateRecord(Record record);

        void DeleteRecord(int id);
    }
}
