using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    [SerializeField] private int rotationOffset = 0;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform characterTransform;

    private void Update()
    {
        if (mainCamera != null)
        {
            Vector3 difference = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize();

            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        
            if (characterTransform.localScale.x < 0)
            {
                rotZ = 180 - rotZ;
                transform.rotation = Quaternion.Euler(0f, 0f, -rotZ + rotationOffset);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
            }
        }
        else
        {
            Debug.LogError("Main Camera not found. Ensure that the main camera is tagged 'MainCamera'.");
        }
    }
}
