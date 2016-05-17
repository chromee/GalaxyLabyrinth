  using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GravityController : MonoBehaviour {

    public Text UpperText;
    public Text LowerText;

    void OnTriggerStay(Collider other)
    {

        if(other.gameObject.name == "LowerWarp")
        {

            if (Input.GetKey(KeyCode.Space))
            {
                Vector3 g = new Vector3(0, 10, 0);
                Physics.gravity = g;
                UpperText.text = "Current Stage";
                UpperText.fontSize = 50;
                UpperText.color = Color.yellow;
                LowerText.text = "Lower Stage";
                LowerText.fontSize = 25;
                LowerText.color = Color.white;
            }
        }

        if(other.gameObject.name == "UpperWarp")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Vector3 g = new Vector3(0, -10, 0);
                Physics.gravity = g;
                UpperText.text = "Upper Stage";
                UpperText.fontSize = 25;
                UpperText.color = Color.white;
                LowerText.fontSize = 50;
                LowerText.color = Color.yellow;
                LowerText.text = "Current Stage";
            }

        }
    }
}
