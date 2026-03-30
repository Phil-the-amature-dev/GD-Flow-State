using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    private Transform Barrel;
    public Camera playerCamera;
    public LayerMask targetLayer;
    public LayerMask playerLayer;
    public string targetTag;
    public abstract float maxDistance { get; set; }
    public abstract float damage { get; set; }

    public abstract GameObject muzzleEffect { get; set; }
    public abstract GameObject barrel { get; set; }




    public void Start()
    {
        playerCamera = FindAnyObjectByType<Camera>();
        targetLayer = GameManager.instance.getTargetLayer;
        playerLayer = GameManager.instance.getPlayerLayer;
        targetTag = GameManager.instance.getTargetTag;
        targetLayer = targetLayer & ~(LayerMask.GetMask("Player")); // excludes player layer from the layermask so that it's not detected when commiting a raycast
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
