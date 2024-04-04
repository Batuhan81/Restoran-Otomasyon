/*****************
* This abstract class need for creating derived Entities 
* Example class ProductEntity : BaseEntity
*
*****************/
using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework.CodeFirst.Entities
{
    public abstract class BaseEntity
    {
        private DateTime _addedDate;
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime AddedDate
        {
            get { return DateTime.SpecifyKind(_addedDate, DateTimeKind.Utc); }
            private set { _addedDate = value; }
        }
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            AddedDate = DateTime.UtcNow;
        }
    }
}
