using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yuyinbao : MonoBehaviour
{
    public AudioSource[] musicGroup;
    public AudioSource attack;
    public AudioSource overAttack;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void attackAudio()
    {
        AudioSource music = attack;
        music.PlayOneShot(music.GetComponent<AudioSource>().clip);
    }

    void overAttackAudio()
    {
        AudioSource music = overAttack;
        music.PlayOneShot(music.GetComponent<AudioSource>().clip);        
    }
    
    void overLoadFireMusic()
    {
        int index = Random.Range(1,musicGroup.Length);
        AudioSource music = this.musicGroup[index];
        music.PlayOneShot(music.GetComponent<AudioSource>().clip);
    }

    void yoo()
    {
        AudioSource music = this.musicGroup[0];
        music.PlayOneShot(music.GetComponent<AudioSource>().clip); 
    }
}
