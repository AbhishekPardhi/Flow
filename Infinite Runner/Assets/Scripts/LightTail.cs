using UnityEngine;

public class LightTail : MonoBehaviour
{
    private LineRenderer lr;
    [SerializeField] private Vector3 startPoint;
    [SerializeField] private Vector3 endPoint;

    private float alpha = 1f;
    private float speed = 1f;

    void Start() {
        lr = GetComponent<LineRenderer>();
    }

    void Update() {
        applyVelocity();
        destroyTail();
        pulsating();
        if(GameManage.playerDeath) {
            fadeAway();
        }
        lr.SetPosition(0, startPoint);
        lr.SetPosition(1, endPoint);
    }

    public void setEndPoint(Vector3 endPoint) {
        this.endPoint = endPoint;
    }

    public void setStartPoint(Vector3 startPoint) {
        this.startPoint = startPoint;
    }

    void applyVelocity() {
        startPoint = startPoint + Vector3.left * GameManage.x_Velocity*Time.deltaTime;
        endPoint = endPoint + Vector3.left * GameManage.x_Velocity*Time.deltaTime;
    }

    void destroyTail() {
        if(startPoint.x < GameManage.fixedKillDistance && endPoint.x < GameManage.fixedKillDistance)
            Destroy(gameObject);
    }

    void pulsating() {
        lr.startWidth = GameManage.width + 0.2f;
        lr.endWidth = GameManage.width + 0.2f;
    }

    void fadeAway() {
        alpha -= Time.deltaTime * speed;
        Color start = Color.white;
        start.a = alpha;
        lr.startColor = start;
        lr.endColor = start;
    }
}
