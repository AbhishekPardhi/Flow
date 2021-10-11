using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D play;
    public Rigidbody2D options;
    public Rigidbody2D quit;
    public float x=1f;
    public float y = 1f;
    public Fade fade;
    public AudioMixer audioMixer;
    void Start()
    {
        giverandomvel(play);
        giverandomvel(options);
        giverandomvel(quit);
        audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("Volume", 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void giverandomvel(Rigidbody2D rig)
    {
        Vector3 vec = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        vec.Normalize();
        float vel = Random.Range(30, x);
        rig.velocity = vel * vec;
        rig.angularVelocity = y * vel;
    }
    public void Play()
    {
        fade.FadeOut(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void VolumeControl(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
        audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("Volume", 0));
    }
    public void LowSensi()
    {
        PlayerPrefs.SetFloat("Sensitivity", 0f);
    }
    public void MedSensi()
    {
        PlayerPrefs.SetFloat("Sensitivity", 0.5f);
    }
    public void HighSensi()
    {
        PlayerPrefs.SetFloat("Sensitivity", 1f);
    }
}
