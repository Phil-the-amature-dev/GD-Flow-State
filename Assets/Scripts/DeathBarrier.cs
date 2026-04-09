using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    [SerializeField] private Spawn spawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter()
    {
        spawnPoint.Respwan();
    }
   
}
