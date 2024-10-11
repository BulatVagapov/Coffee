using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Plash : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float timeToFadeOut;

    public UnityEvent PlashDisappearedEvent;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void LeavePlash(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
        FaidOut().Forget();
    }

    private async UniTask FaidOut()
    {
        spriteRenderer.DOFade(0, timeToFadeOut);
        transform.DOScale(0.2f, timeToFadeOut);
        await UniTask.Delay((int)(timeToFadeOut * 1000));
        PlashDisappearedEvent?.Invoke();
        PlashDisappearedEvent?.RemoveAllListeners();
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        spriteRenderer.DOFade(1, 0);
        transform.DOScale(1f, 0);
    }
}
