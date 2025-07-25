using UnityEngine;

public class IconManager : MonoBehaviour
{
    private Icon firstSelected = null;
    private Icon secondSelected = null;

    public void IconClicked(Icon clicked)
    {
        if (firstSelected == null)
        {
            firstSelected = clicked;
        }
        else if (secondSelected == null && clicked != firstSelected)
        {
            secondSelected = clicked;
            CheckMatch();
        }
    }

    void CheckMatch()
    {
        if (firstSelected.iconID == secondSelected.iconID)
        {
            // Match found: Move one icon to the other's position
            Vector3 targetPosition = secondSelected.transform.position;
            firstSelected.transform.position = targetPosition;

            // Destroy the second icon
            Destroy(secondSelected.gameObject);
        }

        // Reset selection either way
        firstSelected = null;
        secondSelected = null;
    }
}
