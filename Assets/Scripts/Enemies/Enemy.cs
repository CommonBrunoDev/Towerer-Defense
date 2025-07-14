using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health;
    public bool IsDead = false;

    public float speed;
    public float damage;
    public float distanceTravelled = 0;

    public int currentIndex = 0;

    public Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("Rigidbody?");
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        { Death(); }
    }
    private void Death()
    {
        GameManager.Instance.waveHandler.enemyAmount--;
        IsDead = true;
    }
}
