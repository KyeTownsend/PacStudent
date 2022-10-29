using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private bool isMoving;
    int currentInput = 0;
    int lastInput = 0;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.4f;

    Vector3 PacVectorUp;
    Vector3 PacVectorDown;
    Vector3 PacVectorLeft;
    Vector3 PacVectorRight;

    public LayerMask walls;

    private Animator anim;

    public AudioSource AudioSource;
    public AudioClip movingSFX;

    public ParticleSystem walk;

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

        if (lastInput == 1) {
            if(!Physics2D.OverlapCircle(transform.position + PacVectorUp, 0.2f, walls)) {
                currentInput = 1;
            }
        }
        if (lastInput == 2) {
            if(!Physics2D.OverlapCircle(transform.position + PacVectorLeft, 0.2f, walls)) {
                currentInput = 2;
            }
        }
        if (lastInput == 3) {
            if(!Physics2D.OverlapCircle(transform.position + PacVectorDown, 0.2f, walls)) {
                currentInput = 3;
            }
        }
        if (lastInput == 4) {
            if(!Physics2D.OverlapCircle(transform.position + PacVectorRight, 0.2f, walls)) {
                currentInput = 4;
            }
        }

        if (currentInput == 1 && !isMoving) {
            StartCoroutine(MovePlayer(PacVectorUp));
        }
        if (currentInput == 2 && !isMoving) {
            StartCoroutine(MovePlayer(PacVectorLeft));
        }
        if (currentInput == 3 && !isMoving) {
            StartCoroutine(MovePlayer(PacVectorDown));
        }
        if (currentInput == 4 && !isMoving) {
            StartCoroutine(MovePlayer(PacVectorRight));
        }
    }

    void Walk() {
        walk.Play();
    }

    private IEnumerator MovePlayer(Vector3 Direction) {

            isMoving = true;

            float elapsedTime = 0;

            origPos = transform.position;
            targetPos = origPos + Direction;

            if(currentInput == 1 && isMoving) {
                anim.Play("Up", 0, 0.0f);
            } else {
                AudioSource.Stop();
                walk.Stop();
            }

            if(currentInput == 2 && isMoving) {
                anim.Play("Left", 0, 0.0f);
            } else {
                AudioSource.Stop();
                walk.Stop();
            }

            if(currentInput == 3 && isMoving) {
                anim.Play("Down", 0, 0.0f);
            } else {
                AudioSource.Stop();
                walk.Stop();
            }

            if(currentInput == 4 && isMoving) {
                anim.Play("Right", 0, 0.0f);
            } else {
                AudioSource.Stop();
                walk.Stop();
            }


            if(!Physics2D.OverlapCircle(targetPos, 0.1f, walls)){
                while (elapsedTime < timeToMove) {
                    transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
                    elapsedTime += Time.deltaTime;
                    yield return null;
                    if (!AudioSource.isPlaying) {
                        AudioSource.Play();
                  }
                    walk.Play();
                }
            }
        isMoving = false;
        yield return null;
    }
}
