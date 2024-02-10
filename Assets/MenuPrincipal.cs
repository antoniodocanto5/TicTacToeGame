using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private string nomeLevelDeJogo;
    [SerializeField] private GameObject PainelMenuInicial;
    [SerializeField] private GameObject PainelOpcoes;  // Corrigido para ser do tipo GameObject

    public void jogar()
    {
        SceneManager.LoadScene(nomeLevelDeJogo);
    }

    public void AbriOpcoes()
    {
        PainelMenuInicial.SetActive(false);
        PainelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        PainelOpcoes.SetActive(false);
        PainelMenuInicial.SetActive(true);
    }

    public void SairJogo()
    {
        Application.Quit();
    }
}
