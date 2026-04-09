using UnityEngine;

public class Spawn : MonoBehaviour
{
    private Transform player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respwan()
    {
        player.position = transform.position;
    }
}
