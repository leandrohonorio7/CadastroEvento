//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Site.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EventoDia
    {
        public EventoDia()
        {
            this.Pessoa = new HashSet<Pessoa>();
        }
    
        public int Id { get; set; }
        public int IdEvento { get; set; }
        public System.DateTime Data { get; set; }
        public Nullable<System.DateTime> HoraInicio { get; set; }
        public Nullable<System.DateTime> HoraFim { get; set; }
        public string Observacao { get; set; }
    
        public virtual Evento Evento { get; set; }
        public virtual ICollection<Pessoa> Pessoa { get; set; }
    }
}