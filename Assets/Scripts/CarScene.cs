using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class CarScene : MonoBehaviour
{
    public GameObject location, parked_at, valid_until;
    
    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, dynamic> parsed = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(PlayerPrefs.GetString("menu_json"));
        JToken car = parsed["panels"][1];
        location.GetComponent<Text>().text = (string) car["location"];
        parked_at.GetComponent<Text>().text = (string)car["parkedAt"];
        valid_until.GetComponent<Text>().text = (string)car["parkValidUntil"];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}