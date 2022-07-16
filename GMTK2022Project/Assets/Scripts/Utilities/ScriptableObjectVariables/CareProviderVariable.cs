using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable.../Provider Variable")]
public class CareProviderVariable : ScriptableObject
{
    public VariableUpdated ValueUpdated;

    [SerializeField] private CareProvider value;

    public CareProvider Value
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