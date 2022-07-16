using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakroomHandler : MonoBehaviour
{
    [SerializeField] private CareProviderListVariable breakRoomProviders;

    public void UpdateProviderMorale()
    {
        foreach (CareProvider provider in breakRoomProviders.Value)
        {
            provider.MoraleChangeFromBreakroom = provider.Role.MaxMorale - 
                provider.CurrentMorale;
        }
    }
}
