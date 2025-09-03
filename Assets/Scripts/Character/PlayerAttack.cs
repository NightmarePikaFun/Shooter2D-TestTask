using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Weapon currentWeapon;
    private bool canAttack = true;
    private float attackTime = 1.0f;

    public void Init()
    {
        currentWeapon = ContentManager.Instance.GetWeaponByIndex(0);
        attackTime = currentWeapon.GetAttackTime();
        StartCoroutine(AttackCD());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWeapon == null)
            return;
        if (Input.GetMouseButton(0) && canAttack)
        {
            canAttack = false;
            currentWeapon.DoAttack(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    private IEnumerator AttackCD()
    {
        while (true)
        {
            Debug.Log("You can attack");
            yield return new WaitUntil(() => !canAttack);
            Debug.Log("Reload");
            yield return new WaitForSeconds(attackTime);
            canAttack = true;
        }
    }
}
