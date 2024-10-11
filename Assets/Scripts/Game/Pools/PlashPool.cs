using System.Collections.Generic;
using UnityEngine;

public class PlashPool : MonoBehaviour
{
    private List<Plash> plashPool = new();
    private Plash creatingPlash;

    [SerializeField] private Plash plashPrefab;
    [SerializeField] private int numberOfPlashes;

    private void Awake()
    {
        InitPool();
    }

    private void AddPlash()
    {
        creatingPlash = Instantiate(plashPrefab, transform);
        plashPool.Add(creatingPlash);
        creatingPlash.gameObject.SetActive(false);
    }

    private void InitPool()
    {
        for (int i = 0; i < numberOfPlashes; i++)
        {
            AddPlash();
        }
    }

    public Plash GetPlash()
    {
        for (int i = 0; i < plashPool.Count; i++)
        {
            if (!plashPool[i].gameObject.activeSelf)
            {
                return plashPool[i];
            }

        }
        AddPlash();
        return creatingPlash;
    }
}
