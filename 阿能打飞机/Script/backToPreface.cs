using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; //给IPointerDownHandler用的

public class backToPreface : MonoBehaviour,IPointerDownHandler
{
    public GameObject startButton,rankButton1,cleanButton,quitButton,ruleButton1;//显示菜单,排行，退出按钮
    public GameObject caidan;//菜单
    public GameObject inputButton; //输入框
    public GameObject title; //标题
    public GameObject ruleText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rankButton1.SetActive(true);
        ruleButton1.SetActive(true);
        startButton.SetActive(true);
        inputButton.SetActive(true);
        title.SetActive(true);

        quitButton.SetActive(false);
        ruleText.SetActive(false);
        caidan.SetActive(false);
        cleanButton.SetActive(false);
    }
}
