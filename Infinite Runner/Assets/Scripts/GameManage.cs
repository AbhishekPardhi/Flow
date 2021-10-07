using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static float x_Velocity = 15.0f;
    public static int fixedKillDistance = -15;

    private float m_Timer;
    [SerializeField] private Transform backBlackHole;
    public static float width = 0.0f;

    void Update() {
        pulsating();

        //backBlackHole.position += Vector3.right * 0.2f * Time.deltaTime;
    }

    void pulsating() {
        m_Timer += Time.deltaTime;
        if(m_Timer > 4)
            m_Timer = m_Timer - 4;
        float sine = (float)(Mathf.Sin(4*m_Timer)/2);
        width = sine*sine;
    }
}
