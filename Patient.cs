using System;
using System.Collections.Generic;
using System.Text;

namespace session09C_
{
    internal class Patient(int id, string fullName, string phoneNumber, string medicalHistory)
    {
        public int Id { get; set; } = id;
        public string FullName { get; set; } = fullName;
        public string PhoneNumber { get; set; } = phoneNumber;
        public string MedicalHistory { get; set; } = medicalHistory;

        public override string ToString()
        {
            return $"Id: {Id} :: FullName: {FullName} :: PhoneNumber: {PhoneNumber} :: MedicalHistory: {MedicalHistory}";
        }
    }
}
