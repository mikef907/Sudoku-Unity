using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProcessDeepLinkMngr : MonoBehaviour
{
    public static ProcessDeepLinkMngr Instance { get; private set; }
    public Uri deeplinkURI;
    public int seed;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Application.deepLinkActivated += onDeepLinkActivated;
            if (!String.IsNullOrEmpty(Application.absoluteURL))
            {
                // Cold start and Application.absoluteURL not null so process Deep Link.
                onDeepLinkActivated(Application.absoluteURL);
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void onDeepLinkActivated(string url)
    {
        // Update DeepLink Manager global variable, so URL can be accessed from anywhere.
        // ex https://playsudoku.app/seed/119537084
        try
        {
            deeplinkURI = new Uri(url);

            var val = deeplinkURI.Segments[2];

            if (!string.IsNullOrEmpty(val) && int.TryParse(val, out seed))
                SceneManager.LoadScene("Game");
        }
        catch (Exception ex)
        { 
        
        }
    }
}
