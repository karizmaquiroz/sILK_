using UnityEngine;

public class PControll : MonoBehaviour
{
    public GameObject clip;
    public GameObject clipTwo;
    public GameObject clipThree;

    public void SpawnClip() 
    {
        clip.SetActive(true);
    }
    public void SpawnClipTwo()
    {
        clipTwo.SetActive(true);
    }
    public void SpawnClipThree()
    {
        clipThree.SetActive(true);
    }
}
