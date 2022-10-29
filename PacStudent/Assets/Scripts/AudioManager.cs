using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source1;
    public AudioSource source2;
    public AudioClip bgm;
    public AudioClip ghostbgm;
    // Start is called before the first frame update
    void Start()
    {
        source1.PlayOneShot(bgm);
    }

    // Update is called once per frame
    void Update()
    {
        while ((!(source1.isPlaying)) && (!(source2.isPlaying))) {
          source2.PlayOneShot(ghostbgm);
        }
    }
}
