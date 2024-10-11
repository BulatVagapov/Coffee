using Cysharp.Threading.Tasks;
using UnityEngine;

public class CharacterWithWaterDropThrower : Character
{
    private CoffeeMachineInput coffeeMachineInput;
    public WaterDropThrower WaterDropThrower { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        WaterDropThrower = GetComponent<WaterDropThrower>();
        coffeeMachineInput = input as CoffeeMachineInput;
    }

    private void Start()
    {
        coffeeMachineInput.StartRegularAttackEvent += () => WaterDropThrower.RegularAttack(PlayerStaticTransform.PlayerTransform.position).Forget();
        coffeeMachineInput.StartCircularAttackEvent += () => WaterDropThrower.CircularAttack();
        coffeeMachineInput.StartCrazyAttackEvent += OnCrazyAttack;
    }

    private void OnCrazyAttack()
    {
        WaterDropThrower.CrazyAttack().Forget();
    }
}
