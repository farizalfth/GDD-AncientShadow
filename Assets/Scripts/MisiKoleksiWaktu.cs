using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using System.Collections;

public class MisiKoleksiWaktu : MonoBehaviour
{
    [Header("Pengaturan Waktu")]
    public float waktuTersisa = 60f; 
    public Text waktuText; 

    [Header("Pengaturan Kunci")]
    public int totalKunciHarusDikumpulkan = 3; 
    private int jumlahKunciTerkumpul = 0;
    public Text jumlahKunciText; 

    [Header("Pengaturan UI Notifikasi & Game Over")]
    // DIUBAH KE GAMEOBJECT: Agar bisa menerima Gambar "TeksLevel"
    public GameObject notifikasiObject; 
    public GameObject panelGameOver; 

    private bool gameSelesai = false;
    private bool pintuTerbuka = false;

    private void Start()
    {
        Time.timeScale = 1f; 
        if (panelGameOver != null) panelGameOver.SetActive(false);
        
        // Sembunyikan gambar notifikasi saat awal permainan
        if (notifikasiObject != null) notifikasiObject.SetActive(false); 
        
        UpdateUIKunci();
    }

    private void Update()
    {
        if (gameSelesai) return;

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
        
        // Aktifkan gambar notifikasi di layar
        if (notifikasiObject != null)
        {
            notifikasiObject.SetActive(true);
            
            StopAllCoroutines(); 
            StartCoroutine(SembunyikanNotifikasiSetelahDetik(3f));
        }
    }

    // Coroutine untuk menyembunyikan gambar secara otomatis setelah beberapa detik
    private IEnumerator SembunyikanNotifikasiSetelahDetik(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (notifikasiObject != null)
        {
            notifikasiObject.SetActive(false); // Sembunyikan kembali
        }
    }

    public bool ApakahPintuTerbuka()
    {
        return pintuTerbuka;
    }

    void TriggerGameOver()
    {
        gameSelesai = true;
        Time.timeScale = 0; 
        
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(true);
        }
        else
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}