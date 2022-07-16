using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PatientListItem : MonoBehaviour
{
    [SerializeField] private Patient observedPatient;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI rankText;
    [SerializeField] private TextMeshProUGUI severityText;
    [SerializeField] private PatientVariable selectedPatient;
    [SerializeField] private List<Image> providerSlots;
    public Patient ObservedPatient
    {
        get
        {
            return observedPatient;
        }
        set
        {
            observedPatient = value;
            UpdateDisplay();
        }
    }


    public void TryAddObservedProvider(CareProvider provider)
    {
        if (observedPatient.ProviderSlots.Count + 1 > providerSlots.Count)
        {
            return;
        }
        
        observedPatient.ProviderSlots.Add(provider);
        UpdateDisplay();

    }

    public void UnassignProvider(CareProvider provider)
    {
        observedPatient.UnassignProvider(provider);
    }

    private void Start()
    {
        observedPatient.ProviderSlots = new List<CareProvider>();
        if (observedPatient != null)
        {
            UpdateDisplay();
        }
    }

    public void UpdateSelectedPatient()
    {
        selectedPatient.Value = observedPatient;
    }

    private void UpdateDisplay()
    {
        nameText.text = observedPatient.Name.ToUpper();
        rankText.text = observedPatient.Rank.ToString().ToUpper();
        severityText.text = observedPatient.Injury.Severity.ToString().ToUpper();
        for (int i = 0; i < observedPatient.ProviderSlots.Count; i++)
        {
            providerSlots[i].color = observedPatient.ProviderSlots[i].indicator;
        }
    }
}
