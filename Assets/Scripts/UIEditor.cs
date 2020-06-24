using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIEditor : MonoBehaviour
{
    #region Singleton class: LevelEditor

    public static UIEditor Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    #endregion

    [SerializeField] int sceneOffset;
    [SerializeField] TMP_Text nextLevelText;
    [SerializeField] TMP_Text currentLevelText;
    [SerializeField] Image progressFillImage;
    [SerializeField] TMP_Text levelCompletedText;
    [SerializeField] Image fadePanel;
    [SerializeField] Image tutoimage;
    [SerializeField] TMP_Text swiptostart;


    void Start()
    {
        FadeAtStart();
        progressFillImage.fillAmount = 0f;
        SetLevelProgressText();
    }

    private void Update()
    {
        touchcount();
    }

    void SetLevelProgressText()
    {
        int level = SceneManager.GetActiveScene().buildIndex + sceneOffset;
        currentLevelText.text = level.ToString();
        nextLevelText.text = (level + 1).ToString();
    }

    public void UpdateLevelProgress()
    {
        float val = 1f - ((float)LevelEditor.Instance.objectsInScene / LevelEditor.Instance.totalObjects);
        progressFillImage.DOFillAmount(val, .4f);
    }

    public void ShowLevelCompletedUI()
    {
        levelCompletedText.DOFade(1f, -6f).From(0f);
    }

    public void FadeAtStart()
    {
        fadePanel.DOFade(0f, 1.0f).From(0.7f);
    }

    public void touchcount()
    {
        
        if (Input.touchCount > 0)
        {
            
            tutoimage.enabled = false;    
            swiptostart.enabled = false;
        }
    }

}
