using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRollUI : MonoBehaviour
{
    [SerializeField]
    public List<Sprite> faceNumberSprites;
    public int numOfRolls;
    public float waitTime;
    public int tarRollValue;
    public int minRollValue;
    public int maxRollValue;
    public int rotateAngle;

    public Transform pivot;
    public GameObject faceNumber;
    
    public void RandomDiceRoll(Throw diceValues) {
        StartCoroutine(WaitBeforeFlash(diceValues));
    }

    IEnumerator WaitBeforeFlash(Throw diceValues) {
        for (int i = 0; i < numOfRolls; i++) {
            int tempTar = Random.Range(diceValues.GetMin(), diceValues.GetMax() + 1);
            faceNumber.GetComponent<Image>().sprite = faceNumberSprites[tempTar];
            yield return
                new WaitForSeconds(
                    waitTime); //Spin(new Quaternion(0, 0, Random.Range(-2, 3) * rotateAngle, 1));
        }
        
        //yield return Spin(new Quaternion(0, 0, 0, 1));
        faceNumber.GetComponent<Image>().sprite = faceNumberSprites[diceValues.GetThrow()];
    }

    IEnumerator Spin(Quaternion rotation)
    {
        float elapsedTime = 0f;
        while (elapsedTime <= waitTime)
        {
            pivot.rotation = Quaternion.Lerp(pivot.rotation, rotation, elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;
            yield return new WaitForSecondsRealtime(0f);
        }
    }
}
