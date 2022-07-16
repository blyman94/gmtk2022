using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CareProviderListVariable : ScriptableObject
{
    public VariableUpdated ValueUpdated;

    [SerializeField] private List<CareProvider> value;

    public List<CareProvider> Value
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