//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClinicReception
{
    using System;
    using System.Collections.Generic;
    
    public partial class Schedule
    {
        public int RecordId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }
        public Nullable<int> PatientID { get; set; }
        public string PatientSurname { get; set; }
        public string PatientName { get; set; }
        public string PatientPatronymic { get; set; }
        public Nullable<int> MedCard { get; set; }
        public string Phone { get; set; }
        public Nullable<int> DocID { get; set; }
        public string DocSurname { get; set; }
        public string DocName { get; set; }
        public string DocPatronymic { get; set; }
        public string Department { get; set; }
        public Nullable<int> CabNumber { get; set; }
    
        public virtual AppointmentRegistration AppointmentRegistration { get; set; }
        public virtual Doctors Doctors { get; set; }
    }
}
