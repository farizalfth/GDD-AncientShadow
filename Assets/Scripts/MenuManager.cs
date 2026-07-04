using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject loadingCanvas;
    public GameObject menuUtama;    // Hubungkan ke "Menu Utama" di Hierarchy
    public GameObject settingsPanel; // Hubungkan ke "Settings" di Hierarchy
    public GameObject exitPanel;     // Hubungkan ke "Exit" di Hierarchy

    void Start()
    {
        // Saat game jalan, pastikan hanya Menu Utama yang muncul
        if(menuUtama != null) menuUtama.SetActive(true);
        if(settingsPanel != null) settingsPanel.SetActive(false);
        if(exitPanel != null) exitPanel.SetActive(false);
    }

    // --- FUNGSI UNTUK SETTINGS ---
    public void BukaSettings()
    {
        menuUtama.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void TutupSettings()
    {
        settingsPanel.SetActive(false);
        menuUtama.SetActive(true);
    }

    // --- FUNGSI UNTUK EXIT ---
    public void BukaPanelExit()
    {
        menuUtama.SetActive(false);
        exitPanel.SetActive(true);
    }

    public void TutupPanelExit()
    {
        exitPanel.SetActive(false);
        menuUtama.SetActive(true);
    }

    public void KeluarGameBeneran()
    {
        Debug.Log("Game Keluar");
        Application.Quit();
    }
}