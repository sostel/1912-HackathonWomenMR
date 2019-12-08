using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

public class FollowBehavior : MonoBehaviour
{
    [SerializeField]
    private float minDistanceInMeters = 0.6f;

    [SerializeField]
    private float moveSpeed = 0.01f;

    [SerializeField]
    private float turnSpeed = 1f;
    
    [SerializeField]
    private bool isFollowing = true;

    // Update is called once per frame
    void Update()
    {
        Turn();
        Follow();        
    }

    private void Turn() 
    {
        if (EyeTrackingTarget.LookedAtTarget == this.gameObject)
        {
            TurnToUser();
        }
        else
        {
            TurnToWhatUserIsLookingAt();
        }
    }

    private void TurnToUser() 
    {
        this.transform.LookAt(LerpLookAtPos(CameraCache.Main.transform.position)); // TODO: Implement more natural behavior
    }

    private Vector3 LerpLookAtPos(Vector3 destination) 
    {
        Vector3 origin = this.transform.position + this.transform.forward;
        return origin + (destination - origin).normalized * turnSpeed;
    }

    private void TurnToWhatUserIsLookingAt()
    {
        if (EyeTrackingTarget.LookedAtTarget == null)
        {
            TurnToUser();
        }
        else
        {
            this.transform.LookAt(LerpLookAtPos(EyeTrackingTarget.LookedAtPoint)); // TODO: Implement more natural behavior
        }
    }


    private void Follow ()
    {
        if (isFollowing)
        {
            Vector3 newPos = this.transform.position + (CameraCache.Main.transform.position - this.transform.position).normalized * moveSpeed;

            if (Vector3.Distance(CameraCache.Main.transform.position, newPos) > minDistanceInMeters)
            {
                this.transform.position = newPos;
            }
        }
    }
}