using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverBlurbHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverBlurbText;

    [SerializeField] private List<string> gameOverBlurbs;

    [SerializeField] private IntVariable patientDeathCount;

    [SerializeField] private GameEvent GoodEnding;
    
    [SerializeField] private GameEvent BadEnding;

    public void UpdateGameOverBlurb()
    {
        if (patientDeathCount.Value == 0)
        {
            gameOverBlurbText.text = gameOverBlurbs[0];
            GoodEnding.Raise();
        }
        else if (patientDeathCount.Value > 0 && patientDeathCount.Value <= 5)
        {
            gameOverBlurbText.text = gameOverBlurbs[1];
            GoodEnding.Raise();
        }
        else if (patientDeathCount.Value > 5 && patientDeathCount.Value <= 10)
        {
            gameOverBlurbText.text = gameOverBlurbs[2];
            BadEnding.Raise();
        }
        else
        {
            gameOverBlurbText.text = gameOverBlurbs[3];
            BadEnding.Raise();
        }
    }
}
