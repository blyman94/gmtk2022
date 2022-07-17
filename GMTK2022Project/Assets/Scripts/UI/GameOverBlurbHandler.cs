using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverBlurbHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverBlurbText;

    [SerializeField] private List<string> gameOverBlurbs;

    [SerializeField] private IntVariable patientDeathCount;

    public void UpdateGameOverBlurb()
    {
        if (patientDeathCount.Value == 0)
        {
            gameOverBlurbText.text = gameOverBlurbs[0];
        }
        else if (patientDeathCount.Value > 0 && patientDeathCount.Value <= 5)
        {
            gameOverBlurbText.text = gameOverBlurbs[1];
        }
        else if (patientDeathCount.Value > 5 && patientDeathCount.Value <= 10)
        {
            gameOverBlurbText.text = gameOverBlurbs[2];
        }
        else if (patientDeathCount.Value > 10 && patientDeathCount.Value <= 15)
        {
            gameOverBlurbText.text = gameOverBlurbs[3];
        }
        else
        {
            gameOverBlurbText.text = gameOverBlurbs[4];
        }
    }
}
