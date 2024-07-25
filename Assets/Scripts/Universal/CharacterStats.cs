using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private float _hitPoints;
    [SerializeField] private float _damage;

    public event Action HealthChanged;

    public float MaxHitPoints { get; private set; }
    public float HitPoints { get { return _hitPoints; } }
    public float Damage { get { return _damage; } }

    private void Awake()
    {
        MaxHitPoints = _hitPoints;
    }

    public void RemoveHitPoints(float changeAmount)
    {
        if (_hitPoints > 0) 
        {
            ChangeHitPoints(changeAmount);
        }        
    }

    public void AddHitPoints(float changeAmount)
    {
        if (_hitPoints < MaxHitPoints) 
        {
            ChangeHitPoints(changeAmount);

            if (_hitPoints > MaxHitPoints) 
            {
                _hitPoints = MaxHitPoints;           
            }
        }
    }

    private void ChangeHitPoints(float changeAmount)
    {
        _hitPoints += changeAmount;

        HealthChanged?.Invoke();
    }        
}
