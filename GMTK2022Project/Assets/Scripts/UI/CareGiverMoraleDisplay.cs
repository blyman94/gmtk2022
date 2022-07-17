using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CareGiverMoraleDisplay : MonoBehaviour
{
    [SerializeField] private CareProvider observedProvider;
    [SerializeField] private Image careProviderImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI startMoraleText;
    [SerializeField] private TextMeshProUGUI patientMoraleText;
    [SerializeField] private TextMeshProUGUI breakroomMoraleText;
    [SerializeField] private TextMeshProUGUI hospitalMoraleText;
    [SerializeField] private TextMeshProUGUI finalMoraleText;

    public void UpdateDisplay()
    {
        observedProvider.UpdateCurrentMorale(out int previousMorale,
            out int patientMorale, out int breakroomMorale,
            out int hospitalMorale, out int finalMorale);
        nameText.text = observedProvider.Name;
        startMoraleText.text = previousMorale.ToString();
        patientMoraleText.text = patientMorale.ToString();
        breakroomMoraleText.text = breakroomMorale.ToString();
        hospitalMoraleText.text = hospitalMorale.ToString();
        finalMoraleText.text = finalMorale.ToString();
    }
}
