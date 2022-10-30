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

        Vector3 cherryVectorRight = new Vector3(80.0f, 0.0f, 0.0f);
        Vector3 cherryVectorLeft = new Vector3(-80.0f, 0.0f, 0.0f);
        origPos = transform.position;
        elapsedTime = 0.0f;

        if (transform.position.x < 0) {
            targetPos = transform.position + cherryVectorRight;
        } else {
            targetPos = transform.position + cherryVectorLeft;
        }

    }

    void Update() {
          transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
          elapsedTime += Time.deltaTime;

          if (elapsedTime > timeToMove) {
              Destroy(gameObject);
          }

    }

    protected virtual void Eat() {
        FindObjectOfType<GameManager>().CherryEaten(this);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman")) {
            Debug.Log("cherry eaten");
            Eat();
        } else {
            Debug.Log("cherry collided but not with pacman");
        }
    }

}
