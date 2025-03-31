using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelsChooser : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    void Start()
    {
        int maxLevel;
        SaveManager.data.MaxLevel = 1;
        maxLevel = SaveManager.data.MaxLevel;



        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            Match levelNum = Regex.Match(child.name, @"\((\d+)\)");
            if (levelNum.Success)
            {
                if (int.Parse(levelNum.Groups[1].Value) <= maxLevel)
                {
                    child.GetComponent<Button>().onClick.AddListener(() =>
                    {
                        audioSource.PlayOneShot(audioClip);
                        //SceneManager.LoadScene(int.Parse(levelNum.Groups[1].Value));
                        Debug.Log("scene load" + int.Parse(levelNum.Groups[1].Value));
                    });
                    child = null;
                }
                else
                    child.GetComponent<Button>().interactable = false;
            }
        }
    }
    int f()
    {
        return 3;
    }
}
