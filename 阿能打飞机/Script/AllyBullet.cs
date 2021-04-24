using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AllyBullet : MonoBehaviour
{
    public float speed = 5.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dy = speed * Time.deltaTime;
        this.transform.Translate(0,dy,0,Space.Self);
        Vector3 sp = Camera.main.WorldToScreenPoint(this.transform.position);
        if(sp.y > Screen.height)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag.Equals("monster"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            GameObject main = GameObject.Find("游戏主控"); //寻找主控组件，旗下含有部分脚本。
            //方法1：消息调用：
            //main.SendMessage("addScore",1); //将消息调用至该组件下，寻找function调用。

            //方法2：寻找组件然后调用：
            gameScore myGame = main.GetComponent<gameScore>();//将gameScore脚本调出，并赋予变量myGame脚本的执行力。
            myGame.addScore(1);//将addScore视为内部函数进行调用。
            
        }
    }
}
