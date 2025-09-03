using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentManager : MonoBehaviour
{
    public static ContentManager Instance;

    [SerializeField]
    private Player player;
    [SerializeField]
    private List<Weapon> _weapons = new List<Weapon>();
    [SerializeField]
    private int _currentWeaponIndex = 0;

    private void Awake()
    {
        Instance = this;
        foreach(var weapon in _weapons)
        {
            weapon.CreateInstance();
        }
        
    }

    public Weapon GetWeaponByIndex(int index)
    {
        if (index >= _weapons.Count)
            index = _weapons.Count - 1;
        if(index < 0)
            index = 0;
        return _weapons[index];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
