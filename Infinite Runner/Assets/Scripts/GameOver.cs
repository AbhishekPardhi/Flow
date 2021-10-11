using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Fade fade;
    public Text text;
    public Text high;
    public AudioClip gameover;
    public AudioClip noice;
    public AudioSource source;
    public void RestartButton()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        fade.FadeOut(1);
    }
    public void MainMenuButton()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        fade.FadeOut(0);
    }
    private void Awake()
    {
        text.text = "SCORE : " + PlayerPrefs.GetInt("Score", 0);
        if (PlayerPrefs.GetInt("Score", 0) == PlayerPrefs.GetInt("HighScore", 0))
        {
            high.enabled = true;
            source.clip = noice;
            source.Play();
        }
        else
        {
            high.enabled = false;
            source.clip = gameover;
            source.Play();
        }
    }
}
