using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int score { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        SetScore(0);
    }

    private void SetScore(int score) {
        this.score = score;
        Text scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        scoreText.text = ("Score: " + this.score.ToString());
    }

    public void PelletEaten(Pellet pellet) {
        pellet.gameObject.SetActive(false);
        SetScore(this.score + 10);
        Debug.Log("parsed pellet eaten");
    }

    public void CherryEaten(CherryController cherry) {
        cherry.gameObject.SetActive(false);
        SetScore(this.score + 100);
        Debug.Log("parsed cherry eaten");
    }

}
