using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientGenerator : MonoBehaviour
{
    [SerializeField] private List<string> patientNames;
    [SerializeField] private List<Injury> injuries;

    [SerializeField] private List<string> availablePatientNames;
    [SerializeField] private PatientListVariable daysPatient;

    public void Awake()
    {
        ResetNameList();
        daysPatient.Value = new List<Patient>();
        daysPatient.Value.Clear();
        
    }

    private void ResetNameList()
    {
        availablePatientNames = patientNames;
    }

    public Patient GeneratePatient()
    {
        Patient patient = new Patient();
        Debug.Log(availablePatientNames[Random.Range(0, availablePatientNames.Count - 1)]);
        patient.Name = availablePatientNames[Random.Range(0, availablePatientNames.Count - 1)];
        availablePatientNames.Remove(patient.Name);
        patient.Injury = injuries[Random.Range(0, injuries.Count)];
        patient.Rank = (PatientRank)Random.Range(0, 3);
        patient.ProviderSlots = new List<CareProvider>();
        daysPatient.Value.Add(patient);
        

        return patient;
    }
}
