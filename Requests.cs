//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UchPraktika
{
    using System;
    using System.Collections.Generic;
    
    public partial class Requests
    {
        public int RequestID { get; set; }
        public System.DateTime RequestDate { get; set; }
        public int StatusID { get; set; }
        public string Description { get; set; }
        public int UserID { get; set; }
        public byte[] Img { get; set; }
    
        public virtual Status Status { get; set; }
        public virtual User User { get; set; }
    }
}
