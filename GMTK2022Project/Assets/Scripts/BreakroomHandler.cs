using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakroomHandler : MonoBehaviour
{
    [SerializeField] private CareProviderListVariable breakRoomProviders;
    [SerializeField] private CareProvider nullProvider;

    public void UpdateProviderMorale()
    {
        foreach (CareProvider provider in breakRoomProviders.Value)
        {
            provider.MoraleChangeFromBreakroom = provider.Role.MaxMorale - 
                provider.CurrentMorale;
        }
        ClearProvider();

    }

    public void ClearProvider()
    {
        breakRoomProviders.Value.Clear();
        breakRoomProviders.Value.Add(nullProvider);
        breakRoomProviders.Value.Add(nullProvider);
    }
}
