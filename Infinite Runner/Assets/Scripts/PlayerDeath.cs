using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    Vector3 blackholeCenter;
    private Rigidbody2D rb;

    private bool isSucking = false;
    private bool isExploding = false;
    public AudioSource source;
    public AudioSource damage;
    public AudioClip blackhole;
    public AudioClip damage1;
    public AudioClip damage2;
    public AudioClip destroy;
    private float blackholeRotationSuck = 0.7f;
    
    [SerializeField] private GameObject deathParticlePrefab;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (!GameManage.playerDeath)
        { if (other.gameObject.tag == "blackhole") {
                GetComponent<LightMovement>().enabled = false;

                blackholeCenter = other.gameObject.transform.position;
                GameManage.x_Velocity = 0;
                GameManage.playerDeath = true;
                isSucking = true;
                source.clip = blackhole;
                source.Play();
            }
            else if (other.gameObject.tag == "opaque") {
                GetComponent<LightMovement>().enabled = false;

                GameManage.x_Velocity = 0;
                GameManage.playerDeath = true;
                isExploding = true;
                source.clip = destroy;
                source.Play();
            }
            else if (other.gameObject.tag == "translucent") {
                GameManage.playerHealth -= 20;
                int x = Random.Range(0, 2);
                if (x == 0) damage.clip = damage1;
                else damage.clip = damage2;
                damage.Play();
            }
            else if (other.gameObject.tag == "health pack") {
                GameManage.playerHealth = GameManage.playerHealth + 10 > 100 ? 100 : GameManage.playerHealth + 10;
            }
            else if (other.gameObject.tag == "shield pickup") {
                Debug.Log("help");
                GameManage.playerShield = true;
            }
        }
    }

    void Update() {
        if(isSucking) {
            blackHoleDeath();
        }
        else if(isExploding) {
            opaqueDeath();
        }
    }

    void blackHoleDeath() {
        Vector3 direc = transform.position - blackholeCenter;

        //Transform around spiral
        Quaternion smallDisp = Quaternion.AngleAxis(blackholeRotationSuck, Vector3.forward);
        direc = smallDisp * direc;
        rb.transform.position = blackholeCenter + direc * (1 - Time.deltaTime/1);
            
        //Rotate around blackhole

        float angle = Mathf.Atan2(direc.y, direc.x) * Mathf.Rad2Deg;           
        Quaternion lookTowards = Quaternion.AngleAxis(angle, Vector3.forward);
        rb.transform.rotation = lookTowards;
            
        //Scale around blackhole
        transform.localScale = transform.localScale * (1 - Time.deltaTime/1);

        //Destroy once small
        if(transform.localScale.x < 0.04)
                Destroy(gameObject);

        //Accelerate falling in
        blackholeRotationSuck += Time.deltaTime/2;
    }

    void opaqueDeath() {
        Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
