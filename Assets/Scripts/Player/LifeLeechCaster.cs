using System;
using System.Collections;
using UnityEngine;

public class LifeLeechCaster : MonoBehaviour
{
    [SerializeField] private float _lifeLeechDuration;
    [SerializeField] private float _lifeLeechCooldown;
    [SerializeField] private float _lifeLeechTickDamage;
    [SerializeField] private float _lifeLeechTickDelay;
    [SerializeField] private CharacterStats _playerStats;
    [SerializeField] private LifeLeechAnimator _lifeLeechAnimator;

    private CharacterStats _enemyStats;
    private bool _isLifeLeechOnCooldown;

    public event Action AbilityCasted;

    public float LifeLeechDuration { get { return _lifeLeechDuration; } }
    public float LifeLeechCooldown { get {  return _lifeLeechCooldown; } }

    private void Awake()
    {
        _isLifeLeechOnCooldown = false;
    }

    private void Update()
    {
        transform.position = _playerStats.transform.position;

        CastLifeLeech();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyDamageTaker>(out EnemyDamageTaker enemy))
        {
            _enemyStats = enemy.GetComponent<CharacterStats>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyDamageTaker>(out _))
        {
            _enemyStats = null;
        }
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
            if (_enemyStats != null)
            {
                if (_playerStats.HitPoints < _playerStats.MaxHitPoints)
                {
                    _playerStats.ChangeHitPoints(_lifeLeechTickDamage);
                }

                _enemyStats.ChangeHitPoints(-_lifeLeechTickDamage);
            }

            yield return wait;
        }

        _lifeLeechAnimator.gameObject.SetActive(false);
    }

    private IEnumerator TrackCooldown()
    {
        WaitForSeconds wait = new WaitForSeconds(_lifeLeechCooldown);

        _isLifeLeechOnCooldown = true;

        yield return wait;

        _isLifeLeechOnCooldown = false;
    }
}
