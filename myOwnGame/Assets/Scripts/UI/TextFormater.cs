using UnityEngine;

public class TextFormater : MonoBehaviour
{
    public static string FormatDescription(string description)
    {
        if(string.IsNullOrEmpty(description))
        {
            return description;
        }

        return description.Replace(". ", ".\n");
    }
}
