using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Voice : MonoBehaviour
{
    public GameObject obj;
    public AudioClip clip1;
    private AudioSource audiosource;
    private float duration;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = clip1;
        audiosource.Play();
        duration = clip1.length;
        StartCoroutine(WaitForSound());
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(duration);
        print("FinishAudio");
    }
}
