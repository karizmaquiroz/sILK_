using Unity.VisualScripting;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    int gState = 0;
    float speed = 1.0f;
    bool lvl1Complete = false;
    bool lvl2Complete = false;
    bool lvl3Complete = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (lvl1Complete == true) {
            
        }
        if (lvl2Complete == true) {

        }
        if (lvl3Complete == true) {

        }
    }

    //public static int StateSet(int lvl){
        //switch (gState) {
        //    case 1:
            // blah
       //     break;
      //      case 2:
            //blah
           // break;
      // default:
       //     break;
        //}
       // }

}
