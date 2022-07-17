using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PatientVariable : ScriptableObject
{
    public VariableUpdated ValueUpdated;

    private Patient value;

    public Patient Value
    {
        get
        {
            return value;
        }
        set
        {
            this.value = value;
            ValueUpdated?.Invoke();
        }
    }
}
