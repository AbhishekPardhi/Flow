using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using Lean.Common;
using TMPro;

namespace Lean.Gui
{
    public class ScoreManager : MonoBehaviour
    {
        // Start is called before the first frame update
        private bool newhighscore = false;
        public int score;
        public float sc;
        public int highscore;
        public LeanPulse leanpulse;
        public TMP_Text scoreText;
        void Start()
        {
            scoreText.text = "0";
        }

        // Update is called once per frame
        void Update()
        {
            if (score > PlayerPrefs.GetInt("HighScore", 0) && newhighscore == false)
            {
                newhighscore = true;
                leanpulse.Pulse();
            }
            highscore = PlayerPrefs.GetInt("HighScore", 0);
            score = Mathf.FloorToInt(sc);
            scoreText.text = "" + score;
            if (!GameManage.playerDeath) sc += Time.deltaTime * 2;
            else
            {
                PlayerPrefs.SetInt("Score", score);
                if(score > PlayerPrefs.GetInt("HighScore", 0)) PlayerPrefs.SetInt("HighScore", score);
            }
        }
    }
}