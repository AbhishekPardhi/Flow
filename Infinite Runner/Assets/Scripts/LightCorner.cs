using UnityEngine;

public class LightCorner : MonoBehaviour
{

    private SpriteRenderer render;
    private float pulsate_width = 3.0f;
    private float alpha = 1f;
    private float speed = 1f;

    void Start() {
        render = GetComponent<SpriteRenderer>();
    }

    void Update() {
        transform.position += Vector3.left * Time.deltaTime * GameManage.x_Velocity;
        transform.localScale = new Vector3(2.5f + GameManage.width*pulsate_width, 2.5f + GameManage.width*pulsate_width, 0);
        if(transform.position.x < GameManage.fixedKillDistance)
            Destroy(gameObject);
        
        if(GameManage.playerDeath) {
            fadeAway();
        }
    }

    void fadeAway() {
        alpha -= Time.deltaTime * speed;
        Color start = Color.white;
        start.a = alpha;
        render.color = start;
    }
}
