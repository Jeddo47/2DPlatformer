using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSmoothChanger : GeneralHealthDisplayer
{    
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _healthBarFillSpeed;

    protected override void ChangeHealthDisplay()
    {
        StartCoroutine(HealthBarFill());
    }

    private IEnumerator HealthBarFill() 
    {        
        while (_healthBar.value != PlayerStats.HitPoints / PlayerStats.MaxHitPoints) 
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, PlayerStats.HitPoints / PlayerStats.MaxHitPoints, _healthBarFillSpeed * Time.deltaTime);

            yield return null;
        }        
    }
}
