using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleAnimation : MonoBehaviour
{

    public Image startImage;
    public Sprite[] spriteArray;

    public float frameSpeed = 0.5f;

    private int spriteIndex;
    Coroutine animate;

    void Start() {

        playAnim();

    }

    public void playAnim() {
        StartCoroutine(startAnim());
    }

    IEnumerator startAnim() {

        yield return new WaitForSeconds(frameSpeed);
        if (spriteIndex >= spriteArray.Length) {
            spriteIndex = 0;
        }
        startImage.sprite = spriteArray[spriteIndex];
        spriteIndex += 1;
        StartCoroutine(startAnim());
    }

}
