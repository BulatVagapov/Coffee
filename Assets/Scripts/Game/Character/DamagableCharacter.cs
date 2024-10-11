using UnityEngine;

public class DamagableCharacter : Character
{
    private Animator seedAnimator;
    public SeedHealth Health { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        Health = GetComponent<SeedHealth>();
        seedAnimator = transform.GetComponentInChildren<Animator>();
        DamagableCharactersDictionary.AddDamagableCharacter(GetComponent<Collider2D>(), this);
    }

    protected override void Update()
    {
        base.Update();
        seedAnimator.SetFloat("Xaxis", Mathf.Abs(input.Direction.x));
        seedAnimator.SetFloat("Yaxis", input.Direction.y);

        RotateCharacterToRalativeDirection(input.Direction);
    }

    private void RotateCharacterToRalativeDirection(Vector2 direction)
    {
        if(direction.x < 0 && transform.rotation.eulerAngles.y < 160)
        {
            transform.Rotate(Vector3.up * -180);
        }


        if(direction.x > 0 && transform.rotation.eulerAngles.y != 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }
}
