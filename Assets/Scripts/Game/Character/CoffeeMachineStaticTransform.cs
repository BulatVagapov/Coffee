using UnityEngine;

public class CoffeeMachineStaticTransform : MonoBehaviour
{
    public static Transform CoffeeMachineTransform { get; private set; }

    void Awake()
    {
        CoffeeMachineTransform = transform;
    }
}
