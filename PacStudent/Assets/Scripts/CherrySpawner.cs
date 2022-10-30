using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherrySpawner : MonoBehaviour
{
    public GameObject cherry;
    Vector3 randomSpawn;
    public float timer = 0.0f;
    public float timeToSpawn = 10.0f;
    public int side = 0;

    void Update() {

        int side = Random.Range(0, 2);

        if (side == 0) {
            transform.position = new Vector3(-45.0f, transform.position.y, transform.position.z);
        } else {
            transform.position = new Vector3(35.0f, transform.position.y, transform.position.z);
        }

        int randomHeight = Random.Range(0, 27) * 2;
        Vector3 randomSpawn = new Vector3(transform.position.x, transform.position.y + randomHeight , 0);

        timer += Time.deltaTime;
        if (timer >= timeToSpawn) {
            Instantiate(cherry, randomSpawn, Quaternion.identity);
            timer = 0.0f;
        }

    }


}
