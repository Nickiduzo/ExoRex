using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField] private GameObject followObject;
    [SerializeField] private float offSet;

    [SerializeField] private float upperLimit;
    [SerializeField] private float bottomLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float leftLimit;


    [SerializeField] private float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    private Vector3 playerPosition;
    private void FixedUpdate()
    {
        playerPosition = new Vector3(followObject.transform.position.x,transform.position.y, transform.position.z);

        if (followObject.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offSet, playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offSet, playerPosition.y, playerPosition.z);
        }

        transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity, smoothTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(rightLimit, upperLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit,upperLimit), new Vector2(rightLimit,bottomLimit));
    }
}
