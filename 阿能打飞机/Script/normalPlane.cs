using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalPlane : MonoBehaviour
{
    private float speed = 1.0f;
    private float count;//,attackInterval;
    public GameObject redBullet;
    // Start is called before the first frame update
    void Start()
    {
        count = 2;
        //attackInterval = 4;
        //Debug.Log(attackInterval);
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if(count < 4 && count >= 0.5f)
        {
            float dy = speed* Time.deltaTime;
            this.transform.Translate(0,-dy,0,Space.Self);
        }
        else if(count >= 5)
        {
            enemyAttack();
            count = 0;
        }
        Vector3 sp = Camera.main.WorldToScreenPoint(this.transform.position);
        if(sp.y < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void enemyAttack()
    {
        //Debug.Log("敌方攻击！");
        GameObject bullet = Instantiate(redBullet);
        bullet.transform.position = this.transform.position - 1 * this.transform.up;
    }
}
