using UnityEngine;
using UnityEngine.UI;

public class PrivicyPolicyScreen : MonoBehaviour
{
    [SerializeField] private Button okButton;
    
    void Start()
    {
        okButton.onClick.AddListener(() => gameObject.SetActive(false));
        gameObject.SetActive(false);
    }
}
