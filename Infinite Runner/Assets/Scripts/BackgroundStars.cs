using UnityEngine;

public class BackgroundStars : MonoBehaviour
{
    ParticleSystem ps;

    void Start() {
        ps = GetComponent<ParticleSystem>();
    }

    void Update() {
        if(GameManage.playerDeath) {
            ps.Pause();
        }
    }
}
