using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomDiceRollGenerator : MonoBehaviour
{
    [SerializeField]
    public List<Sprite> faceNumberSprites;
    public int numOfRolls;
    public float waitTime;
    public int tarRollValue;
    public int minRollValue;
    public int maxRollValue;

    public GameObject faceNumber;


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
            int tempTar = Random.Range(minRollValue, maxRollValue + 1);
            faceNumber.GetComponent<Image>().sprite = faceNumberSprites[tempTar - 1];
            yield return new WaitForSecondsRealtime(waitTime);
        }
        faceNumber.GetComponent<Image>().sprite = faceNumberSprites[tarRollValue - 1];
    }
}
