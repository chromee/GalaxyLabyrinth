using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class H_timeScript : MonoBehaviour {

    private float time = 300;
    private int endTime = 300;
    public Text op;
    public Text start;


	void Start () {
        //float型からint型へCastし、String型に変換して表示
        GetComponent<Text>().text = "Time Limit : " + ((int)time).ToString();
	}
	

	void Update () {
        //1秒に1ずつ減らしていく
        time = endTime - (int)Time.time;
        //マイナスは表示しない
        if (time < 0) time = 0;
        GetComponent<Text>().text = "Time Limit : " + ((int)time).ToString();
        if (time < 295)
        {
            start.enabled = false;
        }
        else if (time < 290)
            op.enabled = false;
	}
}
