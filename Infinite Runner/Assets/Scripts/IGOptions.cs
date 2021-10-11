using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGOptions : MonoBehaviour
{
    // Start is called before the first frame update
    public Fade fade;
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
}
