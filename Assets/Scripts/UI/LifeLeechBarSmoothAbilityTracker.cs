using System.Collections;
using UnityEngine;

public class LifeLeechBarSmoothAbilityTracker : MonoBehaviour
{
    [SerializeField] private LifeLeechCaster _lifeLeechCaster;
    [SerializeField] private float _leechBarFillSpeed;

    private float _leechBarMinValue = 0;
    private float _leechBarMaxValue = 1;
    private float _leechBarValue = 1;

    public float LeechBarValue => _leechBarValue;

    private void OnEnable()
    {
        _lifeLeechCaster.AbilityCasted += TrackAbilityCast;               
    }

    private void OnDisable()
    {
        _lifeLeechCaster.AbilityCasted -= TrackAbilityCast;
    }

    private void TrackAbilityCast() 
    {
        StartCoroutine(TrackAbilityDuration());            
    }

    private IEnumerator TrackAbilityDuration() 
    {
        WaitForSeconds wait = new WaitForSeconds(_lifeLeechCaster.LifeLeechDuration * _leechBarFillSpeed);

        while (_leechBarValue > _leechBarMinValue)
        {
            ChangeSliderValue(_leechBarMinValue);

            yield return wait;
        }

        StartCoroutine(TrackAbilityCooldown());
    }

    private IEnumerator TrackAbilityCooldown() 
    {
        WaitForSeconds wait = new WaitForSeconds(_lifeLeechCaster.LifeLeechCooldown * _leechBarFillSpeed);

        while (_leechBarValue < _leechBarMaxValue)
        {
            ChangeSliderValue(_leechBarMaxValue);

            yield return wait;
        }
    }

    private void ChangeSliderValue(float targetValue)
    {
        _leechBarValue = Mathf.MoveTowards(_leechBarValue, targetValue, _leechBarFillSpeed);
    }
}
