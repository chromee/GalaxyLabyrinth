using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {

    AudioSource audioSource;

	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayDelayed(1);
	}
}
