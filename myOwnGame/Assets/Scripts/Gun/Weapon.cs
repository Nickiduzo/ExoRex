using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform shotPos;
    [SerializeField] private GameObject shot;

    private float timerToShot;
    public void Start()
    {
        timerToShot = 0.5f;
    }

    public void Update()
    {
        timerToShot -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.G) && timerToShot <= 0)
        {
            GameObject newShot =  Instantiate(shot, shotPos.position, Quaternion.identity);
            Shot shotScript = newShot.GetComponent<Shot>();
            float horizontalDirection = Mathf.Sign(transform.localScale.x);
            shotScript.SetDirection(horizontalDirection);
            timerToShot = 0.3f;
        }
    }
}
