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
    private bool canAttack = true;
    private float attackTime = 1.0f;


    private void Awake()
    {
        weapons[currentWeaponIndex].CreateInstance();
        currentWeapon = weapons[currentWeaponIndex];
        attackTime = currentWeapon.GetAttackTime();
        StartCoroutine(AttackCD());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && canAttack)
        {
            canAttack = false;
            currentWeapon.DoAttack(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    private IEnumerator AttackCD()
    {
        while(true)
        {
            Debug.Log("You can attack");
            yield return new WaitUntil(() => !canAttack);
            Debug.Log("Reload");
            yield return new WaitForSeconds(attackTime);
            canAttack = true;
        }
    }
}
