using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStaticTransform : MonoBehaviour
{
    public static Transform PlayerTransform { get; private set; }

    void Awake()
    {
        PlayerTransform = transform;
    }
}
