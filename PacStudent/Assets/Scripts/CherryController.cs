using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{

    private Vector3 origPos, targetPos;
    private float timeToMove = 7.5f;
    private float elapsedTime;
    Vector3 cherryVectorRight;
    Vector3 cherryVectorLeft;

    void Start() {

        Vector3 cherryVectorRight = new Vector3(60.0f, 0.0f, 0.0f);
        origPos = transform.position;
        elapsedTime = 0.0f;
        targetPos = transform.position + cherryVectorRight;

    }

    void Update() {
          transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
          elapsedTime += Time.deltaTime;
    }

}
