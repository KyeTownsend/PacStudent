using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class HUDManager : MonoBehaviour
{

  public GameObject scared;

  void Start() {
      scared.SetActive(false);
  }

  public void ExitGame() {
      SceneManager.LoadScene("StartScene");
  }
}
