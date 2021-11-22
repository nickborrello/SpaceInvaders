using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Invader : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public int score = 10;
    public System.Action<Invader> killed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            this.killed?.Invoke(this);
        }
    }
}
