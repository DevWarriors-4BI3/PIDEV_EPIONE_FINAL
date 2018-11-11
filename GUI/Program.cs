using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using System.Threading.Tasks;
using Data;
using Service;

namespace GUI
{
    class Program
    {

        static void Main(string[] args)
        {
            ServiceDocteur sd = new ServiceDocteur();
            Doctor d = new Doctor();
            d = sd.GetById("63bd4d7e-05db-4db8-bde0-ffe8181be100");


            ServiceDisponibility sdispo = new ServiceDisponibility();
           
            sdispo.Add(new Disponibility()
            {
                doctor = d,
                startTimeOfDisponibility = DateTime.Now,
                endTimeOfDisponibility = DateTime.Now,
                State = true
            });
            sdispo.Commit();


        }
    }
}
