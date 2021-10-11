using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using Lean.Common;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool newhighscore=false;
    public int score;
    public GameObject leanpulse;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0) && newhighscore==false)
        {
            newhighscore = true;
            //leanpulse.GetComponent<refe>
        }
    }
}
