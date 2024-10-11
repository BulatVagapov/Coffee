using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementGroup : MonoBehaviour
{
    [SerializeField] private Image medalImage;
    [SerializeField] private Sprite achievedSprite;
    [SerializeField] private Sprite unahievedSprite;
    [SerializeField] private Slider slider;

    [SerializeField] private TMP_Text currentValueText;
    [SerializeField] private TMP_Text needfullValueText;

    public void SetAchievementGroupView(int currentValue, int maxValue)
    {
        medalImage.sprite = currentValue >= maxValue ? achievedSprite : unahievedSprite;

        slider.value = (float)currentValue / (float)maxValue;

        needfullValueText.text = maxValue.ToString();
        currentValueText.text = currentValue.ToString();
    }
}
