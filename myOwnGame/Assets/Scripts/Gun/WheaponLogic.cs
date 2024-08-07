using UnityEngine;

public class WheaponLogic : MonoBehaviour
{
    [SerializeField] private Transform shotPos;
    [SerializeField] private GameObject shot;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Animator animator;

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
            Fire();
            timerToShot = 0.5f;
        }
    }

    private void Fire()
    {
        animator.SetTrigger("isShot");
        AudioManager.Instance.PlaySound("PistolShot");

        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - shotPos.position).normalized;

        GameObject newShot = Instantiate(shot, shotPos.position, Quaternion.identity);
        newShot.transform.right = direction;

        Shot shotScript = newShot.GetComponent<Shot>();
        if (shotScript != null)
        {
            shotScript.SetDirection(direction);
        }
    }
}
