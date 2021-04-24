using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dy = speed * Time.deltaTime;
        this.transform.Translate(0,-dy,0,Space.Self);
        Vector3 sp = Camera.main.WorldToScreenPoint(this.transform.position);
        if(sp.y < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag.Equals("player"))
        {
            Destroy(this.gameObject);
        }
    }
}
