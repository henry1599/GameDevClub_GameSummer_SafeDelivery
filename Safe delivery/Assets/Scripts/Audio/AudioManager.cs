using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            //s.source.spatialBlend = 1;
        }
    }

    private void Start()
    {
        if (SharedUI.CURRENT_SCENE == "Start menu")
        {
            Play("Begin");
        }
        else if (SharedUI.CURRENT_SCENE == "Gameplay" || SharedUI.CURRENT_SCENE == "Tutorial")
        {
            Play("Theme");
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, s => s.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound :" + name + " not found");
            return;
        }
        s.source.Play();
    }

    public Sound GetSound(string name)
    {
        Sound s = Array.Find(sounds, s => s.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound :" + name + " not found");
            return null;
        }
        return s;
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, s => s.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound :" + name + " not found");
            return;
        }
        s.source.Stop();
    }
}
