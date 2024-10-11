using System.Collections.Generic;
using UnityEngine;

public static class DamagableCharactersDictionary
{
    private static Dictionary<Collider2D, DamagableCharacter> damagableCharacters = new();

    public static void AddDamagableCharacter(Collider2D characterCollider, DamagableCharacter character)
    {
        if (damagableCharacters.ContainsKey(characterCollider)) return;

        damagableCharacters.Add(character.GetComponent<Collider2D>(), character);
    }

    public static bool ContainsCharacter(Collider2D characterCollider)
    {
        return damagableCharacters.ContainsKey(characterCollider);
    } 

    public static DamagableCharacter GetCharacter(Collider2D characterCollider)
    {
        if (!damagableCharacters.ContainsKey(characterCollider)) return null;

        return damagableCharacters[characterCollider];
    }
}
