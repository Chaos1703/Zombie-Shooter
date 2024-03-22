using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject characterSelectionPanel;
    public void StartMission1(){
        SceneManager.LoadScene("GamePlay1");
    }
    public void StartMission2(){
        SceneManager.LoadScene("GamePlay2");
    }
    public void StartMission3(){
        SceneManager.LoadScene("GamePlay3");
    }
    public void StartMission4(){
        SceneManager.LoadScene("GamePlay4");
    }

    public void OpenCharacterSelectionPanel(){
        characterSelectionPanel.SetActive(true);
    }  

    public void CloseCharacterSelectionPanel(){
        characterSelectionPanel.SetActive(false);
    }    

    public void SelectTommy(){
        GameManager.instance.characterIndex = 0;
    }
    public void SelectMary(){
        GameManager.instance.characterIndex = 1;
    }
}
