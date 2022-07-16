using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientGenerator : MonoBehaviour
{
    [SerializeField] private List<string> patientNames;
    [SerializeField] private List<Injury> injuries;

    private List<string> availablePatientNames;

    private void Start()
    {
        ResetNameList();
    }

    private void ResetNameList()
    {
        availablePatientNames = patientNames;
    }

    public Patient GeneratePatient()
    {
        Patient patient = new Patient();
        patient.Name = availablePatientNames[Random.Range(0, availablePatientNames.Count - 1)];
        availablePatientNames.Remove(patient.Name);
        patient.Injury = injuries[Random.Range(0, injuries.Count)];
        patient.Rank = (PatientRank)Random.Range(0, 3);

        return patient;
    }
}
