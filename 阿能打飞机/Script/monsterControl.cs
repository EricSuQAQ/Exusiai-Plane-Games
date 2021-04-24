using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterControl : MonoBehaviour
{
    public GameObject monsterPreFab;
    public Sprite[] images;
    public float timer;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateMonster", 0.1f,1f);//(执行方法，第一次延迟，每次执行的间隔)
        timer = 0;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 5)
        {
            if(count < 5)
            {
                InvokeRepeating("CreateMonster", 0.1f,30f);
            }
            else if(count <= 25)
            {
                Time.timeScale += 0.1f;
                //float k = Time.timeScale;
                //Debug.Log("当前游戏速度为：" + k);
            }
            timer = 0;
            count += 1;
        }

    }

    private void CreateMonster()
    {
        float x = Random.Range(-2000,2000);
        x = x/1000;
        float y = 5;
        GameObject monster = Instantiate(monsterPreFab);
        monster.transform.position = new Vector3(x,y,0);

        int index = Random.Range(0,images.Length);
        SpriteRenderer renderer = monster.GetComponent<SpriteRenderer>();
        renderer.sprite = this.images[index];
    }
}
