using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProviderDisplayParent : MonoBehaviour
{
    [SerializeField] List<CareProviderDisplay> childDisplays;

    public void ClearAllFromBreakRoom()
    {
        foreach (CareProviderDisplay display in childDisplays)
        {
            display.ClearFromBreakRoom();
        }
    }

    public void ClearAllFromPatients()
    {
        foreach (CareProviderDisplay display in childDisplays)
        {
            display.ClearFromPatient();
        }
    }

}
