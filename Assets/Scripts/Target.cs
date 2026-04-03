using System.Dynamic;
using UnityEngine;
using UnityEngine.UIElements;

public class Target : MonoBehaviour
{
    
    
    [SerializeField] private float health;
    [SerializeField] private int targetID;
    [SerializeField] private int targetValue;
    private NextLevelDoor nextLevelDoor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (NextLevelDoor door in FindObjectsByType<NextLevelDoor>(FindObjectsSortMode.None))
        {
            if (door.doorID == targetID)
            {
                nextLevelDoor = door;
            }
        }
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
        nextLevelDoor.UpdateTargetCount(targetValue);
    }
}
