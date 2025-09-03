using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Scrollbar healthBar;
    private int _maxHealth;
    private int _currentHealth;

    public Action<int> Init(int helath)
    {
        _maxHealth = helath;
        _currentHealth = helath;
        return ChangeHealth;
    }

    private void ChangeHealth(int value)
    {
        _currentHealth = value;
        if(_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        else if( _currentHealth < 0)
        {
            _currentHealth = 0;
        }
        healthBar.size = (float)_currentHealth / _maxHealth;
    }
}
