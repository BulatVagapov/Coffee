using System;
using UnityEngine;

public class CharactersSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerSeed;
    [SerializeField] private int npcSeedsQuantity;
    [SerializeField] private NPCSeedsPool npcSeedsPool;
    [SerializeField] private GameObject coffeeMachine;

    public GameObject PlayerSeed => playerSeed;
    public int NpcSeedsQuantity => npcSeedsQuantity;

    public int CurrentNumberOfNPCSeeds { get; private set; }
    public event Action<int> CurrentNumberOfSeedsChengedEvent;
    public event Action AllNpcSeedIsDestroyedEvent;

    private void Awake()
    {
        npcSeedsPool.InitPool(npcSeedsQuantity);

        for (int i = 0; i < npcSeedsPool.NpcSeedsPool.Count; i++)
        {
            npcSeedsPool.NpcSeedsPool[i].GetComponent<SeedHealth>().DeadEvent += DecreaceNumberOfSeeds;
        }
    }

    private void SpawnCharacter(GameObject spawningObject)
    {
        spawningObject.transform.position = PointOnFieldProvider.GetRandomPointOnField();
        spawningObject.SetActive(true);
    }

    public void SpawnGameCharacters()
    {
        SpawnCharacter(playerSeed);
        SpawnCharacter(coffeeMachine);

        CurrentNumberOfNPCSeeds = npcSeedsQuantity;
        CurrentNumberOfSeedsChengedEvent?.Invoke(CurrentNumberOfNPCSeeds);

        for (int i = 0; i < npcSeedsPool.NpcSeedsPool.Count; i++)
        {
            SpawnCharacter(npcSeedsPool.NpcSeedsPool[i]);
        }
    }

    public void DecreaceNumberOfSeeds()
    {
        CurrentNumberOfNPCSeeds--;
        CurrentNumberOfSeedsChengedEvent?.Invoke(CurrentNumberOfNPCSeeds);

        if (CurrentNumberOfNPCSeeds <= 0) AllNpcSeedIsDestroyedEvent?.Invoke();
    }
}
