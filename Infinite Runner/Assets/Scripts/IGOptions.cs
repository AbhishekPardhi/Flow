using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class IGOptions : MonoBehaviour
{
    // Start is called before the first frame update
    public Fade fade;
    public AudioMixer audioMixer;
    public AudioSource asource;
    public AudioClip t1;
    public AudioClip t2;
    void Start()
    {
        fade = FindObjectOfType<Fade>();
        audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("Volume",0));
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
    private void changeToT1()
    {
        asource.clip = t1;
        Invoke(nameof(changeToT2), asource.clip.length);
    }
    private void changeToT2()
    {
        asource.clip = t2;
        Invoke(nameof(changeToT1), asource.clip.length);
    }
}
