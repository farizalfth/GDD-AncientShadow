using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour
{
    public float threshold = -10f;     // Ketinggian jatuh
    public Vector3 startPosition;      // Posisi awal
    public GameObject notificationUI;  // Objek teks (RespawnText)
    public float displayDuration = 2f; // Berapa lama teks muncul

    void Start()
    {
        // Simpan posisi awal karakter saat mulai game
        startPosition = transform.position;
        
        // Pastikan teks dalam keadaan MATI saat game baru mulai
        if (notificationUI != null)
            notificationUI.SetActive(false);
    }

    void Update()
    {
        // Jika karakter jatuh melewati batas threshold
        if (transform.position.y < threshold)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // Matikan CharacterController sebentar agar posisi bisa pindah
        CharacterController cc = GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        // Pindahkan ke posisi awal
        transform.position = startPosition;

        if (cc != null) cc.enabled = true;

        // Jalankan fungsi munculkan teks
        StopAllCoroutines();
        StartCoroutine(ShowNotification());
    }

    IEnumerator ShowNotification()
    {
        if (notificationUI != null)
        {
            notificationUI.SetActive(true); // Teks MUNCUL
            yield return new WaitForSeconds(displayDuration);
            notificationUI.SetActive(false); // Teks HILANG lagi
        }
    }
}