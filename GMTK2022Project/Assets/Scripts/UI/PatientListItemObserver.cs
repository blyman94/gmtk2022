using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PatientListItemObserver : MonoBehaviour
{
    [SerializeField] private Patient observedPatient;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI prestigeText;
    [SerializeField] private TextMeshProUGUI severityText;
    [SerializeField] private PatientVariable selectedPatient;
    [SerializeField] private CareProvider nullProvider;
    [SerializeField] private List<Image> providerSlotImages;

    public Patient ObservedPatient
    {
        get
        {
            return observedPatient;
        }
        set
        {
            observedPatient = value;
        }
    }

    private void Start()
    {
        if (observedPatient != null)
        {
            UpdateDisplay();
        }
    }

    public bool TryAddProvider(CareProvider provider)
    {
        if (observedPatient.AssignedProviders[0] == nullProvider &&
            observedPatient.AssignedProviders[1] == nullProvider)
        {
            observedPatient.AssignedProviders[0] = provider;
            UpdateDisplay();
            return true;
        }
        else if (observedPatient.AssignedProviders[0] == nullProvider &&
            observedPatient.AssignedProviders[1] != nullProvider)
        {
            observedPatient.AssignedProviders[0] = provider;
            UpdateDisplay();
            return true;
        }
        else if (observedPatient.AssignedProviders[0] != nullProvider &&
            observedPatient.AssignedProviders[1] == nullProvider)
        {
            observedPatient.AssignedProviders[1] = provider;
            UpdateDisplay();
            return true;
        }
        else 
        {
            Debug.Log("Already has two providers!");
            return false;
        }
    }

    public void ClearProviders()
    {
        observedPatient.AssignedProviders = new List<CareProvider>();
        observedPatient.AssignedProviders.Add(nullProvider);
        observedPatient.AssignedProviders.Add(nullProvider);
        UpdateDisplay();
    }

    public void UpdateSelectedPatient()
    {
        selectedPatient.Value = observedPatient;
    }

    private void UpdateDisplay()
    {
        nameText.text = observedPatient.Name.ToUpper();
        prestigeText.text = "PRESTIGE LEVEL: " +
            observedPatient.Background.Rank.PrestigeLevel.ToString();
        severityText.text = "SEVERITY: " + observedPatient.Injury.SurvivalThreshold.ToString();
        for (int i = 0; i < providerSlotImages.Count; i++)
        {
            if (observedPatient.AssignedProviders[i] != null)
            {
                providerSlotImages[i].color = observedPatient.AssignedProviders[i].indicatorColor;
            }
            else
            {
                providerSlotImages[i].color = Color.white;
            }
        }
    }
}
