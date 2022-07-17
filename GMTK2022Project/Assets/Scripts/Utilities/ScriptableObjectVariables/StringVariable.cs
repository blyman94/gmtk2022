using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable.../String Variable")]
public class StringVariable : ScriptableObject
{
    public VariableUpdated ValueUpdated;

    [SerializeField] private string value;

    public string Value
    {
        get { return value; }
        set
        {
            this.value = value;
            ValueUpdated?.Invoke();
        }
    }

}
