namespace Doctor.Application.Model.Data
{
    using System;
    using System.Collections.Generic;
    public class AddPrescriptionData
    {
        public int IdDoctor { get; set; }

        public int IdPatient { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateOfExpiration { get; set; }
        public IDictionary<string, int> Medicines { get; set; }
    }
}
