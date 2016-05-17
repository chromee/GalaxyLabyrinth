using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ModeScript : MonoBehaviour
{
    ButtonScript btn = new ButtonScript();

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            btn.EasyButtonPush();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            btn.HardButtoPush();
        }
        if(Input.GetKey(KeyCode.Space))
        {
            btn.SceneLoad();
        }
    }
}