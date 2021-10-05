using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static float x_Velocity = 15.0f;
    public static int fixedKillDistance = -15;

    private float m_Timer;
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
