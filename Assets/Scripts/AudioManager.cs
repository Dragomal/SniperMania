using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance{ get; private set;}
    [SerializeField] AudioSource source;

    private void Awake(){
        Instance = this;
    }
    public void PlaySFX(AudioClip clipToPlay){
        source.PlayOneShot(clipToPlay);
    }
}