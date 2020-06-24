using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UnderGroundScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (!Game.isGameover)
        {
            string tag = other.tag;

            if (tag.Equals("Object"))
            {
                Debug.Log("object");
 
                LevelEditor.Instance.objectsInScene--;
                UIEditor.Instance.UpdateLevelProgress();
                Destroy(other.gameObject);
                

                if(LevelEditor.Instance.objectsInScene == 0)
                {
                    UIEditor.Instance.ShowLevelCompletedUI();
                    LevelEditor.Instance.PlayWinFx();

                    Invoke("NextLevel", 2f);
                }
            }
            if (tag.Equals("Obstacle"))
            {
                
                Handheld.Vibrate();
                Game.isGameover = true;
                Camera.main.transform.DOShakePosition(1f, .2f, 20, 90f).OnComplete(() =>
                {
                    LevelEditor.Instance.RestartLevel();
                });
            }
        }
    }

    void NextLevel()
    {
        LevelEditor.Instance.LoadNextLevel();
    }
}
