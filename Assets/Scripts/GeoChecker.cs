using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GeoInfo
{
    public string country;
}

public class GeoChecker : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(CheckGeoLocation());
    }

    private IEnumerator CheckGeoLocation()
    {
        UnityWebRequest request = UnityWebRequest.Get("https://ipinfo.io/json");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string jsonResult = request.downloadHandler.text;
            Debug.Log("Received JSON: " + jsonResult);

            GeoInfo geoInfo = JsonUtility.FromJson<GeoInfo>(jsonResult);

            Debug.Log("Country: " + geoInfo.country);

            if (geoInfo.country == "UA")
            {
                Debug.Log("User is in Ukraine, remaining MainScene...");
            }
            else
            {
                Debug.Log("User is not in Ukraine, opening Wikipedia...");
                Application.OpenURL("https://uk.wikipedia.org/");
            }
        }
        else
        {
            Debug.LogError("Не вдалося отримати геолокацію.");
        }
    }
}
