using UnityEngine;

public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private PlayerHealthViewHeart[] pleyerHearts;
    private int currentIndex;

    private void Start()
    {
        currentIndex = pleyerHearts.Length - 1;
    }

    public void RefillHearts()
    {
        for(int i = 0; i < pleyerHearts.Length; i++)
        {
            pleyerHearts[i].SetFullSprite();
        }

        currentIndex = pleyerHearts.Length - 1;
    }

    public void EmptyHeart()
    {
        if (currentIndex < 0) return;

        pleyerHearts[currentIndex].SetEmptySprite();
        currentIndex--;
    }
}
