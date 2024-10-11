using UnityEngine;

public class CoffeeMachineDamageDealer : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (DamagableCharactersDictionary.ContainsCharacter(collision))
            DamagableCharactersDictionary.GetCharacter(collision).Health.GetDamage(damage);
    }
}
