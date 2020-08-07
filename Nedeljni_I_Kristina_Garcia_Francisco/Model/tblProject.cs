//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nedeljni_I_Kristina_Garcia_Francisco.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblProject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProject()
        {
            this.tblEmployees = new HashSet<tblEmployee>();
            this.tblManagers = new HashSet<tblManager>();
        }
    
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ClientName { get; set; }
        public System.DateTime ContractDate { get; set; }
        public string ContractManager { get; set; }
        public System.DateTime ProjectStartDate { get; set; }
        public System.DateTime ProjectDeadline { get; set; }
        public int HourlyRate { get; set; }
        public string Realisation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEmployee> tblEmployees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblManager> tblManagers { get; set; }
    }
}
