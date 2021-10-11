using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static float x_Velocity = 15.0f;
    public static int fixedKillDistance = -15;
    public static bool playerDeath = false;
    public static int playerHealth = 100;

    public static float screenRoof = 4f;
    public static float screenFloor = -4f;

    private float m_Timer;
    [SerializeField] private Transform backBlackHole;
    public static float width = 0.0f;

    void Update() {
        pulsating();
    }

    void pulsating() {
        m_Timer += Time.deltaTime;
        if(m_Timer > 4)
            m_Timer = m_Timer - 4;
        float sine = (float)(Mathf.Sin(4*m_Timer)/2);
        width = sine*sine;
    }
}
