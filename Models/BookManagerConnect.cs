using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BookManager.Models
{
    public partial class BookManagerConnect : DbContext
    {
        public BookManagerConnect()
            : base("name=BookManagerConnect")
        {
        }

        public static int BadRequest { get; internal set; }
        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
