using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm_Hospital_.Models
{
    public class Doctor : Person
    {
        public Speciality Special { get; set; }
        public string Location { get; set; }
        public List<Patient> Patients { get; set; }
        public List<WorkDay> WorkDays { get; set; }
        public string Degree { get; set; }
        public double Rating { get; set; }
    }
    public enum Speciality
    {
        Allergist,
        Anesthesiologist,
        Venerologist,
        Virologist,
        Ambulance,
        Dermatologist,
        Nutritionist,
        Infectious,
        Cosmetologist,
        Neurologist,
        Oncologist,
        Psychologist,
        Pediatrician,
        Surgeon,
        Therapist,
        Traumatologist

    }
}
