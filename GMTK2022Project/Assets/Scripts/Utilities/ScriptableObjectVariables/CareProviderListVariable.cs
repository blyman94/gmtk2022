using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CareProviderListVariable : ScriptableObject
{
    public VariableUpdated ValueUpdated;

    [SerializeField] private List<CareProvider> value;
    [SerializeField] private CareProvider nullProvider;

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

    public void AddAtIndex(CareProvider provider, int index)
    {
        value[index] = provider;
        ValueUpdated?.Invoke();
    }

    public bool CheckValidPlacement(int index)
    {
        return value[index] == nullProvider;

    }

    public void ResetList(int entries)
    {
        value = new List<CareProvider>();
        for (int i = 0; i < entries; i++)
        {
            value.Add(nullProvider);
        }
        ValueUpdated?.Invoke();
    }

    public void AddAtIndexUnique(CareProvider provider, int index)
    {
        if (value.Contains(provider))
        {
            int removalIndex = value.IndexOf(provider);
            value[removalIndex] = nullProvider;
        }

        value[index] = provider;
        ValueUpdated?.Invoke();
    }
}