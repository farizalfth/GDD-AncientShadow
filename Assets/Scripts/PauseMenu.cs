using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;

    private void Start()
    {
        // Memastikan panel otomatis tertutup saat game dimulai
        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(false);
        }
        Time.timeScale = 1f; // Memastikan waktu game berjalan normal di awal
    }

    // Fungsi untuk tombol Menu (Hamburger Button)
    public void OpenMenu()
    {
        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(true);
            Time.timeScale = 0f; // Menghentikan game (pause)
        }
    }

    // Fungsi untuk tombol "Lanjut" (Next)
    public void Resume()
    {
        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(false);
            Time.timeScale = 1f; // Melanjutkan jalannya game
        }
    }

    // Fungsi untuk tombol "Restart"
    public void RestartGame()
    {
        Time.timeScale = 1f; // Reset waktu ke normal sebelum reload scene
        
        // Memuat ulang scene yang sedang aktif saat ini
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Fungsi untuk tombol "Back To Home"
    public void GoToHome()
    {
        Time.timeScale = 1f; // Reset waktu ke normal sebelum berpindah scene
        SceneManager.LoadScene("MainMenu"); // Memuat scene MainMenu (Gambar 2)
    }
}