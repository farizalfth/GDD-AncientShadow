using UnityEngine;

public class ItemKunci : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Mencari script pengatur misi di dalam game
            MisiKoleksiWaktu misi = Object.FindFirstObjectByType<MisiKoleksiWaktu>();
            if (misi != null)
            {
                misi.TambahKunci();
            }

            // Hancurkan objek kunci setelah diambil
            Destroy(gameObject);
        }
    }
}