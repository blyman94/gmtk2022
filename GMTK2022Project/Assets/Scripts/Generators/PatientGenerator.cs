using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PatientGenerator : MonoBehaviour
{
    [SerializeField] private IntVariable patientCount;
    [SerializeField] private List<Injury> allInjuries;
    [SerializeField] private List<PatientRank> allRanks;
    [SerializeField] private PatientListVariable daysPatients;
    [SerializeField] private CareProvider nullProvider;

    private List<Patient> patientListToStore;
    [SerializeField] private string firstNames;
    [SerializeField] private string lastNames;

    private string[] firstNamesList;
    private string[] lastNamesList;

    private void Start()
    {
        firstNamesList = firstNames.Split(' ');
        lastNamesList = lastNames.Split(' ');
    }

    public void GeneratePatients()
    {
        patientListToStore = new List<Patient>();
        for (int i = 0; i < patientCount.Value; i++)
        {
            Patient patient = new Patient(GenerateRandomName(),
                GenerateRandomBackground(),
                allInjuries[Random.Range(0, allInjuries.Count)]);
            patient.AssignedProviders.Add(nullProvider);
            patient.AssignedProviders.Add(nullProvider);
            patientListToStore.Add(patient);
        }
        daysPatients.Value = patientListToStore;
    }

    private string GenerateRandomName()
    {
        string first = firstNamesList[Random.Range(0, firstNamesList.Length)];
        string last = lastNamesList[Random.Range(0, lastNamesList.Length)];
        return first + " " + last;
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

    private List<string> ReadNamesFromFile(string fileName)
    {
        List<string> newList = new List<string>();
        TextAsset nameAsset = Resources.Load(fileName) as TextAsset;
        List<string> names = new List<string>(nameAsset.text.Split('\n'));
        return names;
    }
}
