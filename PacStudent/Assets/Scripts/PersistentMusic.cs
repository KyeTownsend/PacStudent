using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentMusic : MonoBehaviour
{

    private AudioSource BGM;

    private void Awake() {
      DontDestroyOnLoad(transform.gameObject);
       BGM = GetComponent<AudioSource>();
    }

    public void MusicActive()
     {
         if (BGM.isPlaying) return;
         BGM.Play();
     }
}
