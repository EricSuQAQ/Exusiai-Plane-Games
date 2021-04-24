using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    //public GameObject exusiai;
    // Start is called before the first frame update
    public AudioSource[] musicGroup;
    void Start()
    {
        //Debug.Log("准备生成阿能");
        /*
        Application.targetFrameRate = 60;
        GameObject newPlayer = Instantiate(exusiai);
        newPlayer.transform.position = new Vector3 (0,-4f,0);
        */

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void failMusic()
    {
        AudioSource music = this.musicGroup[0];
        music.PlayOneShot(music.GetComponent<AudioSource>().clip);
        AudioSource aneng = this.musicGroup[1];
        aneng.PlayOneShot(aneng.GetComponent<AudioSource>().clip);
    }

}
