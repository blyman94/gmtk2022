using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PatientResultObserver : MonoBehaviour
{
    [SerializeField] private Patient observedPatient;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI prestigeText;
    [SerializeField] private TextMeshProUGUI severityText;

    [SerializeField] private TextMeshProUGUI ProviderAText;
    [SerializeField] private TextMeshProUGUI ProviderBText;

    [SerializeField] private DiceRollUI NaturalThrow;
    [SerializeField] private DiceRollUI ProviderThrowA;
    [SerializeField] private DiceRollUI ProviderThrowB;
    [SerializeField] private TextMeshProUGUI throwSumText;
    [SerializeField] private Image survivalSprite;
    [SerializeField] private List<Sprite> liveDieSprite;
    [SerializeField] private IntVariable deathCountVariable;


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

    public void CalculatePatientRoll()
    {
        observedPatient.GetSurvivalData(out Throw naturalThrow,
            out List<Throw> providerThrows, out int survivalThreshold,
            out int throwSum, out bool survived);
        observedPatient.UpdateCareProviderMorales(survived);

        if (!survived)
        {
            deathCountVariable.Value += 1;
        }   

        NaturalThrow.RandomDiceRoll(naturalThrow);
        for (int i = 0; i < observedPatient.AssignedProviders.Count; i++)
        {
            if (i == 0)
            {
                ProviderThrowA.RandomDiceRoll(providerThrows[i]);
            }
            else
            {
                ProviderThrowB.RandomDiceRoll(providerThrows[i]);

            }
        }

        throwSumText.text = throwSum.ToString();

        int spriteIndex = survived ? 0 : 1;
        survivalSprite.sprite = liveDieSprite[spriteIndex];

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        nameText.text = observedPatient.Name.ToUpper();
        prestigeText.text = "PRESTIGE CLASS: " +
            observedPatient.Background.Rank.GetPrestigeGroup().ToString();
        severityText.text = "ROLL NEEDED: " + observedPatient.Injury.SurvivalThreshold.ToString();

        for (int i = 0; i < observedPatient.AssignedProviders.Count; i++)
        {
            if (i == 0)
            {
                ProviderAText.text = observedPatient.AssignedProviders[i].Name;
            }
            else
            {
                ProviderBText.text = observedPatient.AssignedProviders[i].Name;
            }
        }


    }


}
