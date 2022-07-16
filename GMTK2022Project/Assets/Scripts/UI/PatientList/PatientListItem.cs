using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PatientListItem : MonoBehaviour
{
    [SerializeField] private Patient observedPatient;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI rankText;
    [SerializeField] private TextMeshProUGUI severityText;
    [SerializeField] private PatientVariable selectedPatient;

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

    private void Start()
    {
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
    }
}
