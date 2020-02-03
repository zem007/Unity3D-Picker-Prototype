using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public static int score = 1000;

    void Awake()
    {
        if(PlayerPrefs.HasKey("ApplePickerHighScore")) {
            score = PlayerPrefs.GetInt("ApplePickerHighScore");
        }
        PlayerPrefs.SetInt("ApplePickerHighScore", score);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GUIText gt = this.GetComponent<GUIText>();
        gt.text = "Highest Score: " + score;

        //更新PlayerPrefs中存的最高分
        if(score > PlayerPrefs.GetInt("ApplePickerHighScore")) {
            PlayerPrefs.SetInt("ApplePickerHighScore", score);
        }
    }
}
