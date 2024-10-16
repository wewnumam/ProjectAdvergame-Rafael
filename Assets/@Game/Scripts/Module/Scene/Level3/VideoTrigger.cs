using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoTrigger : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public double stopTime = 10.0; // Time (in seconds) when the video should stop
    public bool hasPaused = false; // To track if the video has been paused
    public UnityEvent onPause;
    public UnityEvent onEnd;

    void Start()
    {
        videoPlayer.Play();

        // Subscribe to the loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    // Event handler called when the video reaches its end
    void OnVideoEnd(VideoPlayer vp)
    {
        onEnd?.Invoke();
        // Add your custom notification logic here, such as UI updates or scene transitions
    }

    // Optionally, unsubscribe from the event when the object is destroyed
    void OnDestroy()
    {
        videoPlayer.loopPointReached -= OnVideoEnd;
    }

    void Update()
    {
        // Pause video at the specified stop time
        if (!hasPaused && videoPlayer.time >= stopTime)
        {
            onPause?.Invoke();
            videoPlayer.Pause();
            hasPaused = true;
        }
    }

    public void Resume()
    {
        videoPlayer.Play();
        hasPaused = false;
    }
}