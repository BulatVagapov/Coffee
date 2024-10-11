using System;
using UnityEngine;

public class SeedHealth : MonoBehaviour
{
    [SerializeField] private int maxHP;
    private int currentHP;

    public event Action HealthPointChangedEvent;
    public event Action DeadEvent;

    private void Start()
    {
        currentHP = maxHP;
    }

    public void GetDamage(int damage)
    {
        currentHP -= damage;

        HealthPointChangedEvent?.Invoke();
        if (currentHP <= 0)
        {
            DeadEvent?.Invoke();
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        currentHP = maxHP;
    }
}
