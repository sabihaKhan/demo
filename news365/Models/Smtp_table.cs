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
    
    public partial class Smtp_table
    {
        public int smtp_id { get; set; }
        public string Smtp_protocol { get; set; }
        public string Smtp_host { get; set; }
        public Nullable<int> Smtp_port { get; set; }
        public string Smtp_username { get; set; }
        public string Smtp_password { get; set; }
        public string Smtp_mail_type { get; set; }
        public string Smtp_charset { get; set; }
    }
}
