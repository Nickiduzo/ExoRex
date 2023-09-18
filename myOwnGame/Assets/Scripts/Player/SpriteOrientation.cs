using UnityEngine;

public class SpriteOrientation : MonoBehaviour
{
    private Transform currentTransform;

    private void Awake()
    {
        currentTransform = gameObject.transform;
    }

    public void Flip(float horizontalDirection)
    {
        if (horizontalDirection == 0f)
            return;

        if (Mathf.Sign(currentTransform.localScale.x) == -Mathf.Sign(horizontalDirection))
        {
            currentTransform.localScale = new Vector2(Mathf.Sign(horizontalDirection), currentTransform.localScale.y);
        }

    }
}
