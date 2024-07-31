using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform shotPos;
    [SerializeField] private GameObject shot;

    private float timerToShot;

    private void Start()
    {
        timerToShot = 0.5f;
    }

    private void Update()
    {
        timerToShot -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.G) && timerToShot <= 0)
        {
            AudioManager.Instance.PlaySound("PistolShot");
            GameObject newShot = Instantiate(shot, shotPos.position, shotPos.rotation);
            Shot shotScript = newShot.GetComponent<Shot>();
            shotScript.SetDirection(shotPos.right);
            timerToShot = 0.3f;
        }
    }
}
