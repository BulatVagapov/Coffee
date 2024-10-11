using UnityEngine;

public abstract class AbstractInput : MonoBehaviour
{
    protected Vector2 direction;
    public Vector2 Direction => direction;

    private void OnDisable()
    {
        direction = Vector2.zero;
    }
}
