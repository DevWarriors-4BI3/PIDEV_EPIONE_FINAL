using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class AppointmentModel
    {
        public Appointment appointement { get; set; }
        public IEnumerable<Disponibility> Disponibilities { get; set; }
    }
}