using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LifeLeechBarSmoothChanger : MonoBehaviour
{
    [SerializeField] private Slider _lifeLeechBar;
    [SerializeField] private LifeLeechCaster _lifeLeechCaster;
    [SerializeField] private float _leechBarFillSpeed;

    private float _leechBarMinValue = 0;
    private float _leechBarMaxValue = 1;

    private void OnEnable()
    {
        _lifeLeechCaster.AbilityCasted += ChangeLifeLeechDisplay;
    }

    private void OnDisable()
    {
        _lifeLeechCaster.AbilityCasted -= ChangeLifeLeechDisplay;
    }

    private void ChangeLifeLeechDisplay() 
    {
        StartCoroutine(ShowAbilityDuration());            
    }

    private IEnumerator ShowAbilityDuration() 
    {
        WaitForSeconds wait = new WaitForSeconds(_lifeLeechCaster.LifeLeechDuration * _leechBarFillSpeed);

        while (_lifeLeechBar.value > _leechBarMinValue) 
        {
            ChangeSliderValue(_leechBarMinValue);

            yield return wait;
        }

        StartCoroutine(ShowAbilityCooldown());
    }

    private IEnumerator ShowAbilityCooldown() 
    {
        WaitForSeconds wait = new WaitForSeconds(_lifeLeechCaster.LifeLeechCooldown * _leechBarFillSpeed);

        while (_lifeLeechBar.value < _leechBarMaxValue)
        {
            ChangeSliderValue(_leechBarMaxValue);

            yield return wait;
        }
    }

    private void ChangeSliderValue(float targetValue) 
    {
        _lifeLeechBar.value = Mathf.MoveTowards(_lifeLeechBar.value, targetValue, _leechBarFillSpeed);
    }
}
