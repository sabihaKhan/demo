//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace news365.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class NewsTable
    {
        public int NewsID { get; set; }
        [DisplayName("News Category")]
        public Nullable<int> CategoryID { get; set; }
        public string Description { get; set; }
        public List<CategoryTable> NewsCategories { get; set; }
      
        public virtual CategoryTable CategoryTable { get; set; }
    }
}
