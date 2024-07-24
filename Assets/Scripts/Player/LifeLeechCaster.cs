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

    public float LifeLeechDuration { get { return _lifeLeechDuration; } }
    public float LifeLeechCooldown { get { return _lifeLeechCooldown; } }

    private void Awake()
    {
        _isLifeLeechOnCooldown = false;
    }

    private void Update()
    {
        CastLifeLeech();
    }

    private void CastLifeLeech()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && _isLifeLeechOnCooldown == false)
        {
            StartCoroutine(TrackCooldown());
            StartCoroutine(LeechLife());
            AbilityCasted?.Invoke();
        }
    }

    private IEnumerator LeechLife()
    {
        WaitForSeconds wait = new WaitForSeconds(_lifeLeechTickDelay);

        _lifeLeechAnimator.gameObject.SetActive(true);

        for (int i = 0; i < _lifeLeechDuration; i++)
        {
            List<CharacterStats> enemiesInRange = GetEnemiesInRange();
            
            foreach (var enemy in enemiesInRange)
            {
                if (_playerStats.HitPoints < _playerStats.MaxHitPoints)
                {
                    _playerStats.AddHitPoints(_lifeLeechTickDamage);
                }

                enemy.RemoveHitPoints(-_lifeLeechTickDamage);
            }

            yield return wait;
        }

        _lifeLeechAnimator.gameObject.SetActive(false);
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

        _isLifeLeechOnCooldown = true;

        yield return wait;

        _isLifeLeechOnCooldown = false;
    }
}
