using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 
using UnityEngine.SceneManagement;

public class Exusiai : MonoBehaviour
{
    public GameObject whiteBullet;
    private float timer,attackCount,speedAttack,duration;
    public int hp;
    public GameObject endManue;
    public Text finalText;
    public Sprite original, onOverload;
    private bool check;
    public Text hpText;
    //public GameObject caidan,returnButton,quitButton;//结尾菜单
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(0, -4f, 0);
        timer = 10;
        speedAttack = 1;
        attackCount = 0;
        duration = 0;
        hp = 10;
        check = false;
        /*
        caidan.SetActive(false);
        returnButton.SetActive(false);
        quitButton.SetActive(false);
        */

    /*
        string userName = PlayerPrefs.GetString("current");
        Debug.Log(userName);
    
        int firstScore = PlayerPrefs.GetInt("firstScore");
        string firstPlayer = PlayerPrefs.GetString("firstPlayer");
        Debug.Log("第一名得分是：" + firstScore);
        Debug.Log("第一名名字是：" + firstPlayer);
    */
    }

    // Update is called once per frame
    void Update()
    {
        exusiaiMove();
        timer += Time.deltaTime;
        attackCount += Time.deltaTime;

        if(attackCount >= speedAttack)
        {
            Fire();
            attackCount = 0;
        }

        if(timer >= 20 && check == false)
        {
            //阿能头上的技能转好了，可以释放过载模式
            if(SceneManager.GetActiveScene().name == "游戏过程")
            {
                SpriteRenderer renderer = this.GetComponent<SpriteRenderer>();
                renderer.sprite = this.onOverload;
            }
            

        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(timer >= 20 && SceneManager.GetActiveScene().name == "游戏过程")
            {
                check = true;
                overLoadFire();
                SpriteRenderer renderer = this.GetComponent<SpriteRenderer>();
                renderer.sprite = this.original;
                timer = 0;
            }
            else if (timer >= 1 && timer < 20)
            {
                Debug.Log("过载模式冷却中：" + (int)(timer) + "/20");
            }
        }
        if(speedAttack == 0.1f || duration != 0)
        {
            duration += Time.deltaTime;
            //Debug.Log(duration);
            if(duration >= 3)
            {
                speedAttack = 1f;
                //Debug.Log("过载模式关闭");
                duration = 0;
                check = false;
            }

        }
        
    }

    private void Fire()
    {
        if(SceneManager.GetActiveScene().name == "游戏过程")
        {
            GameObject bullet = Instantiate(whiteBullet);
            bullet.transform.position = this.transform.position + 1 * this.transform.up;
            if(check == false)//尚未开启过载模式
            {
                GameObject music = GameObject.Find("阿能语音包");
                music.SendMessage("attackAudio");           
            }
        }
    }

    private void overLoadFire()
    {
        //Debug.Log("过载模式启动！");
        GameObject music = GameObject.Find("阿能语音包");
        music.SendMessage("overLoadFireMusic");
        music.SendMessage("overAttackAudio"); 
        speedAttack = 0.1f;
    }

    private void exusiaiMove()
    {
        float step = 5f * Time.deltaTime;
        if(Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x >= -2.5)
        {
            this.transform.Translate(-step,0,0);
        }
        if(Input.GetKey(KeyCode.UpArrow) && this.transform.position.y <= 4)
        {
            this.transform.Translate(0,step,0);
        }
        if(Input.GetKey(KeyCode.DownArrow) && this.transform.position.y >= -4.5)
        {
            this.transform.Translate(0,-step,0);
        }
        if(Input.GetKey(KeyCode.RightArrow) && this.transform.position.x <= 2.5 )
        {
            this.transform.Translate(step,0,0);
        }
    } 

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag.Equals("enemyBullet"))
        {
            hp -= 1;
            Destroy(other.gameObject);
            hpText.text = "HP：" + hp;
            //Debug.Log("阿能被攻击！剩余血量：" + hp + "/10");
            if(hp > 0)
            {
                GameObject music = GameObject.Find("阿能语音包");
                music.SendMessage("yoo");
            }


        }
        if( hp <= 0)
        {
            Destroy(this.gameObject);
            Time.timeScale = 0f;
            /*
            caidan.SetActive(true);
            returnButton.SetActive(true);
            quitButton.SetActive(true);
            */

            //Debug.Log("阿能死了！");
            rank();
            endManue.SetActive(true);
            finalText.text = "" + PlayerPrefs.GetInt("CurrentScore");

            GameObject main = GameObject.Find("游戏主控"); 
            AudioSource audio = main.GetComponent<AudioSource>();
            audio.Stop();
            
            //AudioSource failAudio = this.GetComponent<AudioSource>();
            main.SendMessage("failMusic");
            //Debug.Log("成功播放：" + failAudio.name);
            
        }
    }

    private void rank()
    {
        int CurrentScore = PlayerPrefs.GetInt("CurrentScore");
        //Debug.Log("你的最终得分是：" + CurrentScore);
        if(CurrentScore > PlayerPrefs.GetInt("thirdScore"))
        {
            PlayerPrefs.SetInt("thirdScore",CurrentScore);
            PlayerPrefs.SetString("thirdPlayer",PlayerPrefs.GetString("current"));
            //Debug.Log("第三名更新完成");
        }

        if(CurrentScore > PlayerPrefs.GetInt("secondScore"))
        {
            //原第二变第三
            PlayerPrefs.SetInt("thirdScore",PlayerPrefs.GetInt("secondScore"));
            PlayerPrefs.SetString("thirdPlayer",PlayerPrefs.GetString("secondPlayer"));
            //玩家变成第二
            PlayerPrefs.SetInt("secondScore",CurrentScore);
            PlayerPrefs.SetString("secondPlayer",PlayerPrefs.GetString("current"));
            //Debug.Log("第二名更新完成");
        }

        if(CurrentScore > PlayerPrefs.GetInt("firstScore"))
        {
            //原第一变第二
            PlayerPrefs.SetInt("secondScore",PlayerPrefs.GetInt("firstScore"));
            PlayerPrefs.SetString("secondPlayer",PlayerPrefs.GetString("firstPlayer"));
            //玩家变成第一
            PlayerPrefs.SetInt("firstScore",CurrentScore);
            PlayerPrefs.SetString("firstPlayer",PlayerPrefs.GetString("current"));
            //Debug.Log("第一名更新完成");
        }

    }
}
