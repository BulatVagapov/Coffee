using UnityEngine;

public class PointOnFieldProvider : MonoBehaviour
{
    private static float gameFieldRadius => gameField.lossyScale.y / 2f;
    private static float sqrRadius;
    private static Vector2 spawnPoint;
    [SerializeField] private Transform gameFieldTransform;
    private static Transform gameField;

    private void Awake()
    {
        gameField = gameFieldTransform;
        sqrRadius = gameFieldRadius * gameFieldRadius;
    }

    public static Vector2 GetRandomPointOnField()
    {
        spawnPoint = Random.insideUnitCircle;
        spawnPoint *= gameFieldRadius;
        spawnPoint += (Vector2)gameField.position;
        return spawnPoint;
    }

    public static Vector2 GetNearestPointOnField(Vector3 targetPoint)
    {
        if((targetPoint - gameField.position).sqrMagnitude < sqrRadius)
        {
            return targetPoint;
        }

        return (targetPoint - gameField.position).normalized * gameFieldRadius;
    }
}
