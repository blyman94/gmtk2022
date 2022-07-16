using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BreakRoomDisplay : MonoBehaviour
{
    [SerializeField] private CareProvider observedProvider;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;


    public CareProvider ObservedProvider
    {
        get
        {
            return observedProvider;
        }
        set
        {
            observedProvider = value;
            UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        if(observedProvider != null)
        {
            _textMeshProUGUI.text = observedProvider.name;
        }
    }
}   
