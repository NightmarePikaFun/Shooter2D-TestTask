using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer weaponSprite;
    [SerializeField]
    private Button firstWeapon;
    [SerializeField]
    private Button secondWeapon;

    private Weapon currentWeapon;
    private bool canAttack = true;
    private float attackTime = 1.0f;

    public bool canMove = false;

#if UNITY_ANDROID
    private Vector2 touchStartPos;
    private Vector2 secondTouchPos;
#endif

    private void Awake()
    {
        firstWeapon.onClick.AddListener(() =>
        {
            SetWeapon(ContentManager.Instance.GetWeaponByIndex(0));
        });
        secondWeapon.onClick.AddListener(() =>
        {
            SetWeapon(ContentManager.Instance.GetWeaponByIndex(1));
        });
#if !UNITY_ANDROID
        firstWeapon.gameObject.SetActive(false);
        secondWeapon.gameObject.SetActive(false);
#endif

    }

    public void Init()
    {
        SetWeapon( ContentManager.Instance.GetWeaponByIndex(0));
        
        StartCoroutine(AttackCD());
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
            return;
        if (currentWeapon == null)
            return;
#if !UNITY_ANDROID
        if (Input.GetMouseButton(0) && canAttack)
        {
            canAttack = false;
            currentWeapon.DoAttack(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeapon(ContentManager.Instance.GetWeaponByIndex(0));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeapon(ContentManager.Instance.GetWeaponByIndex(1));
        }
#endif
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
                secondTouchPos = touchStartPos;
            }
            if(touch.phase == TouchPhase.Moved)
            {
                secondTouchPos = touch.position;
            }
            if (!canAttack)
                return;
            if (Vector2.Distance(secondTouchPos, touchStartPos) < 0.01f)
                currentWeapon.DoAttack(Vector3.up);
            else
                currentWeapon.DoAttack(secondTouchPos- touchStartPos );
            canAttack = false;
        }
#endif
    }

    private void SetWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
        attackTime = currentWeapon.GetAttackTime();
        weaponSprite.sprite = weapon.weaponSprite;
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
