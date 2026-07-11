using UnityEngine;
using UnityEngine.SceneManagement; // Tambahkan ini untuk pindah scene
using System.Collections; // Tambahkan ini jika ingin pakai loading delay (opsional)

public class MenuManager : MonoBehaviour
{
    [Header("Panel References")]
    public GameObject menuUtama;
    public GameObject settingsPanel;
    public GameObject exitPanel;
    public GameObject loadingCanvas;

    [Header("Scene Settings")]
    public string namaSceneLevel1 = "Level1";

    void Start()
    {
        // 1. OTOMATISASI AWAL (Memaksa semua panel mati di awal tanpa perlu mematikan ceklis di Editor)
        if (settingsPanel != null) settingsPanel.SetActive(false);
        if (exitPanel != null) exitPanel.SetActive(false);

        // 2. Tampilkan loading canvas dulu sebagai intro
        if (loadingCanvas != null) loadingCanvas.SetActive(true);
        if (menuUtama != null) menuUtama.SetActive(false);

        // 3. Jalankan fungsi untuk menutup loading setelah beberapa detik
        Invoke("TutupLoadingIntro", 2.0f); // Muncul loading selama 2 detik
    }

    void TutupLoadingIntro()
    {
        if (loadingCanvas != null) loadingCanvas.SetActive(false);
        if (menuUtama != null) menuUtama.SetActive(true);
    }

    // --- FUNGSI UNTUK START GAME ---
    public void MulaiGame()
    {
        // Jika ada loading canvas, tampilkan dulu sebelum pindah
        if (loadingCanvas != null)
        {
            loadingCanvas.SetActive(true);
            // Memulai proses pindah scene (bisa ditambah delay jika mau)
            Invoke("PindahKeLevel1", 0.5f);
        }
        else
        {
            PindahKeLevel1();
        }
    }

    private void PindahKeLevel1()
    {
        SceneManager.LoadScene(namaSceneLevel1);
    }

    // --- FUNGSI UNTUK SETTINGS ---
    public void BukaSettings()
    {
        TampilkanHanya(settingsPanel);
    }

    public void TutupSettings()
    {
        TampilkanHanya(menuUtama);
    }

    // --- FUNGSI UNTUK EXIT ---
    public void BukaPanelExit()
    {
        TampilkanHanya(exitPanel);
    }

    public void TutupPanelExit()
    {
        TampilkanHanya(menuUtama);
    }

    public void KeluarGameBeneran()
    {
        Debug.Log("Game Keluar...");
        Application.Quit();
    }

    // --- HELPER FUNCTION (Agar kode lebih bersih) ---
    // Fungsi ini otomatis mematikan semua panel dan menyalakan yang dipilih
    private void TampilkanHanya(GameObject panelYangAktif)
    {
        if (menuUtama != null) menuUtama.SetActive(menuUtama == panelYangAktif);
        if (settingsPanel != null) settingsPanel.SetActive(settingsPanel == panelYangAktif);
        if (exitPanel != null) exitPanel.SetActive(exitPanel == panelYangAktif);
    }
}