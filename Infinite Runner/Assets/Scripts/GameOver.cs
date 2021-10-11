using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
  public void RestartButton()
  {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
  }
   public void MainMenuButton()
  {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
  }
}
