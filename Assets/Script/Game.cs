using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class Game : MonoBehaviour
{
    private int playTime = 300;      //現在のプレイ時間
    private static int endTime = 300;       //終了時間

    public Text text;
    public GameObject player;
    public Text RestartText;

    bool good = false;
    bool bad = false;
    bool reset = false;
    Rigidbody rigid;
    AudioSource audioSource;

    void Start()
    {
        rigid = player.gameObject.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    

    void Update()
    {
        playTime = endTime - (int)Time.time;
        Debug.Log(playTime);
        CheckTime();
        if(good&&bad)
        {
            Application.LoadLevel("Start");
        }

        if (good)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Application.LoadLevel("Start");
                reset = true;
            }
            GoodEnd();
        }

        if(bad)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Application.LoadLevel("Start");
                reset = true;
            }
            BadEnd();
        }

        if(reset)
        {
            Reset();
        }
    }


    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            good = true;
            audioSource.Play();
        }
    }

    public void CheckTime()
    {
        if (playTime < 0)
        {
            bad = true;
        }
    }

    public void BadEnd()
    {
        text.color = Color.blue;
        text.text = "GAME OVER";
        RestartText.color = Color.green;
        RestartText.text = "It will return to the start scene with the space key.";
        rigid.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void GoodEnd()
    {
        int Score = playTime;
        text.color = Color.yellow;
        text.text = "CLEAR!!";
        RestartText.color = Color.yellow;
        RestartText.text = "It will return to the start scene with the space key.";
        
    }

    public void Reset()
    {
        Debug.Log("Reset");
        playTime = 300;
        endTime = 300;
        this.transform.position = new Vector3(45, 0, -45);
        rigid.constraints = RigidbodyConstraints.None;
        good = false;
        bad = false;
        reset = false;
        Vector3 g = new Vector3(0, -10, 0);
        Physics.gravity = g;
    }
}
