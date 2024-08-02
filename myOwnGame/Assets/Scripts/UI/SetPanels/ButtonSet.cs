using UnityEngine;

public class ButtonSet : MonoBehaviour
{
    private Stuff oneStuff;
    public void OnButtonClick()
    {
        CraftPanel.ActionRecipeRequire?.Invoke(oneStuff);
    }
}
