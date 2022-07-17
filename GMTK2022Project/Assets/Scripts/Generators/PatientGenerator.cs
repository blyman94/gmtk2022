using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PatientGenerator : MonoBehaviour
{
    [SerializeField] private string filePathFN;
    [SerializeField] private string filePathLN;
    [SerializeField] private IntVariable patientCount;
    [SerializeField] private List<Injury> allInjuries;
    [SerializeField] private List<PatientRank> allRanks;
    [SerializeField] private PatientListVariable daysPatients;
    [SerializeField] private CareProvider nullProvider;

    private List<Patient> patientListToStore;
    private List<string> firstNames;
    private List<string> lastNames;

    private void Start()
    {
        firstNames = ReadNamesFromFile(filePathFN);
        lastNames = ReadNamesFromFile(filePathLN);
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
        string first = firstNames[Random.Range(0, firstNames.Count)];
        string last = lastNames[Random.Range(0, lastNames.Count)];

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

    private List<string> ReadNamesFromFile(string filePath)
    {
        List<string> newList = new List<string>();
        StreamReader inpStm = new StreamReader(filePath);

        while (!inpStm.EndOfStream)
        {
            string inpLn = inpStm.ReadLine();
            newList.Add(inpLn);
        }
        inpStm.Close();
        return newList;
    }
}
