using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientGenerator : MonoBehaviour
{
    [SerializeField] IntVariable patientCount;
    [SerializeField] List<Injury> allInjuries;
    [SerializeField] List<PatientRank> allRanks;
    [SerializeField] PatientListVariable daysPatients;

    private List<Patient> patientListToStore;

    public void GeneratePatients()
    {
        patientListToStore = new List<Patient>();
        for (int i = 0; i < patientCount.Value; i++)
        {
            Patient patient = new Patient("Patient_" + i.ToString(), 
            GenerateRandomBackground(), allInjuries[Random.Range(0, allInjuries.Count)]);
            patientListToStore.Add(patient);
        }
        daysPatients.Value = patientListToStore;
        Debug.Log("New Patients Generated!");
    }

    private PatientBackground GenerateRandomBackground()
    {
        PatientRank rank = allRanks[Random.Range(0, allRanks.Count)];
        bool isMarried = Random.Range(0.0f, 1.0f) <= 0.3f;
        int childCount = Random.Range(0, 20);
        int age = Random.Range(17, 65);
        int daysUntilDischarge = Random.Range(1, 1825);

        return new PatientBackground(rank, isMarried, childCount, age, 
            daysUntilDischarge);
    }
}
