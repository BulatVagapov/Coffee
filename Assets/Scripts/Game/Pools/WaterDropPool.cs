using System.Collections.Generic;
using UnityEngine;

public class WaterDropPool : MonoBehaviour
{
    private List<WaterDrop> waterDropsPool = new();
    private WaterDrop createdWaterDrop;

    [SerializeField] private WaterDrop waterDropPrefab;
    [SerializeField] private PlashPool plashPool;
    [SerializeField] private int numberOfWaterDrops;

    private void Awake()
    {
        InitPool();
    }

    private void AddWaterDrop()
    {
        createdWaterDrop = Instantiate(waterDropPrefab, transform);
        createdWaterDrop.PlashPool = plashPool;
        waterDropsPool.Add(createdWaterDrop);
        createdWaterDrop.gameObject.SetActive(false);
    }

    private void InitPool()
    {
        for (int i = 0; i < numberOfWaterDrops; i++)
        {
            AddWaterDrop();
        }
    }

    public WaterDrop GetWaterDrop()
    {
        for(int i = 0; i < waterDropsPool.Count; i++)
        {
            if (!waterDropsPool[i].gameObject.activeSelf)
            {
                waterDropsPool[i].GetWaterDrop();
                return waterDropsPool[i];
            }

        }
        AddWaterDrop();
        createdWaterDrop.GetWaterDrop();
        return createdWaterDrop;
    } 
}
