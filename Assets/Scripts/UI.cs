using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI lives;
    public TextMeshProUGUI bones;
    
    //Method to update the lives number in the UI
    public void UpdateLivesCounter()
    {
        lives.text = Manager.lives.ToString();
    }

    public void UpdateBoneCounter()
    {
        bones.text = Manager.bones.ToString();
    }
}
