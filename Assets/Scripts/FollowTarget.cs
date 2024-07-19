using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform leftLimit;
    [SerializeField] private Transform rightLimit;

    private Camera thisCamera;

    private void Awake()
    {
        thisCamera = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 bottomLeft = thisCamera.ViewportToWorldPoint(new Vector3(0, 0, thisCamera.nearClipPlane));
        Vector3 bottomRight = thisCamera.ViewportToWorldPoint(new Vector3(1, 0, thisCamera.nearClipPlane));

        bool canMoveRight = bottomRight.x < rightLimit.position.x;
        bool canMoveLeft = bottomLeft.x > leftLimit.position.x;

        float xDifference = target.position.x - transform.position.x;

        if (canMoveRight && xDifference > 0)
        {
            transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        }

        if (canMoveLeft && xDifference < 0)
        {
            transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        }
    }
}
