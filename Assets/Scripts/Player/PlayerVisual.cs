using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;

    public void SetVelocity(float velocity, float maxSpeed)
    {
        if (velocity == 0.0f && _playerAnimator.speed != 1.0f) _playerAnimator.speed = 1.0f;
        else if(velocity != 0.0f)
        {
            float animatorSpeed = MapValue(velocity, 0.0f, 1.0f, 0.0f, maxSpeed, true);
            _playerAnimator.speed = animatorSpeed;
        }
        _playerAnimator.SetFloat("Velocity", velocity);
    }

    public void SetCrouching(bool isCrouching) => _playerAnimator.SetBool("Crouching", isCrouching);
    public void Play(string clipName) => _playerAnimator.Play(clipName);

    private float MapValue(float value, float originalMin, float originalMax, float newMin, float newMax, bool clamp)
    {
        float newValue = (value - originalMin) / (originalMax - originalMin) * (newMax - newMin) + newMin;
        if (clamp == true)
            newValue = Mathf.Clamp(newValue, newMin, newMax);
        return newValue;
    }
}
