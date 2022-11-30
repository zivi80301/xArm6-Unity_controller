using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource TestSound;

    private void Start()
    {
        TestSound = GetComponent<AudioSource>();
    }
    public void OnPlayButton()
    {
        TestSound.Play();
        print("Playing Sound");
    }
}
