using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField]
    private float speedValue = 0.3f;

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speedValue);
    }
}
