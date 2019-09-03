using System;
using System.Collections;
using System.Collections.Generic;
using Const;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResourcesService : Singleton<ResourcesService>
{
    private Dictionary<string, AudioClip> AudioClipCacheDic = new Dictionary<string, AudioClip>();
    private Action prgCB = null;
    public override void InitSvc()
    {
        Debug.Log("Init ResourcesService...");
    }
    
    public AudioClip LoadAudioClip(string name,bool isCache = false)
    {
        AudioClip audioClip = null;
        if (!AudioClipCacheDic.TryGetValue(name, out audioClip))
        {
            audioClip = Resources.Load<AudioClip>(Consts.AUDIO_PATH + name);
        }

        if (isCache)
        {
            AudioClipCacheDic.Add(name,audioClip);
        }
        return audioClip;
    }
    public void AsyncLoadScene(int index, Action loaded) {
        AsyncOperation sceneAsync = SceneManager.LoadSceneAsync(index);
        prgCB = () => {
            float val = sceneAsync.progress;
            if (val == 1) {
                if (loaded != null) {
                    loaded();
                }
                prgCB = null;
                sceneAsync = null;
            }
        };
    }
    private void Update()
    {
        if (prgCB != null)
        {
            prgCB();
        }
    }

}
