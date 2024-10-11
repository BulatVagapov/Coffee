using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;


public class WaterDropThrower : MonoBehaviour
{
    private WaterDrop currentWaterDrop;
    [SerializeField] private WaterDropPool waterDropPool;
    private Vector3 rotationAngles;
    [SerializeField] private Transform animatingTransform;
    [SerializeField] private Transform firePointTransform;
    public bool AttackInProcess { get; private set; }

    [SerializeField] private WaterDropSpeeds waterDropSpeeds;

    [Header("RegularAttack")]
    [SerializeField] private int numberOfDropsInRegularAttack;
    [SerializeField] private float additionalZAngle;
    [SerializeField] private float timeBetweenShotsForRegularAttack;
    private Vector3 directionToTarget;

    [Header("CircularAttack")]
    [SerializeField] private int numberOfWaterDropsInCircle;
    private float zAngleBetweenDrops => 360 / numberOfWaterDropsInCircle;
    private Vector3 rottationForCircularAttack;

    [Header("CrazyAttack")]
    [SerializeField] private int numberOfDropsForCrazyAttack;
    [SerializeField] private float timeBetweenShotsForCrazyAttack;

    private bool attackIsStoped;

    private void OnEnable()
    {
        attackIsStoped = false;
    }


    private void CorrectAngles(ref Vector3 angles)
    {
        if (angles.z > 0 && angles.z < 180) return;

        angles.y = 180;
        angles.z = 180 - (angles.z -180);
    }

    private void GetWaterDrop()
    {
        currentWaterDrop = waterDropPool.GetWaterDrop();
        currentWaterDrop.transform.position = firePointTransform.position;
    }
    
    public async UniTask RegularAttack(Vector3 targetPosition)
    {
        AttackInProcess = true;

        GetWaterDrop();

        rotationAngles = Vector3.zero;
        directionToTarget = targetPosition - transform.position;
        rotationAngles.z = Mathf.Atan2(-directionToTarget.x, directionToTarget.y) * Mathf.Rad2Deg;

        CorrectAngles(ref rotationAngles);

        currentWaterDrop.transform.rotation = Quaternion.Euler(rotationAngles);
        currentWaterDrop.Throw(waterDropSpeeds.RegularAttackSpeed);

        await UniTask.Delay((int)(timeBetweenShotsForRegularAttack * 1000));

        for (int i = 1; i < numberOfDropsInRegularAttack; i++)
        {
            if (attackIsStoped) return;
            
            GetWaterDrop();

            if (i%2 == 0)
            {
                rotationAngles.z += additionalZAngle;
                CorrectAngles(ref rotationAngles);
            }
            else
            {
                rotationAngles.z -= additionalZAngle;
                CorrectAngles(ref rotationAngles);
            }

            currentWaterDrop.transform.Rotate(rotationAngles);
            currentWaterDrop.Throw(waterDropSpeeds.RegularAttackSpeed);

            await UniTask.Delay((int)(timeBetweenShotsForRegularAttack * 1000));
        }

        AttackInProcess = false;
    }

    public async UniTask CircularAttack()
    {
        AttackInProcess = true;

        rotationAngles = Vector3.zero;
        rottationForCircularAttack = Vector3.zero;

        animatingTransform.DOScaleY(0.33f, 0.5f);
        await UniTask.Delay(700);

        animatingTransform.DOScaleY(0.39f, 0.1f);
        await UniTask.Delay(100);

        for (int i = 0; i < numberOfWaterDropsInCircle; i++)
        {
            if (attackIsStoped) return;
            CorrectAngles(ref rotationAngles);
            GetWaterDrop();
            currentWaterDrop.transform.Rotate(rotationAngles);
            currentWaterDrop.Throw(waterDropSpeeds.CircularAttackSpeed);

            rottationForCircularAttack.z += zAngleBetweenDrops;
            rotationAngles = rottationForCircularAttack;
        }

        AttackInProcess = false;
    }

    public async UniTask CrazyAttack()
    {
        AttackInProcess = true;
        rotationAngles = Vector3.zero;

        animatingTransform.DORotate(Vector3.forward * 15, timeBetweenShotsForCrazyAttack);
        await UniTask.Delay((int)(timeBetweenShotsForCrazyAttack * 1000));

        animatingTransform.DORotate(Vector3.forward * -15, timeBetweenShotsForCrazyAttack * 2);
        await UniTask.Delay((int)(timeBetweenShotsForCrazyAttack * 2 * 1000));

        for (int i = 0; i < numberOfDropsForCrazyAttack; i++)
        {
            if (attackIsStoped) return;

            GetWaterDrop();

            if (i % 2 == 0)
            {
                rotationAngles = Vector3.zero;
                rotationAngles.z = Random.Range(0f, 180f);

                animatingTransform.DORotate(Vector3.forward * 15, timeBetweenShotsForCrazyAttack);
            }
            else
            {
                rotationAngles.z *= -1;
                CorrectAngles(ref rotationAngles);

                animatingTransform.DORotate(Vector3.forward * -15, timeBetweenShotsForCrazyAttack);
            }

            currentWaterDrop.transform.Rotate(rotationAngles);
            currentWaterDrop.Throw(waterDropSpeeds.CrazyAttackSpeed);

            await UniTask.Delay((int)(timeBetweenShotsForCrazyAttack * 1000));
        }


        animatingTransform.DORotate(Vector3.zero, 0.3f);
        AttackInProcess = false;
    }

    private void OnDisable()
    {
        AttackInProcess = false;
        attackIsStoped = true;
    }
}
