using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomDiceRollGenerator : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI numberDisplay;
    public int numOfRolls;
    public float waitTime;
    public int tar;
    public int min;
    public int max;

    // Start is called before the first frame update
    void Start()
    {
        RandomDiceRoll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomDiceRoll() {
        StartCoroutine(WaitBeforeFlash());
    }

    IEnumerator WaitBeforeFlash() {
        for (int i = 0; i < numOfRolls; i++) {
            int tempTar = Random.Range(min, max);
            Debug.Log(tempTar);
            numberDisplay.text = tempTar.ToString();
            yield return new WaitForSecondsRealtime(waitTime);
        }
        numberDisplay.text = tar.ToString();
    }
}
