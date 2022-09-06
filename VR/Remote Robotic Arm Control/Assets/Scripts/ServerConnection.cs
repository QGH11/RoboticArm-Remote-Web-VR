using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class ServerConnection : MonoBehaviour
{
    public GameObject _slider1;
    public GameObject _slider2;
    public GameObject _slider3;
    public GameObject _slider4;
    public GameObject _slider5;
    public GameObject _slider6;
    private Slider slider1;
    private Slider slider2;
    private Slider slider3;
    private Slider slider4;
    private Slider slider5;
    private Slider slider6;
    public readonly Slider[] sliderList = new Slider[6];

    // Start is called before the first frame update
    void Start()
    {
        slider1 = _slider1.GetComponent<Slider>();
        slider2 = _slider2.GetComponent<Slider>();
        slider3 = _slider3.GetComponent<Slider>();
        slider4 = _slider4.GetComponent<Slider>();
        slider5 = _slider5.GetComponent<Slider>();
        slider6 = _slider6.GetComponent<Slider>();

        /*default motor degrees*/
        sliderList[0] = slider1;
        sliderList[1] = slider2;
        sliderList[2] = slider3;
        sliderList[3] = slider4;
        sliderList[4] = slider5;
        sliderList[5] = slider6;
        StartCoroutine(GetRequest("http://127.0.0.1:5000/receiver"));


        foreach (Slider s in sliderList)
        {
            s.onValueChanged.AddListener((value) =>
            {
                StartCoroutine(GetRequest("http://127.0.0.1:5000/receiver"));
            });
        }
       
    }
    
    IEnumerator GetRequest(string url)
    {

        WWWForm degreesForm = new();
        int i = 1;
        foreach (Slider s in sliderList)
        {
            degreesForm.AddField("" + i, s.value.ToString());
            i++;
        }
        
        /*Send Data*/
        using UnityWebRequest webRequest = UnityWebRequest.Post(url, degreesForm);
        yield return webRequest.SendWebRequest();
        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error: " + webRequest.error);

        }
        else
        {
            Debug.Log("Receiver Connected");
        }

        /*
                using UnityWebRequest webRequest = UnityWebRequest.Get(url);
                yield return webRequest.SendWebRequest();
                if (webRequest.result == UnityWebRequest.Result.ConnectionError)
                {
                    Debug.Log("Error: " + webRequest.error);

                }
                else
                {
                    Debug.Log("Receiver Connected");
                    foreach (Slider s in sliderList)
                    {
                        s.onValueChanged.AddListener((value) =>
                        {
                            *//*send new motor degrees*//*
                            Debug.Log("herre");
                        });
                    }
                }*/
    }
}
