using AppsFlyerSDK;
using UnityEngine;

public class AppsflyerManager : MonoBehaviour
{
    private const string devKey = "ytPuQc6oHMvGHLh83FVpdd";

    void Start()
    {
        AppsFlyer.initSDK(devKey, ToString());
        AppsFlyer.startSDK();
    }

}
