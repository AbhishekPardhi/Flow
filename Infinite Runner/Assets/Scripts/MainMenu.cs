using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D play;
    public Rigidbody2D options;
    public Rigidbody2D quit;
    public float x=1f;
    public float y = 1f;
    public Fade fade;
    void Start()
    {
        giverandomvel(play);
        giverandomvel(options);
        giverandomvel(quit);
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
}
