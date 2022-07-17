using System.Globalization;
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
    public int rotateAngle;

    public Transform pivot;
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
            yield return Spin(new Quaternion(0, 0, Random.Range(-2, 3) * rotateAngle, 1));
            //yield return new WaitForSecondsRealtime(waitTime);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(0, 0, 90, 1), waitTime/90 * Time.deltaTime);
        }
        yield return Spin(new Quaternion(0, 0, 0, 1));
        faceNumber.GetComponent<Image>().sprite = faceNumberSprites[tarRollValue - 1];
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
