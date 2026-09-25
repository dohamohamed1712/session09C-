using System;
using System.Collections.Generic;
using System.Text;

namespace session09C_
{
    internal static class PatientMapper
    {
        public static PatientDto MapFromModelToDto(Patient patient)
        {
            return new PatientDto(patient.Id, patient.FullName, patient.PhoneNumber);
        }
    }
}
