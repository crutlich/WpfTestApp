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
    
    public partial class ClientsProduct
    {
        public int Id_clpr { get; set; }
        public int Client { get; set; }
        public int Product { get; set; }
    
        public virtual Client Client1 { get; set; }
        public virtual Product Product1 { get; set; }
    }
}
