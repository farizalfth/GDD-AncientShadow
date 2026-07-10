using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class MisiKoleksiWaktu : MonoBehaviour
{
    [Header("Pengaturan Waktu")]
    public float waktuTersisa = 60f; // 60 detik (1 menit)
    public Text waktuText; // Drag UI Text Timer ke sini

    [Header("Pengaturan Kunci")]
    public int totalKunciHarusDikumpulkan = 3; // Jumlah kunci yang disebar
    private int jumlahKunciTerkumpul = 0;
    public Text jumlahKunciText; // Drag UI Text "Kunci: 0/3" ke sini

    [Header("Pengaturan UI Notifikasi & Game Over")]
    public Text notifikasiText; // Drag UI Text Notifikasi ke sini
    public GameObject panelGameOver; // Drag UI Panel Game Over ke sini (opsional)

    private bool gameSelesai = false;
    private bool pintuTerbuka = false;

    private void Start()
    {
        Time.timeScale = 1f; // Pastikan waktu berjalan normal saat start
        if (panelGameOver != null) panelGameOver.SetActive(false);
        if (notifikasiText != null) notifikasiText.text = "";
        UpdateUIKunci();
    }

    private void Update()
    {
        if (gameSelesai) return;

        // Sistem Hitung Mundur Waktu
        if (waktuTersisa > 0)
        {
            waktuTersisa -= Time.deltaTime;
            DisplayTime(waktuTersisa);
        }
        else
        {
            waktuTersisa = 0;
            TriggerGameOver();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        if (waktuText != null)
        {
            waktuText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void TambahKunci()
    {
        if (gameSelesai) return;

        jumlahKunciTerkumpul++;
        UpdateUIKunci();

        if (jumlahKunciTerkumpul >= totalKunciHarusDikumpulkan)
        {
            BukaPintu();
        }
    }

    void UpdateUIKunci()
    {
        if (jumlahKunciText != null)
        {
            jumlahKunciText.text = "Kunci: " + jumlahKunciTerkumpul + " / " + totalKunciHarusDikumpulkan;
        }
    }

    void BukaPintu()
    {
        pintuTerbuka = true;
        if (notifikasiText != null)
        {
            notifikasiText.text = "Pintu Level 2 Terbuka!";
        }
    }

    public bool ApakahPintuTerbuka()
    {
        return pintuTerbuka;
    }

    void TriggerGameOver()
    {
        gameSelesai = true;
        Time.timeScale = 0; // Menghentikan pergerakan game
        
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(true);
        }
        else
        {
            // Jika Anda tidak punya panel GameOver, game akan langsung restart otomatis
            RestartGame();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}