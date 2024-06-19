using UnityEngine;

public class NpcFollower : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator npcAnimator;

    private bool isFollowing;

    private void LateUpdate()
    {
        if (isFollowing == true)
        {
            FollowPlayer();
            MirrorAnimation();
        }
    }

    public void FollowPlayer()
    {
        transform.parent = player;
        transform.localPosition = new Vector3(0, 0, -0.2f);
        transform.rotation = player.rotation;
    }
    public void StartFollowing() => isFollowing = true;
    public void StopFollowing() => isFollowing = false;
    private void MirrorAnimation()
    {
        npcAnimator.SetFloat("Velocity", playerAnimator.GetFloat("Velocity"));
    }
}
