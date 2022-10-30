using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    void Start()
    {
         GameObject.FindGameObjectWithTag("Music").GetComponent<PersistentMusic>().MusicActive();
    }

}
