//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfTestApp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            this.ClientsProducts = new HashSet<ClientsProduct>();
        }
    
        public int Id_cl { get; set; }
        public string Type_cl { get; set; }
        public string Name_cl { get; set; }
        public int Status_cl { get; set; }
        public int Manager { get; set; }
    
        public virtual Manager Manager1 { get; set; }
        public virtual Client_status Client_status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientsProduct> ClientsProducts { get; set; }
    }
}
