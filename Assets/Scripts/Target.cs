using UnityEngine;
using UnityEngine.UIElements;

public class Target : MonoBehaviour
{
    [SerializeField] private float health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) { TargetDie(); }
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        Debug.Log(health);
    }

    public void TargetDie()
    {
        Destroy(this.gameObject);
    }
}
