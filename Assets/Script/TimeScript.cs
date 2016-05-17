using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;


public class TimeScript : MonoBehaviour {

    private float time = 300;
    private int endTime = 300;
    public Text op;
    public Text goal;
    public Text start;
    public GameObject OpoQ;

	void Start () {

		//float型からint型へCastし、String型に変換して表示
		GetComponent<Text>().text = "Time Limit : " + ((int)time).ToString();
        OpoQ.GetComponent<Renderer>().enabled = false;

	}
	
	void Update () {

		//1秒に1ずつ減らしていく
        time = endTime - (int)Time.time;
		//マイナスは表示しない
		if (time < 0) time = 0;
        GetComponent<Text>().text = "Time Limit : " + ((int)time).ToString();
        if (time < 295)
        {
            goal.enabled = false;
            start.enabled=false;
            OpoQ.GetComponent<Renderer>().enabled = true;
        }
        else if(time<290)
            op.enabled = false;


	}
}
