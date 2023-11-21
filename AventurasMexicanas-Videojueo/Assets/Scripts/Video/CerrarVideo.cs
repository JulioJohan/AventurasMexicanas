using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CerrarVideo : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    private AudioSource[] allAudioSources;
    public AudioSource[] todosAudios;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        PauseAudio();
        PausarAudio();
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Play();
        videoPlayer.loopPointReached += EndReached;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
      
    }



    void CheckOver(VideoPlayer videoPlayer)
    {
        gameObject.SetActive(false);
    }

    // Función para pausar todos los sonidos
    void PausarAudio()
    {
        print(todosAudios.Length);
        for (int i = 0; i < todosAudios.Length; i++)
            todosAudios[i].Stop();
    }


    // Función para pausar todos los sonidos
    void PauseAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        print(allAudioSources.Length);
        for (int i = 0; i < allAudioSources.Length; i++)            
            allAudioSources[i].Pause();
    }

    // Función para reanudar todos los sonidos
    void ResumeAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        for (int i = 0; i < allAudioSources.Length; i++)
            allAudioSources[i].UnPause();
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        gameObject.SetActive(false);
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
        Time.timeScale = 1;
        ResumeAudio(); // Reanuda todos los sonidos
    }

}
