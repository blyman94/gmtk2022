using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActivePatientObserver : MonoBehaviour
{
    [SerializeField] private PatientVariable activePatient;
    [SerializeField] private CanvasGroupRevealer choosePatientRevealer;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI prestigeText;
    [SerializeField] private TextMeshProUGUI prestigeDescriptionText;
    [SerializeField] private TextMeshProUGUI rankText;
    [SerializeField] private TextMeshProUGUI rankDescriptionText;
    [SerializeField] private TextMeshProUGUI injurySeverityText;
    [SerializeField] private TextMeshProUGUI injuryDescriptionText;
    [SerializeField] private TextMeshProUGUI ageText;
    [SerializeField] private TextMeshProUGUI marriedText;
    [SerializeField] private TextMeshProUGUI childText;
    [SerializeField] private TextMeshProUGUI dischargeText;

    private void OnEnable()
    {
        activePatient.ValueUpdated += UpdateDisplay;
    }
    private void Start()
    {
        ClearActivePatient();
        UpdateDisplay();
    }

    public void ClearActivePatient()
    {
        activePatient.Value = null;
    }

    private void OnDisable()
    {
        activePatient.ValueUpdated -= UpdateDisplay;
    }

    private void UpdateDisplay()
    {
        if (activePatient.Value == null)
        {
            choosePatientRevealer.ShowGroup();
            return;
        }
        else
        {
            choosePatientRevealer.HideGroup();

            nameText.text = activePatient.Value.Name;
            prestigeText.text = "Class " + activePatient.Value.Background.Rank.GetPrestigeGroup().ToString();
            prestigeDescriptionText.text = activePatient.Value.Background.Rank.PrestigeDescription;
            rankText.text = activePatient.Value.Background.Rank.Title;
            rankDescriptionText.text = activePatient.Value.Background.Rank.Description;
            injurySeverityText.text = activePatient.Value.Injury.GetInjuryLevel().ToString();
            injuryDescriptionText.text = activePatient.Value.Injury.Description;
            ageText.text = activePatient.Value.Background.Age.ToString();
            marriedText.text = activePatient.Value.Background.IsMarried.ToString();
            childText.text = activePatient.Value.Background.ChildCount.ToString();
            dischargeText.text = activePatient.Value.Background.DaysUntilDischarge.ToString();
        }
    }
}
