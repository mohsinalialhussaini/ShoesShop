//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JOOTASHOP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AdminData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdminData()
        {
            this.productAddedBies = new HashSet<productAddedBy>();
        }
    
        public static int ID { get; set; }
        public static string name { get; set; }
        public static string contact { get; set; }
        public static string cnic { get; set; }
    
        public virtual loginTable loginTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productAddedBy> productAddedBies { get; set; }
    }
}
