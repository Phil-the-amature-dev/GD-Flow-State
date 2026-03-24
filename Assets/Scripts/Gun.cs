using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    private Transform Barrel;
    public Camera playerCamera;
    public LayerMask targetLayer;
    public string targetTag;
    public abstract float maxDistance { get; set; }
    public abstract float damage { get; set; }





    public void Start()
    {
        playerCamera = FindAnyObjectByType<Camera>();
        targetLayer = GameManager.instance.getTargetLayer;
        targetTag = GameManager.instance.getTargetTag;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }


    public abstract void Shoot();
}
