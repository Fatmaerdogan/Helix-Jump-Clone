using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public List<GameObject> Panels;
    private void Start()
    {
        GameManager.instance.GameEndActive += PanelSet;
    }
    public void PanelSet(bool temp)
    {
        Panels[0].SetActive(temp);
        Panels[1].SetActive(!temp);

    }
    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
