using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AppointmentsPoc.Models
{
    public class AppointmentsModel
    {
        public IEnumerable<SelectListItem> Especialidades { get; set; }
        public IEnumerable<SelectListItem> Animais { get; set; }
        public IEnumerable<SelectListItem> Local { get; set; }
        public string LST_AGE { get; set; }
        public string XML_SOURCE { get; set; }
        public string XSLT_SOURCE { get; set; }

        public string OPT_ESP { get; set; }

        public string OPT_LOC { get; set; }

        public string OPT_PRO { get; set; }
        public string OPT_ANI { get; set; }

        public DateTime DAT_AGE { get; set; } = DateTime.Now;
    }
}