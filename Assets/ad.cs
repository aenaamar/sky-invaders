/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class ad : MonoBehaviour
{
    BannerView bannerView;
    void Start()
    {
        bannerView = new BannerView("ca-app-pub-9363258902257936/3775325606", AdSize.Banner, AdPosition.Top);
        //body = GetComponent<Rigidbody>();
        MobileAds.Initialize(initStatus => { });
        var adRequest = new AdRequest();
        bannerView.LoadAd(adRequest);
    }
    // Update is called once per frame
    void Update()
    {

    }
}*/