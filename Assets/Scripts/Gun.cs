using UnityEngine;

public abstract class Gun : MonoBehaviour
{
     private Transform Barrel;
     public Transform playerCamera;
    


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }


    public abstract void Shoot();
}
