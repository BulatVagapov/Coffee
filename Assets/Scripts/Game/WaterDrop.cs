using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WaterDrop : MonoBehaviour
{
    private Rigidbody2D waterDropRB;
    public PlashPool PlashPool;
    private Plash currentPlash;
    [SerializeField] private int damage;

    void Awake()
    {
        waterDropRB = GetComponent<Rigidbody2D>();
    }

    public void Throw(float speed)
    {
        gameObject.SetActive(true);
        waterDropRB.velocity = transform.up * speed;
    }

    public void GetWaterDrop()
    {
        transform.Rotate(Vector3.zero);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (DamagableCharactersDictionary.ContainsCharacter(collision)) 
            DamagableCharactersDictionary.GetCharacter(collision).Health.GetDamage(damage);

        WaterDropCollide();
        gameObject.SetActive(false);
    }

    private void WaterDropCollide()
    {
        currentPlash = PlashPool.GetPlash();
        currentPlash.LeavePlash(transform.position);
    }

    private void OnDisable()
    {
        waterDropRB.velocity = Vector2.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        AudioManager.Instance.PlayWaterDropSound();
    }
}
