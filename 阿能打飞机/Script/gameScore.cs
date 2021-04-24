using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameScore : MonoBehaviour
{
    public int score;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int value)
    {
        this.score += value;
        scoreText.text = "" + score; //更新UI的文字
        //Debug.Log("得分为：" + score);
        PlayerPrefs.SetInt("CurrentScore",this.score);
    }

}
