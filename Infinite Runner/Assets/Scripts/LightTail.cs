using UnityEngine;

public class LightTail : MonoBehaviour
{
    private LineRenderer lr;
    [SerializeField] private Vector3 startPoint;
    [SerializeField] private Vector3 endPoint;

    void Start() {
        lr = GetComponent<LineRenderer>();
    }

    void Update() {
        applyVelocity();
        destroyTail();
        pulsating();
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
}
