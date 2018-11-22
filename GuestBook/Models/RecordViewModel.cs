using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuestBook.Models
{
    public class RecordViewModel : IValidatableObject
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string Author { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Message))
            {
                yield return new ValidationResult("Message must not be empty.", new [] { "Message" });
            }

            if (string.IsNullOrWhiteSpace(Author))
            {
                yield return new ValidationResult("Author must not be empty.", new [] { "Author" });
            }       
        }
    }
}