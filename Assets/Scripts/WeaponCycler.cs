using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Rendering;


public class WeaponCycler : MonoBehaviour
{
    [SerializeField] Gun[] weapons = new Gun[3];
    private Gun activeWeapon;
    private int index = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switchWeapons(index);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y < 0)
        {
            index += 1;
            if (index > weapons.Length-1) { index = 0; };
            switchWeapons(index);
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            index -= 1;
            if (index < 0) { index = weapons.Length-1; }
            switchWeapons(index);
        }
    }

    public void switchWeapons(int index)
    {
        if (activeWeapon != null) { activeWeapon.gameObject.SetActive(false); }
        activeWeapon = weapons[index];
        activeWeapon.gameObject.SetActive(true);
    }
}
