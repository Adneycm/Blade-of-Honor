using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Advertisements;


public class InitializeAds : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string androidGameId;
    [SerializeField] private bool isTesting;

    private string gameId;


    private void Awake()
    {
#if UNITY_ANDROID
                gameId = androidGameId;
#elif UNITY_EDITOR
                gameId= androidGameId; // If you Havn't Switched the Platfrom...
#endif

        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, isTesting, this);
        }
    }


    public void OnInitializationComplete()
    {
        UnityEngine.Debug.Log("Ads Initialized...");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message) { }
}