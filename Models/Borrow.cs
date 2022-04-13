//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Borrow
    {
        public int BorrowID { get; set; }
        public Nullable<int> BookId { get; set; }
        public string BorrowerName { get; set; }
        public Nullable<System.DateTime> BorrowDate { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public Nullable<int> BookStatusId { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual BookStatu BookStatu { get; set; }
    }
}
