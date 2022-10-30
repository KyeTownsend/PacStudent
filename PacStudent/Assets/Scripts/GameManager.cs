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
        Text scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        scoreText.text = this.score.ToString();
        this.score = score;
    }

    public void PelletEaten(Pellet pellet) {
        pellet.gameObject.SetActive(false);
        SetScore(this.score + 10);
        Debug.Log("parsed");
    }



}
