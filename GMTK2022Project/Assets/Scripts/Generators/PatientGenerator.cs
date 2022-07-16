using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientGenerator : MonoBehaviour
{
    [SerializeField] IntVariable patientCount;
    [SerializeField] List<Injury> allInjuries;
    [SerializeField] PatientListVariable daysPatients;

    private List<Patient> patientListToStore;

    public void GeneratePatients()
    {
        patientListToStore = new List<Patient>();
        for (int i = 0; i < patientCount.Value; i++)
        {
            Patient patient = new Patient("Patient_" + i.ToString(),
                allInjuries[Random.Range(0, allInjuries.Count)]);
            patientListToStore.Add(patient);
        }
        daysPatients.Value = patientListToStore;
        Debug.Log("New Patients Generated!");
    }
}
