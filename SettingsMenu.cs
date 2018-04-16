using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    private void Start()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality"));
    }

    public void Low()
    {
        QualitySettings.SetQualityLevel(0);
    }

    public void Medium()
    {
        QualitySettings.SetQualityLevel(2);
    }

    public void High()
    {
        QualitySettings.SetQualityLevel(4);
    } 

    public void Save()
    {
        PlayerPrefs.SetInt("quality", QualitySettings.GetQualityLevel());
        Debug.Log("Option Save");
    }
}
