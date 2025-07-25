using UnityEngine;
using UnityEngine.UI;

public class UIScroller : MonoBehaviour
{
    public ScrollRect scrollRect;

    public void ScrollToTop()
    {
        scrollRect.verticalNormalizedPosition = 1f; // Top
    }

    public void ScrollToBottom()
    {
        scrollRect.verticalNormalizedPosition = 0f; // Bottom
    }
}
