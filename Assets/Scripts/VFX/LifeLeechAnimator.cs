using System.Collections;
using UnityEngine;

public class LifeLeechAnimator : MonoBehaviour
{
    [SerializeField] private Animator _leftProjectileAnimator;
    [SerializeField] private Animator _rightProjectileaAnimator;
    [SerializeField] private LifeLeechCaster _lifeLeechCaster;
    [SerializeField] private CharacterStats _playerStats;

    private float _animationDuration;
    private string _isPlaying = "IsPlaying";

    private void Awake()
    {
        _animationDuration = _lifeLeechCaster.LifeLeechDuration;
    }

    private void OnEnable()
    {
        _lifeLeechCaster.AbilityCasted += PlayAnimation;
    }

    private void OnDisable()
    {
        _lifeLeechCaster.AbilityCasted -= PlayAnimation;
    }

    private void Update()
    {
        transform.position = _playerStats.transform.position;
    }

    private void PlayAnimation() 
    {
        StartCoroutine(StartAnimation());    
    }

    private IEnumerator StartAnimation() 
    {
        WaitForSeconds wait = new WaitForSeconds(_animationDuration);

        _leftProjectileAnimator.SetBool(_isPlaying, true);
        _rightProjectileaAnimator.SetBool(_isPlaying, true);

        yield return wait;

        _leftProjectileAnimator.SetBool(_isPlaying, false);
        _rightProjectileaAnimator.SetBool(_isPlaying, false);
    }
}
