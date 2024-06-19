using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcFollower : MonoBehaviour
{
    public Transform player;
    private bool isFollowing;
    public Animator playerAnimator;
    public Animator npcAnimator;

    public void FollowPlayer()
    {
        transform.parent = player;
        transform.localPosition = new Vector3(0, 0, -1);
        transform.rotation = player.rotation;
        isFollowing = true;
    }

    private void Update()
    {
        if (isFollowing)
        {
            MirrorAnimation();
        }
    }

    void MirrorAnimation()
    {
        npcAnimator.SetFloat("Velocity", playerAnimator.GetFloat("Velocity"));
    }
}
