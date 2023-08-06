using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
public class KillCounter : MonoBehaviour
{
    public static int KillCount;
    public TextMeshProUGUI text;
    public TextMeshProUGUI textHigh;
    // Start is called before the first frame update
    void Start()
    {
        textHigh.text = "HI-SCORE: " + PlayerPrefs.GetInt("HI-SCORE: ", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "SCORE: " + KillCount.ToString();

        if(KillCount > PlayerPrefs.GetInt("HI-SCORE: ", 0))
        {
            PlayerPrefs.SetInt("HI-SCORE: ", KillCount);
            textHigh.text = "HI-SCORE: " + KillCount.ToString();
        }
    }
}
