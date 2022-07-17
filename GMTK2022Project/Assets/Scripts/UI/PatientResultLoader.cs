using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientResultLoader : MonoBehaviour
{
    [SerializeField] private PatientListVariable daysPatients;
    [SerializeField] private GameObject patientResultPrefab;
    
    private List<PatientResultObserver> resultObservers;

    private void OnEnable()
    {
        daysPatients.ValueUpdated += UpdateDisplay;
    }

    private void OnDisable()
    {
        daysPatients.ValueUpdated -= UpdateDisplay;
    }

    public void ExecuteAllDiceRolls()
    {
        foreach (PatientResultObserver observer in resultObservers)
        {
            observer.CalculatePatientRoll();
        }
    }
    private void UpdateDisplay()
    {
        resultObservers = new List<PatientResultObserver>();
        foreach (Patient patient in daysPatients.Value)
        {
            GameObject listItemObject =
                Instantiate(patientResultPrefab, transform);
            PatientResultObserver observer =
                listItemObject.GetComponent<PatientResultObserver>();
            observer.ObservedPatient = patient;
            resultObservers.Add(observer);
        }
    }
}
