using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] characters;
    [HideInInspector]
    public int characterIndex;

    private void Awake() {
        MakeSingleton();
    }

    void Start()
    {
        characterIndex = 0;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }   

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (scene.name != "MainMenu")
        {
            print("Character Index: " + characterIndex);
            if (characterIndex != 0)
            {
                GameObject tommy = GameObject.FindGameObjectWithTag("Player");
                Instantiate(characters[characterIndex], tommy.transform.position, tommy.transform.rotation);
                tommy.SetActive(false);
            }
        }

    }
}
