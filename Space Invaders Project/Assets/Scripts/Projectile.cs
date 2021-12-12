using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Projectile : MonoBehaviour
{
    public float speed;
    Vector3 direction;
    public System.Action<Projectile> destroyed;
    public new BoxCollider2D collider { get; private set; }
    public GameObject explosion;

    private void Awake()
    {
        this.collider = GetComponent<BoxCollider2D>();
    }

    private void OnDestroy()
    {
        if (this.destroyed != null) {
            this.destroyed.Invoke(this);
        }
    }

    private void Update()
    {
        direction = transform.up;
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    private void CheckCollision(Collider2D other)
    {
        Bunker bunker = other.gameObject.GetComponent<Bunker>();

        if (bunker == null || bunker.CheckCollision(this.collider, this.transform.position)) {
            if(other.gameObject.layer != LayerMask.NameToLayer("Boundary"))
            {
                Explode();
            } else
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckCollision(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CheckCollision(other);
    }

    void Explode() {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

}
