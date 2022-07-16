using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable.../Patient List Variable")]
public class PatientListVariable : ScriptableObject
{
    public VariableUpdated ValueUpdated;

    [SerializeField] private List<Patient> value;

    public List<Patient> Value
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
