//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Apartments
{
    using System;
    using System.Collections.Generic;
    
    public partial class Review
    {
        public int IDReview { get; set; }
        public string Content { get; set; }
        public int ApartmentID { get; set; }
    
        public virtual Apartment Apartment { get; set; }
    }
}
