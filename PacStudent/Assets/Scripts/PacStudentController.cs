using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private bool isMoving;
    int lastInput = 0;
    int currentInput = 0;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.4f;

    Vector3 PacVectorUp;
    Vector3 PacVectorDown;
    Vector3 PacVectorLeft;
    Vector3 PacVectorRight;

    public LayerMask walls;

    private Animator anim;

    void Start() {

      PacVectorUp = new Vector3(0.0f, 2.0f, 0.0f);
      PacVectorDown = new Vector3(0.0f, -2.0f, 0.0f);
      PacVectorLeft = new Vector3(-2.0f, 0.0f, 0.0f);
      PacVectorRight = new Vector3(2.0f, 0.0f, 0.0f);

      anim = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            currentInput = 1;
        }
        if (Input.GetKey(KeyCode.A)) {
            currentInput = 2;
        }
        if (Input.GetKey(KeyCode.S)) {
            currentInput = 3;
        }
        if (Input.GetKey(KeyCode.D)) {
            currentInput = 4;
        }

        if (currentInput == 1) {
            if(!Physics2D.OverlapCircle(transform.position + PacVectorUp, 0.2f, walls)) {
                lastInput = 1;
            }
        }
        if (currentInput == 2) {
            if(!Physics2D.OverlapCircle(transform.position + PacVectorLeft, 0.2f, walls)) {
                lastInput = 2;
            }
        }
        if (currentInput == 3) {
            if(!Physics2D.OverlapCircle(transform.position + PacVectorDown, 0.2f, walls)) {
                lastInput = 3;
            }
        }
        if (currentInput == 4) {
            if(!Physics2D.OverlapCircle(transform.position + PacVectorRight, 0.2f, walls)) {
                lastInput = 4;
            }
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

            if(lastInput == 1 && isMoving) {
                anim.Play("Up", 0, 0.0f);
            }
            if(lastInput == 2 && isMoving) {
                anim.Play("Left", 0, 0.0f);
            }
            if(lastInput == 3 && isMoving) {
                anim.Play("Down", 0, 0.0f);
            }
            if(lastInput == 4 && isMoving) {
                anim.Play("Right", 0, 0.0f);
            }

            if(!Physics2D.OverlapCircle(targetPos, 0.1f, walls)){
                while (elapsedTime < timeToMove) {
                    transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
            }
        isMoving = false;
        yield return null;
    }
}
