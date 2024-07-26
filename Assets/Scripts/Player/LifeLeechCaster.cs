using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeLeechCaster : MonoBehaviour
{
    [SerializeField] private float _lifeLeechDuration;
    [SerializeField] private float _lifeLeechCooldown;
    [SerializeField] private float _lifeLeechTickDamage;
    [SerializeField] private float _lifeLeechTickDelay;
    [SerializeField] private CharacterStats _playerStats;
    [SerializeField] private LifeLeechAnimator _lifeLeechAnimator;
    [SerializeField] private Vector2 _overlapAreaSize;

    private bool _isLifeLeechOnCooldown;

    public event Action AbilityCasted;

    public float LifeLeechDuration => _lifeLeechDuration;
    public float LifeLeechCooldown => _lifeLeechCooldown;

    private void Awake()
    {
        _isLifeLeechOnCooldown = false;
    }

    public void CastLifeLeech()
    {
        if (_isLifeLeechOnCooldown == false)
        {            
            StartCoroutine(LeechLife());
            AbilityCasted?.Invoke();
        }
    }

    private IEnumerator LeechLife()
    {
        _isLifeLeechOnCooldown = true;
        _lifeLeechAnimator.gameObject.SetActive(true);

        WaitForSeconds wait = new WaitForSeconds(_lifeLeechTickDelay);

        for (int i = 0; i < _lifeLeechDuration; i++)
        {
            List<CharacterStats> enemiesInRange = GetEnemiesInRange();

            foreach (var enemy in enemiesInRange)
            {
                if (enemy.HitPoints >= _lifeLeechTickDamage)
                {
                    _playerStats.AddHitPoints(_lifeLeechTickDamage);
                }
                else 
                {
                    _playerStats.AddHitPoints(enemy.HitPoints);
                }                

                enemy.RemoveHitPoints(_lifeLeechTickDamage);
            }

            yield return wait;
        }

        _lifeLeechAnimator.gameObject.SetActive(false);

        StartCoroutine(TrackCooldown());
    }

    private List<CharacterStats> GetEnemiesInRange()
    {
        Vector2 playerPosition = transform.position;
        List<CharacterStats> enemiesInRange = new List<CharacterStats>();

        Collider2D[] hits = Physics2D.OverlapAreaAll(playerPosition + _overlapAreaSize, playerPosition - _overlapAreaSize);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent<EnemyDamageTaker>(out EnemyDamageTaker enemy))
            {
                enemiesInRange.Add(enemy.GetComponent<CharacterStats>());
            }
        }

        return enemiesInRange;
    }

    private IEnumerator TrackCooldown()
    {
        WaitForSeconds wait = new WaitForSeconds(_lifeLeechCooldown);                

        yield return wait;

        _isLifeLeechOnCooldown = false;
    }
}
