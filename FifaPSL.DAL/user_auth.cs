//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FifaPSL.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class user_auth
    {
        public byte user_auth_id { get; set; }
        public short user_id { get; set; }
        public string token { get; set; }
        public System.DateTime issued { get; set; }
    
        public virtual user user { get; set; }
    }
}
