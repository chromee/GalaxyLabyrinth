﻿using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        //ゴールを回転させる
        transform.Rotate(new Vector3(1, 1, 1));
	}
    

}