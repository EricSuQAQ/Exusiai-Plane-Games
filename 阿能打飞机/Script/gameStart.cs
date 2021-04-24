using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour
{
    public InputField userName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            //Debug.Log("回车键已经被按下");
            SceneManager.LoadScene("游戏过程");
            string user = userName.text;
            PlayerPrefs.SetString("current",user);
        }
    }
}
