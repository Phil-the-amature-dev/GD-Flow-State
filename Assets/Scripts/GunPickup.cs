using Unity.VisualScripting;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    [SerializeField] private int unlockId;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.unlockGun(unlockId);
        Destroy(gameObject);
    }
}
