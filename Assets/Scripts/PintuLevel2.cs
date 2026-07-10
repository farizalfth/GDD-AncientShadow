using UnityEngine;
using UnityEngine.SceneManagement;

public class PintuLevel2 : MonoBehaviour
{
    public string namaLevelSelanjutnya = "Level2";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MisiKoleksiWaktu misi = Object.FindFirstObjectByType<MisiKoleksiWaktu>();
            if (misi != null && misi.ApakahPintuTerbuka())
            {
                SceneManager.LoadScene(namaLevelSelanjutnya);
            }
            else
            {
                Debug.Log("Pintu masih terkunci! Kumpulkan semua kunci terlebih dahulu.");
            }
        }
    }
}