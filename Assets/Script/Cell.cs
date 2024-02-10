using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Text m_Label;
    public Button m_Button;
    public Main m_Main;
    public void Fill(){
        m_Button.interactable = false;

        m_Label.text = m_Main.GetTurnCharacter();

        m_Main.Switch();
    }
}
