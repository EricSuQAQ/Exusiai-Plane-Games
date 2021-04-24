using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; //给IPointerDownHandler用的

public class ruleButton : MonoBehaviour,IPointerDownHandler
{
    public GameObject startButton,rankButton1,quitButton,ruleButton1;//显示菜单,排行，退出按钮
    public GameObject caidan;//菜单
    public GameObject inputButton; //输入框
    public GameObject title; //标题
    public GameObject ruleText;
    bool isshow = false;
    // Start is called before the first frame update
    void Start()
    {
        caidan.SetActive(isshow);
        quitButton.SetActive(isshow);   
        ruleText.SetActive(isshow);     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rankButton1.SetActive(false);
        ruleButton1.SetActive(false);
        startButton.SetActive(false);
        inputButton.SetActive(false);
        title.SetActive(false);

        quitButton.SetActive(true);
        ruleText.SetActive(true);
    }
}
