using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{

    //public GameObject buttonPrefab;
   
        // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetText());
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    /*For Dynamic Menu
    private void HandlePanel(string title, JToken panel)
    {
        Debug.Log(title);
        switch (title)
        {
            case "car":
                SceneManager.LoadScene("CarScene");
                break;
            case "history":
                SceneManager.LoadScene("HistoryScene");
                break;
            case "shop":
                SceneManager.LoadScene("ShopScene");
                break;
            default:
                break;
        }
    }*/

    IEnumerator GetText()
    {
        UnityWebRequest www = new UnityWebRequest("https://bitbybyte.fi/narwhale/panels.json");
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
            string menu = www.downloadHandler.text;
            PlayerPrefs.SetString("menu_json",menu);
            Dictionary<string, dynamic> parsed = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(menu);
            Debug.Log(parsed["panels"][0].title);

            /*For Dynamically generated buttons
            for (int i = 0; i < parsed["panels"].Count; i++)
            {
                GameObject goButton = (GameObject)Instantiate(buttonPrefab);
                goButton.transform.SetParent(this.transform, false);
                goButton.transform.position = new Vector3(i * 80 + 70, 485, 1);

                JToken panel = parsed["panels"][i];

                string title = (string) (panel["title"] ?? panel["tittle"]);

                Button tempButton = goButton.GetComponent<Button>();
                tempButton.onClick.AddListener(() => HandlePanel(title, panel));

                goButton.transform.GetChild(0).GetComponent<Text>().text = title;

                foreach (JProperty x in panel)
                {
                    string name = x.Name;
                    JToken value = x.Value;
                    Debug.Log(name);
                }
            }*/
        }

    }
}