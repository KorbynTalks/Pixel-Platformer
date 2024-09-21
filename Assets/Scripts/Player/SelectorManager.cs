using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorManager : MonoBehaviour
{
    public int selectedCharacter = 0;

    public void ChangeSelected(int whichCharacter)
    {
        selectedCharacter = whichCharacter;
    }
}
