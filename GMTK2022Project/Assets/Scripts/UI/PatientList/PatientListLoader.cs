using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientListLoader : MonoBehaviour
{
    [SerializeField] private IntVariable patientCount;
    [SerializeField] private Transform listParent;
    [SerializeField] private PatientGenerator generator;
    [SerializeField] private GameObject listItemPrefab;

    private void Start()
    {
        for (int i = 0; i < patientCount.Value; i++)
        {
            Patient patientToDisplay = generator.GeneratePatient();
            GameObject listItemObject = Instantiate(listItemPrefab, listParent);
            PatientListItem listItem = listItemObject.GetComponent<PatientListItem>();
            listItem.ObservedPatient = patientToDisplay;
        }
    }
}
