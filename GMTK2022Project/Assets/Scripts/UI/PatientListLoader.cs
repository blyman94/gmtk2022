using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientListLoader : MonoBehaviour
{
    [SerializeField] private PatientListVariable daysPatients;
    [SerializeField] private GameObject patientListItemPrefab;

    private List<PatientListItemObserver> itemObservers;

    private void OnEnable()
    {
        daysPatients.ValueUpdated += UpdateDisplay;
    }

    private void OnDisable()
    {
        daysPatients.ValueUpdated -= UpdateDisplay;
    }

    public void ClearAllPersonel()
    {
        foreach (PatientListItemObserver observer in itemObservers)
        {
            observer.ClearProviders();
        }
    }

    private void UpdateDisplay()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        
        itemObservers = new List<PatientListItemObserver>();
        foreach (Patient patient in daysPatients.Value)
        {
            GameObject listItemObject =
                Instantiate(patientListItemPrefab, transform);
            PatientListItemObserver observer =
                listItemObject.GetComponent<PatientListItemObserver>();
            observer.ObservedPatient = patient;
            itemObservers.Add(observer);
        }
    }
}
