//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace auto.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Automobiles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Automobiles()
        {
            this.Orders = new HashSet<Orders>();
            this.Images = new HashSet<Images>();
        }
    
        public int idAuto { get; set; }
        public Nullable<int> idBrand { get; set; }
        public Nullable<int> idModel { get; set; }
        public Nullable<int> idKPP { get; set; }
        public Nullable<int> yearModel { get; set; }
        public Nullable<decimal> price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual Brands Brands { get; set; }
        public virtual KPP KPP { get; set; }
        public virtual Models Models { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Images> Images { get; set; }
    }
}