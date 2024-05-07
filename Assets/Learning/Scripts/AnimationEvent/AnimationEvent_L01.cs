using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationEvent_L01 : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _clip;
    [SerializeField] private AnimationEvent _animationEvent;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _clip = _animator.runtimeAnimatorController.animationClips[0];

        _animationEvent = new AnimationEvent();
        _animationEvent.time = 0.5f;
        _animationEvent.functionName = nameof(OnAnimationEvent);

        _clip.AddEvent(_animationEvent);
    }

    private void OnAnimationEvent()
    {
        Debug.Log("Event performed");
    }
}
