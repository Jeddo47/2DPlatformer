using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private float _hitPoints;
    [SerializeField] private float _damage;
    [SerializeField] private float _minHitPoints;

    public event Action HealthChanged;

    public float MaxHitPoints { get; private set; }
    public float HitPoints => _hitPoints;
    public float Damage => _damage;

    private void Awake()
    {
        MaxHitPoints = _hitPoints;
    }

    public void RemoveHitPoints(float changeAmount)
    {
        ChangeHitPoints(-changeAmount);     
    }

    public void AddHitPoints(float changeAmount)
    {
        ChangeHitPoints(changeAmount);
    }

    private void ChangeHitPoints(float changeAmount)
    {
        _hitPoints = Mathf.Clamp(_hitPoints + changeAmount, _minHitPoints, MaxHitPoints);

        HealthChanged?.Invoke();
    }        
}
