//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vending.Model.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class VendingMachine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VendingMachine()
        {
            this.VendingMachineCoin = new HashSet<VendingMachineCoin>();
            this.VendingMachineDrink = new HashSet<VendingMachineDrink>();
        }
    
        public int Id { get; set; }
        public string SecretCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendingMachineCoin> VendingMachineCoin { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendingMachineDrink> VendingMachineDrink { get; set; }
    }
}
