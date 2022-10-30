using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherrySpawner : MonoBehaviour
{
    public GameObject cherry;
    Vector3 randomSpawn;
    public float timer = 0.0f;

    void Update() {
        int randomHeight = Random.Range(0, 27) * 2;
        Vector3 randomSpawn = new Vector3(transform.position.x, transform.position.y + randomHeight , 0);

        timer += Time.deltaTime;
        if (timer >= 10.0f) {
            Instantiate(cherry, randomSpawn, Quaternion.identity);
            timer = 0.0f;
        }

    }


}
