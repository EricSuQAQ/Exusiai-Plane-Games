using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour,IPointerDownHandler
{
    public InputField userName;

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
        SceneManager.LoadScene("游戏过程");
        string user = userName.text;
        PlayerPrefs.SetString("current",user);
    }


}
