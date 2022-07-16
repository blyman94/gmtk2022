using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BreakroomDisplay : MonoBehaviour
{

    private CareProvider provider;

    [SerializeField] private TextMeshProUGUI providerName;

    public CareProvider Provider
    {
        get
        {
            return provider;
        }

        set
        {
            provider = value;
            UpdateDisplay();
        }
    }
    public int index;

    private void Start()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (provider != null)
        {
            providerName.text = provider.Name;
        }
        else
        {
            providerName.text = "EMPTY";
        }
    }

}
