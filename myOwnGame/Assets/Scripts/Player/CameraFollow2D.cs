using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField] private GameObject followObject;
    [SerializeField] private float offSet;
    [SerializeField] private float offSetSmoothing;

    [SerializeField] private float upperLimit;
    [SerializeField] private float bottomLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float leftLimit;

    private Vector3 playerPosition;
    private void Update()
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

        transform.position = Vector3.Lerp(transform.position, playerPosition, offSetSmoothing * Time.deltaTime);

        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
            transform.position.z
            );
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
