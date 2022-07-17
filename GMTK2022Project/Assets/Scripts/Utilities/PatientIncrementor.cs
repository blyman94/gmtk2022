using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientIncrementor : MonoBehaviour
{
    [SerializeField] private IntVariable dayCount;
    [SerializeField] private IntVariable patientCount;

    private void OnEnable()
    {
        dayCount.ValueUpdated += calculatePatients;
    }

    private void OnDisable()
    {
        dayCount.ValueUpdated -= calculatePatients;
    }

    public void ResetPatientCount()
    {
        patientCount.Value = 3;
    }

    private void calculatePatients()
    {
        if (dayCount.Value < 2)
        {
            patientCount.Value = 3;
        }
        else if (dayCount.Value < 4)
        {
            patientCount.Value = 4;
        }
        else if (dayCount.Value < 6)
        {
            patientCount.Value = 5;
        }
        else
        {
            patientCount.Value = 6;
        }
    }
}
