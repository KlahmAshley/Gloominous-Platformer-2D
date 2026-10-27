using UnityEngine;

public class ToggleFunnyHat : MonoBehaviour
{// player mover type ^

    public GameObject funnyHat; //Hat Object 

    public bool IsHatOn()
    {
        return funnyHat.activeSelf; //checks if hat is active for the bool
    }

    public void Toggle(bool isHatOn) //like the move void but with toggle for hat!
    {
        funnyHat.SetActive(isHatOn);  //if hat is on set it active 
       // Instantiate(funnyHat, Vector3.zero, Quaternion.identity); //currently will just set active but maybe we can have a bunch in final?
    }

   
}
