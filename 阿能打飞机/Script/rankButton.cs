using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; //给IPointerDownHandler用的

public class rankButton : MonoBehaviour,IPointerDownHandler
{
    public GameObject startButton,rankButton1,quitButton,cleanButton,ruleButton;//显示菜单,排行，退出按钮
    public GameObject caidan;//菜单
    public GameObject inputButton; //输入框
    public GameObject title; //标题
    bool isshow = false;

    public Text firstScore,secondScore,thirdScore;
    // Start is called before the first frame update
    void Start()
    {
        caidan.SetActive(isshow);
        cleanButton.SetActive(isshow);
        quitButton.SetActive(isshow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rankButton1.SetActive(false);
        ruleButton.SetActive(false);
        quitButton.SetActive(true);
        caidan.SetActive(true);
        cleanButton.SetActive(true);
        startButton.SetActive(false);
        inputButton.SetActive(false);
        title.SetActive(false);

        //Debug.Log("第一名得分：" + PlayerPrefs.GetInt("firstScore"));
        //Debug.Log("第二名得分：" + PlayerPrefs.GetInt("secondScore"));
        //Debug.Log("第三名得分：" + PlayerPrefs.GetInt("thirdScore"));

        if(PlayerPrefs.GetInt("firstScore") != 0)
        {
            firstScore.text = "1. " + PlayerPrefs.GetString("firstPlayer") + "  " + PlayerPrefs.GetInt("firstScore") + " 分";
        }
        //Debug.Log("第一名更迭执行完毕");

        if(PlayerPrefs.GetInt("secondScore") != 0)
        {
            secondScore.text = "2. " + PlayerPrefs.GetString("secondPlayer") + "  " + PlayerPrefs.GetInt("secondScore") + " 分";
        }
        //Debug.Log("第二名更迭执行完毕");

        if(PlayerPrefs.GetInt("thirdScore") != 0)
        {
            thirdScore.text = "3. " + PlayerPrefs.GetString("thirdPlayer") + "  " + PlayerPrefs.GetInt("thirdScore") + " 分";
        }
        //Debug.Log("第三名更迭执行完毕");
        
    }
}
