using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class clean : MonoBehaviour,IPointerDownHandler
{
    public Text firstPlayer,secondPlayer,thirdPlayer;
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
        PlayerPrefs.DeleteAll();
        firstPlayer.text = "第一名暂空";
        secondPlayer.text = "第二名暂空";
        thirdPlayer.text = "第三名暂空";
     }
}
