//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HumanRMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class holiday
    {
        public int holiday_id { get; set; }
        public System.DateTime holiday_month { get; set; }
        public System.DateTime holiday_day { get; set; }
        public System.DateTime holiday_year { get; set; }
        public string holiday_description { get; set; }
        public Nullable<int> holiday_fk_emp_id { get; set; }
        public Nullable<int> holiday_fk_att_id { get; set; }
    
        public virtual attendance attendance { get; set; }
        public virtual employee_info employee_info { get; set; }
    }
}
