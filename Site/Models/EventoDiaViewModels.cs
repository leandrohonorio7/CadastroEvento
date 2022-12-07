using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class EventoDiaViewModels
    {
        public List<DiasDeEvento> AvailableDias { get; set; }
        public List<DiasDeEvento> SelectedDias { get; set; }
        public PostedDias PostedDias { get; set; }
    }

    public class DiasDeEvento
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }

    public class PostedDias
    {
        public string[] DiasIDs { get; set; }
    }
}