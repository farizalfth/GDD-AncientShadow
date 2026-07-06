using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahLevel : MonoBehaviour
{
    [SerializeField] private string namaSceneTujuan = "Level2";

    private void OnTriggerEnter(Collider other)
    {
        // Pesan ini akan muncul di tab Console jika ada benda yang masuk ke kotak hijau
        Debug.Log("Ada objek masuk ke sensor: " + other.name + " dengan Tag: " + other.tag);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Pemain terdeteksi! Berpindah ke " + namaSceneTujuan);
            SceneManager.LoadScene(namaSceneTujuan);
        }
    }
}