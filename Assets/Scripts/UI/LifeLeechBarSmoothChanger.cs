using UnityEngine;
using UnityEngine.UI;

public class LifeLeechBarSmoothChanger : MonoBehaviour
{
    [SerializeField] private Slider _lifeLeechBar;
    [SerializeField] private LifeLeechBarSmoothAbilityTracker _abilityTracker;

    private void Update()
    {
        _lifeLeechBar.value = _abilityTracker.LeechBarValue;
    }
}
