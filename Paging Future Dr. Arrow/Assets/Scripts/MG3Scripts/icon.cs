using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    public int iconID; // Set in Inspector (0-4, each pair shares an ID)
    public IconManager manager;

    public void OnClick()
    {
        manager.IconClicked(this);
    }
}
