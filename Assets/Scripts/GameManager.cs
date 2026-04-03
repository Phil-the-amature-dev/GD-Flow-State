using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Camera playerCamera;
    [SerializeField] private Gun[] gunList;

    private const string TARGET_TAG = "Target";
    private LayerMask TARGET_LAYER;
    private LayerMask PLAYER_LAYER;
    

    public string getTargetTag => TARGET_TAG;
    public int getTargetLayer => TARGET_LAYER;
    public int getPlayerLayer => PLAYER_LAYER;
    public Camera getCamera => playerCamera;    
    
    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            TARGET_LAYER = LayerMask.GetMask("Target");
            PLAYER_LAYER = LayerMask.GetMask("Player");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        playerCamera = FindAnyObjectByType<Camera>();
        
    }

    public void unlockGun(int id)
    {
        foreach (Gun gun in gunList)
        {
            if (gun.GetGunId == id)
            {
                gun.isEnabled = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
