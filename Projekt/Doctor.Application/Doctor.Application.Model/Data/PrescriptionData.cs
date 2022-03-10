namespace Doctor.Application.Model.Data
{
    using System;
    using System.Collections.Generic;

    public class PrescriptionData
    {
        public int IdPrescription { get; set; }
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateOfExpiration { get; set; }
        public IEnumerable<MedicineData> Medicines { get; set; }
    }
}
