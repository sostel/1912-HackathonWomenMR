using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

public class FollowBehavior : MonoBehaviour
{
    [SerializeField]
    private float minDistanceInMeters = 0.6f;

    [SerializeField]
    private float moveSpeed = 0.01f;

    [SerializeField]
    private bool isFollowing = true;

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(CameraCache.Main.transform.position); // TODO: Implement more natural behavior

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