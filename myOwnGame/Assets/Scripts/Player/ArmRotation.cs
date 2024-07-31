using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    [SerializeField] private int rotationOffset = 0;
    [SerializeField] private Camera mainCamera;

    private void Update()
    {
        // Проверка на наличие основной камеры
        if (mainCamera != null)
        {
            Vector3 difference = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize();

            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
        }
        else
        {
            Debug.LogError("Main Camera not found. Ensure that the main camera is tagged 'MainCamera'.");
        }
    }
}
