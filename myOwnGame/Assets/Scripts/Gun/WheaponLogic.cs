using UnityEngine;

public class WheaponLogic : MonoBehaviour
{
    [SerializeField] private Transform shotPos;
    [SerializeField] private GameObject shot;
    [SerializeField] private Camera mainCamera;

    private float timerToShot;

    private void Start()
    {
        timerToShot = 0.5f;
    }

    private void Update()
    {
        timerToShot -= Time.deltaTime;

        if (Input.GetMouseButton(0) && timerToShot <= 0)
        {
            AudioManager.Instance.PlaySound("PistolShot");
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (mousePosition - shotPos.position).normalized;

            GameObject newShot = Instantiate(shot, shotPos.position, Quaternion.identity);
            Shot shotScript = newShot.GetComponent<Shot>();
            shotScript.SetDirection(direction);
            timerToShot = 0.5f;
        }
    }
}
