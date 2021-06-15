using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using TMPro;

public class SettingSystem : MonoBehaviour
{
    [SerializeField]
    private Canvas settingsCanvas;
    [SerializeField]
    private Canvas creditsCanvas;
    [SerializeField]
    private Canvas copyrightCanvas;

    [SerializeField]
    private TMP_Dropdown dropdown;

    void Awake()
    {
        HideSettings();
        HideCredits();
        HideCopyright();

        if(LocalizationSettings.SelectedLocale.Identifier.CultureInfo.EnglishName == "English")
        {
            dropdown.value = 1;
        }
    }

    public void ShowSettings()
    {
        settingsCanvas.enabled = true;
    }

    public void HideSettings()
    {
        settingsCanvas.enabled = false;
        PlayerPrefs.Save();
    }

    public void ShowCredits()
    {
        creditsCanvas.enabled = true;
    }

    public void HideCredits()
    {
        creditsCanvas.enabled = false;
    }

    public void ShowCopyright()
    {
        copyrightCanvas.enabled = true;
    }

    public void HideCopyright()
    {
        copyrightCanvas.enabled = false;
    }

    public void LocaleSelected(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
}
