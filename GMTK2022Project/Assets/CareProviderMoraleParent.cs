using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CareProviderMoraleParent : MonoBehaviour
{
    [SerializeField] List<CareGiverMoraleDisplay> childDisplays;

    public void UpdateAllCareProviderMorales()
    {
        foreach (CareGiverMoraleDisplay moraleDisplay in childDisplays)
        {
            moraleDisplay.UpdateDisplay();
        }
    }
}
