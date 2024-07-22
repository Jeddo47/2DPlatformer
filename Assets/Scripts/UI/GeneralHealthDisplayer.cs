using UnityEngine;

public abstract class GeneralHealthDisplayer : MonoBehaviour
{
    [SerializeField] protected CharacterStats PlayerStats;

    private void OnEnable()
    {
        PlayerStats.HealthChanged += ChangeHealthDisplay;
    }

    private void OnDisable()
    {
        PlayerStats.HealthChanged -= ChangeHealthDisplay;
    }

    protected abstract void ChangeHealthDisplay(); 
}
