using UnityEngine;

public class Character : MonoBehaviour
{
    protected AbstractInput input;
    private CharacterMovement movement;

    public CharacterMovement Movement => movement;

    public void SetInput(AbstractInput input)
    {
        this.input = input;
    }

    protected virtual void Awake()
    {
        movement = GetComponent<CharacterMovement>();
        input = GetComponent<AbstractInput>();
    }

    protected virtual void Update()
    {
        if (input == null) return;
        
        movement.Direction = input.Direction;
    }
}
