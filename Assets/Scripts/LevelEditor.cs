using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelEditor : MonoBehaviour
{
    #region Singleton class: LevelEditor

    public static LevelEditor Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    #endregion

    public int objectsInScene;
    public int totalObjects;
    [SerializeField] Transform objectsParent;
    [SerializeField] ParticleSystem winFx;

    private void Start()
    {
        CountObjects();
    }

    void CountObjects()
    {
        totalObjects = objectsParent.childCount;
        objectsInScene = totalObjects;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }

    public void PlayWinFx()
    {
        winFx.Play();
    }
}
