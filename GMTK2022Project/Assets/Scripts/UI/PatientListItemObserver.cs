using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientListItemObserver : MonoBehaviour
{
    [SerializeField] private Patient patientToObserve;

    public Patient PatientToObserve
    {
        get
        {
            return patientToObserve;
        }
        set
        {
            patientToObserve = value;
        }
    }


}
