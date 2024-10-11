using UnityEngine;

public class PlayerCharacterViewSetter : MonoBehaviour
{
    private SpriteRenderer playerSpriteRenderer;
    private Animator playerAnimator;

    [SerializeField] private Sprite[] playersViewSprites;
    [SerializeField] private RuntimeAnimatorController[] playersAnimatorsControllers;

    private void Start()
    {
        playerSpriteRenderer = PlayerStaticTransform.PlayerTransform.GetComponentInChildren<SpriteRenderer>();
        playerAnimator = PlayerStaticTransform.PlayerTransform.GetComponentInChildren<Animator>();
    }

    public void SetPlayerCharacterView(int viewIndex)
    {
        playerSpriteRenderer.sprite = playersViewSprites[viewIndex];
        playerAnimator.runtimeAnimatorController = playersAnimatorsControllers[viewIndex];
    }

}
