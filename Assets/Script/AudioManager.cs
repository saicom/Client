using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class AudioManager : UnitySingleton<AudioManager>
{
    private AudioSource bgAudioSource;                          //背景音频源

    private List<AudioSource> canUsedSoundList = new List<AudioSource>();                 //可用音频源

    private List<AudioSource> usedSoundList = new List<AudioSource>();                    //在用音频源

    private Dictionary<string, AudioClip> audioClipDic = new Dictionary<string, AudioClip>();         //缓存音频库

    private Dictionary<string, string> audioClipPath = new Dictionary<string, string>();           //音频库路径

    private float musicVolume = 0.4f;                              //背景音量

    private float soundVolume = 0.4f;                              //音效音量

    private int maxSoundPool = 3;                               //最多可用音频源数

    private AudioClip GetAudioClip(string clip)
    {
        if (!audioClipDic.ContainsKey(clip))
        {
            {
                AudioClip audioClip = Resources.Load<AudioClip>(clip);
                audioClip.LoadAudioData();
                audioClipDic.Add(clip, audioClip);
            }
        }
        return audioClipDic[clip];
    }

    public void PlayBackgroundMusic(AudioClip audioClip, bool loop = true)
    {
        if (bgAudioSource == null)
        {
            bgAudioSource = GameEntry.Instance.gameObject.AddComponent<AudioSource>();
        }
        if (bgAudioSource.clip == audioClip && bgAudioSource.isPlaying)
            return;
        if (audioClip)
        {
            bgAudioSource.clip = audioClip;
            bgAudioSource.clip.LoadAudioData();
            bgAudioSource.loop = loop;
            bgAudioSource.volume = musicVolume;
            bgAudioSource.Play();
        }
        else
        {
            Debug.LogErrorFormat("Play Background Music Failed! AudioClip name == {0}", audioClip.name);
        }
    }

    public void PlayBackgroundMusic(string clip, bool loop = true)
    {
        if (true)
        {
            PlayBackgroundMusic(GetAudioClip(clip), loop);
        }
    }


    public void StopBackgroundMusic()
    {
        if (bgAudioSource != null)
            bgAudioSource.Stop();
    }


    public void PlaySound(string clip)
    {
        if (clip == "")
        {
            return;
        }

        if (true)
        {
            PlaySound(GetAudioClip(clip));
        }

    }

    public void PlaySound(AudioClip audioClip)
    {
        if (audioClip)
        {
            if (canUsedSoundList.Count <= 0)
            {
                AddAudioSource();
            }
            AudioSource source = UnusedToUsed();
            source.clip = audioClip;
            source.clip.LoadAudioData();
            source.volume = soundVolume;
            source.loop = false;
            source.Play();
            StartCoroutine(WaitPlayEnd(source));
        }
        else
        {
            //Debug.LogErrorFormat("Play Sound Failed! AudioClip name == {0}", audioClip.name);
        }
    }



    IEnumerator WaitPlayEnd(AudioSource audioSource)
    {
        yield return new WaitUntil(() => { return !audioSource.isPlaying; });
        UsedToUnused(audioSource);
    }


    public bool IsPlaying(string clip)
    {
        for (int i = 0; i < usedSoundList.Count; i++)
        {
            if (usedSoundList[i].clip == GetAudioClip(clip))
                return true;
        }

        return false;
    }

    private AudioSource AddAudioSource()
    {
        if (canUsedSoundList.Count != 0)
        {
            return UnusedToUsed();
        }
        else
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            canUsedSoundList.Add(source);
            return source;
        }
    }

    private AudioSource UnusedToUsed()
    {
        AudioSource audioSource = canUsedSoundList[0];
        canUsedSoundList.RemoveAt(0);
        usedSoundList.Add(audioSource);
        return audioSource;
    }

    private void UsedToUnused(AudioSource audioSource)
    {
        usedSoundList.Remove(audioSource);

        if (canUsedSoundList.Count >= maxSoundPool)
        {
            Destroy(audioSource);
        }
        else
        {
            canUsedSoundList.Add(audioSource);
        }
    }

    public void ChangeMusicVolume(float volume)
    {
        musicVolume = volume;
        bgAudioSource.volume = volume;
    }

    public void ChangeSoundVolume(float volume)
    {
        soundVolume = volume;
        for (int i = 0; i < canUsedSoundList.Count; i++)
        {
            canUsedSoundList[i].volume = volume;
        }
        for (int i = 0; i < usedSoundList.Count; i++)
        {
            usedSoundList[i].volume = volume;
        }

    }


}
