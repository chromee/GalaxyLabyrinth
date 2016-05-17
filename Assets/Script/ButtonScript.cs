using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    public static bool mode = true;



    public void EasyButtonPush()
    {
        mode = true;
    }

    public void HardButtoPush()
    {
        mode = false;
    }

    public void SceneLoad()
    {
        if(mode)
        {
            Application.LoadLevel("EasyStage");
        }
        else
        {
            Application.LoadLevel("HardStage");
        }  
    }

}
