//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LabExamMid.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Memory
    {
        public int Id { get; set; }
        public string Story { get; set; }
        public string PhotoPath { get; set; }
        public System.DateTime Date { get; set; }
        public System.DateTime LastModificationDate { get; set; }
        public int Priority { get; set; }
        public string Username { get; set; }
    
        public virtual User User { get; set; }
    }
}
