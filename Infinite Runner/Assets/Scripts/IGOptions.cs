using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class IGOptions : MonoBehaviour
{
    // Start is called before the first frame update
    public Fade fade;
    public AudioMixer audioMixer;
    void Start()
    {
        fade = FindObjectOfType<Fade>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        fade.FadeOut(1);
    }
    public void MainMenu()
    {
        fade.FadeOut(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void TurnOnVolume()
    {
        audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("Volume")); 
    }
    public void TurnOffVolume()
    {
        audioMixer.SetFloat("Volume", -80);
    }
}
