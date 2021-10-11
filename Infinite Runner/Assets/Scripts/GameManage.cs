using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static float x_Velocity = 15.0f;
    public static int fixedKillDistance = -15;
    public static bool playerDeath = false;
    public static int playerHealth = 100;

    public static float screenRoof = 4.5f;
    public static float screenFloor = -4.5f;

    public static bool playerShield = false;
    public static int level = 1;

    public static float spawnRate = 1f;

    private float m_Timer;
    [SerializeField] private Transform backBlackHole;
    [SerializeField] private GameObject pShield;
    [SerializeField] private ObstacleManager obManage;
    public static float width = 0.0f;
    public Fade fade;

    private float mm_Timer;

    private void Awake()
    {
        playerDeath = false;
        
        playerHealth = 100;
        playerShield = false;

        level = 1;
        x_Velocity = 10f;
        spawnRate = 1f;
    }
    void Update() {
        mm_Timer += Time.deltaTime;
        if(level < 5 && mm_Timer > 45) {
            mm_Timer = 0;
            level++;
            difficultyChange(level);
        }
        pulsating();
        if(!playerDeath) {
            shield();
        }
        if (playerDeath)
        {
            Invoke("GameOver", 2f);
        }
    }
    public void GameOver()
    {
        fade.FadeOut(2);
    }

    void pulsating() {
        m_Timer += Time.deltaTime;
        if(m_Timer > 4)
            m_Timer = m_Timer - 4;
        float sine = (float)(Mathf.Sin(4*m_Timer)/2);
        width = sine*sine;
    }

    void shield() {
        if(playerShield != pShield.activeSelf) {
            pShield.SetActive(playerShield);
        }
    }

    void difficultyChange(int level) {
        obManage.changeDifficulty();
        switch(level) {
            case 2: x_Velocity = 12.5f;
            spawnRate = 0.9f;
            break;

            case 3: x_Velocity = 15f;
            spawnRate = 0.8f;
            break;

            case 4: x_Velocity = 17f;
            spawnRate = 0.7f;
            break;

            case 5: x_Velocity = 20f;
            spawnRate = 0.55f;
            break;
        }
    }
}
