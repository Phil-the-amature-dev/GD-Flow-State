using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] private GameObject muzzle;
    private float lastShotframe;
    private bool canShoot = true;
    private System.Action runShootMethod;
    private Animation recoilAnimation;

    

    public Camera playerCamera;
    public LayerMask targetLayer;
    public LayerMask playerLayer;
    public string targetTag;
    public float shotDelay;
    public bool automatic;
    public abstract float maxDistance { get; set; }
    public abstract float damage { get; set; }

    public abstract GameObject muzzleEffect { get; set; }
    public abstract GameObject impactEffect { get; set; }
    




    public void Start()
    {
        playerCamera = FindAnyObjectByType<Camera>();
        targetLayer = GameManager.instance.getTargetLayer;
        playerLayer = GameManager.instance.getPlayerLayer;
        targetTag = GameManager.instance.getTargetTag;
        recoilAnimation = this.GetComponentInChildren<Animation>();
        runShootMethod = automatic ? automaticFire : semiAutoFire;
        targetLayer = targetLayer & ~(LayerMask.GetMask("Player")); // excludes player layer from the layermask so that it's not detected when commiting a raycast
    }

    public void Update()
    {
        canShoot = (Time.time - lastShotframe > shotDelay);
        runShootMethod();
        
    }


    public abstract void Shoot();

    public void automaticFire()
    {
        if (canShoot && Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
            lastShotframe = Time.time;
            recoilAnimation.Play();
        }
       
    }

    public void semiAutoFire()
    {
        if (canShoot && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
            lastShotframe = Time.time;
            recoilAnimation.Play();
        }

    }


}
