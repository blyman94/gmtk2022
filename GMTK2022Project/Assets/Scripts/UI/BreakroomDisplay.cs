using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BreakroomDisplay : MonoBehaviour
{
    [SerializeField] private CareProvider provider;
    [SerializeField] private TextMeshProUGUI providerName;
    [SerializeField] private Image breakroomImage;

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
        providerName.text = provider.Name;
        breakroomImage.color = provider.indicatorColor;
    }

}
