using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }

    void Start()
    {
        Sound s;
        if (Controller.flag == 0)
        {
            Play("Upside");
            s = Array.Find(sounds, sound => sound.name == "Upside");
            s.source.playOnAwake = true;
        }         
        else
        {
            Play("Downside");
            Controller.flag = 1;
            s = Array.Find(sounds, sound => sound.name == "Downside");
            s.source.playOnAwake = true;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void BackgroundPlay(int n)
    {
        Sound s;
        if(n == 1)
        {
                s = Array.Find(sounds, sound => sound.name == "Upside");
                s.source.Stop();
                s = Array.Find(sounds, sound => sound.name == "Downside");
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }
            s.source.Play();
            s.source.playOnAwake = true;
            s = Array.Find(sounds, sound => sound.name == "Upside");
            s.source.playOnAwake = false;
            Controller.flag = 1;

        }
        if(n == 0)
        {
            s = Array.Find(sounds, sound => sound.name == "Downside");
            s.source.Stop();
            s = Array.Find(sounds, sound => sound.name == "Upside");
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }
            s.source.Play();
            s.source.playOnAwake = true;
            s = Array.Find(sounds, sound => sound.name == "Downside");
            s.source.playOnAwake = false;
            Controller.flag = 0;
        }
    }

 /*   public void Pause()
    {

        Sound s;
        s = Array.Find(sounds, sound => sound.name == "Upside");
        if (s.source.isPlaying)
        {
            Flags.SoundFlag = 0;
            s.source.Stop();
        }
        else
        {
            s = Array.Find(sounds, sound => sound.name == "Downside");
            Flags.SoundFlag = 1;
            s.source.Stop();
        }
    } */

    public void Resume(int n)
    {
        Sound s;
        if(Flags.SoundFlag == 1)
        {
            s = Array.Find(sounds, sound => sound.name == "Downside");
            s.source.Play();
            Controller.flag = 1;
        }
        else
        {
            s = Array.Find(sounds, sound => sound.name == "Upside");
            s.source.Play();
            Controller.flag = 0;
        }
    }

    public void DestroyIt()
    {
        Destroy(gameObject);
    }
}
