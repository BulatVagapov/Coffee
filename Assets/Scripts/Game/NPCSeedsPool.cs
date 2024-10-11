using System.Collections.Generic;
using UnityEngine;

public class NPCSeedsPool : MonoBehaviour
{
    [SerializeField] private GameObject npcSeedPrefab;

    public List<GameObject> NpcSeedsPool { get; private set; }

    public void InitPool(int poolElementQuantity)
    {
        NpcSeedsPool = new();

        for (int i = 0; i < poolElementQuantity; i++)
        {
            NpcSeedsPool.Add(Instantiate(npcSeedPrefab, transform));
            NpcSeedsPool[i].SetActive(false);
        }
    }
}
