using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D rigidbody;

    public Vector2 Direction;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidbody.velocity = Direction * Speed;
    }

    private void OnDisable()
    {
        if (rigidbody == null) return;
        rigidbody.velocity = Vector2.zero;
    }
}
