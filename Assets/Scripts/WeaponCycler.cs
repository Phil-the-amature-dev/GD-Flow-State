using System.Collections;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;


public class WeaponCycler : MonoBehaviour
{
    public static WeaponCycler instance;
    [SerializeField] Gun[] weapons = new Gun[3];
    private Gun activeWeapon;
    private int index = 0;

    public int GetIndex => index;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switchWeapons(index);
    }

    public void Awake()
    {
        {
            if (instance != null && instance != this)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y < 0)
        {
            int prevIndex = index;
            index += 1;
            if (index > weapons.Length-1) { index = 0; };
            if (weapons[index].isEnabled == false) { index = prevIndex; }
            switchWeapons(index);
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            int prevIndex = index;
            index -= 1;
            if (index < 0) { index = weapons.Length-1; }
            if (weapons[index].isEnabled == false) { index = prevIndex; }
            switchWeapons(index);
        }
    }

    public void switchWeapons(int index)
    {
        if (activeWeapon != null) { activeWeapon.gameObject.SetActive(false); }
        if (weapons[index].isEnabled)
        {
            activeWeapon = weapons[index];
            activeWeapon.gameObject.SetActive(true);
        }
        
    }
}
