using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private bool isMoving;
    int lastInput = 0;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.4f;

    Vector3 PacVectorUp;
    Vector3 PacVectorDown;
    Vector3 PacVectorLeft;
    Vector3 PacVectorRight;


    void Start() {

      PacVectorUp = new Vector3(0.0f, 2.0f, 0.0f);
      PacVectorDown = new Vector3(0.0f, -2.0f, 0.0f);
      PacVectorLeft = new Vector3(-2.0f, 0.0f, 0.0f);
      PacVectorRight = new Vector3(2.0f, 0.0f, 0.0f);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            lastInput = 1;
        }
        if (Input.GetKey(KeyCode.A)) {
            lastInput = 2;
        }
        if (Input.GetKey(KeyCode.S)) {
            lastInput = 3;
        }
        if (Input.GetKey(KeyCode.D)) {
            lastInput = 4;
        }

        if (lastInput == 1 && !isMoving) {
            StartCoroutine(MovePlayer(PacVectorUp));
        }
        if (lastInput == 2 && !isMoving) {
            StartCoroutine(MovePlayer(PacVectorLeft));
        }
        if (lastInput == 3 && !isMoving) {
            StartCoroutine(MovePlayer(PacVectorDown));
        }
        if (lastInput == 4 && !isMoving) {
            StartCoroutine(MovePlayer(PacVectorRight));
        }
    }

    private IEnumerator MovePlayer(Vector3 Direction) {

        isMoving = true;

        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + Direction;

        while (elapsedTime < timeToMove) {

            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;

    }

}
