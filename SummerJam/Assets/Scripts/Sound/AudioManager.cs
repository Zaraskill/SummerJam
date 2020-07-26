using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private List<Sound> increaseVolume = new List<Sound>();
    private float speedIncrease = .1f;

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

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.initVolume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Update()
    {
        for (int i = increaseVolume.Count; i-->0;)
        {
            increaseVolume[i].volume += Time.deltaTime * speedIncrease;
            if (increaseVolume[i].volume >= increaseVolume[i].maxVolume)
            {
                increaseVolume[i].source.volume = increaseVolume[i].maxVolume;
                increaseVolume[i].volume = increaseVolume[i].maxVolume;
                increaseVolume.Remove(increaseVolume[i]);
            }
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + " not found!");
            return;
        }
        s.source.volume = s.maxVolume;
        s.source.Play();
    }

    public void PlayProgresif(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + " not found!");
            return;
        }
        increaseVolume.Add(s);
        s.source.volume = s.initVolume;
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + " not found!");
            return;
        }
        s.source.Stop();
    }
}
