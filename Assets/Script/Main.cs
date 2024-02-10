using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Board m_board;
    public GameObject m_Winner;
    public Text m_cursor;

    private bool m_XTurn = true;
    private int m_TurnCount = 0;

    void Awake(){
        m_board.Build(this);

        m_cursor.text =GetTurnCharacter();
    }

    public void Switch(){
        m_TurnCount++;

        bool hasWinner = m_board.CheckForWinner();

        if(hasWinner || m_TurnCount ==9){
            //end game
            StartCoroutine(EndGame(hasWinner));

            return;
        }

        m_XTurn = !m_XTurn;

        m_cursor.text =GetTurnCharacter();  
    }

    public string GetTurnCharacter(){
        if(m_XTurn){
            return "X";
        }
        else{
            return "O";
        }
    }

    private IEnumerator EndGame(bool hasWinner){
        Text winnerLabel = m_Winner.GetComponentInChildren<Text>();

        if(hasWinner){
            winnerLabel.text = GetTurnCharacter() + " " + "Won!";
        }
        else{
            winnerLabel.text = "Draw!";
        }

        m_Winner.SetActive(true);

        WaitForSeconds wait  = new WaitForSeconds(2.0f);
        yield return wait;

        m_board.Reset();
        m_TurnCount = 0;

        m_Winner.SetActive(false);
    }
}
