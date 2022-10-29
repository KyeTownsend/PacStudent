using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public GameObject cherry;

    void Update() {

        int randomHeight = Random.Range(1, 30) * 2;
        Vector3 randomSpawn = new Vector3(transform.position.x, transform.position.y + randomHeight , transform.position.z);
        Instantiate(cherry, randomSpawn, Quaternion.identity);
    }

}
