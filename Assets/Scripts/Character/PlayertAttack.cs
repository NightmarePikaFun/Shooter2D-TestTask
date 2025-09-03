using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayertAttack : MonoBehaviour
{
    [SerializeField]
    private List<Weapon> weapons = new List<Weapon>();

    [SerializeField]
    private int currentWeaponIndex = 0;

    private Weapon currentWeapon;

    private void Awake()
    {
        weapons[currentWeaponIndex].CreateInstance();
        currentWeapon = weapons[currentWeaponIndex];
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            currentWeapon.DoAttack(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Debug.Log("Attack");
        }
    }
}
