using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public VideoPlayer videoPlayer; 

    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
     {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
     }
}
