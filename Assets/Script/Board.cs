using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject m_CellPrefab;

    private Cell[] m_Cells = new Cell[9];

    public void Build (Main main){
        for(int i = 0; i <= 8; i++){
            GameObject newCell = Instantiate(m_CellPrefab, transform);
            m_Cells[i] = newCell.GetComponent<Cell>();
            m_Cells[i].m_Main = main;
        } 
    }

    public void Reset(){
        foreach(Cell cell in m_Cells){
            cell.m_Label.text = "";

            cell.m_Button.interactable = true;
        }
    }

    public bool CheckForWinner(){
        int i = 0;

        //horizontal
        for(i = 0; i <= 6; i +=3){
            if(!CheckValues(i, i + 1)){
                continue;
            }

            if(!CheckValues(i, i + 2)){
                continue;
            }

            return true;
        }

        //vertical
        for(i = 0; i <= 2; i++){
            if(!CheckValues(i, i + 3)){
                continue;
            }

            if(!CheckValues(i, i + 6)){
                continue;
            }

            return true;
        }

        //left diagonal
        if(CheckValues(0, 4) && CheckValues(0, 8)){
            return true;
        }

        //right diagonal
        if(CheckValues(2, 4) && CheckValues(2, 6)){
            return true;
        }

        return false;
    }

    private bool CheckValues(int firstIndex, int secondIndex){
        string firstValue = m_Cells[firstIndex].m_Label.text;
        string secondValue = m_Cells[secondIndex].m_Label.text;

        if(firstValue == "" || secondValue == ""){
            return false;
        }

        if(firstValue == secondValue){
            return true;
        }
        else{
            return false;
        }
    }
}
