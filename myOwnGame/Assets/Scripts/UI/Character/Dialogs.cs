using UnityEngine;

public class Dialogs : MonoBehaviour
{
    [SerializeField] public Transform textPosition;
    private void Awake()
    {
        this.transform.position = textPosition.position;           
    }
    private void Update()
    {
        this.transform.position = textPosition.position;
    }
}
