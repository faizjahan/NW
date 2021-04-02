using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class ShopScene : MonoBehaviour
{

    public GameObject itemPrefab;
    public GameObject catalog;
    
    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, dynamic> parsed = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(PlayerPrefs.GetString("menu_json"));
        JToken shop = parsed["panels"][2];
        JToken items = shop["catalog"];
        int i = 0;
        foreach(JToken item in items)
        {
            GameObject item_go = (GameObject)Instantiate(itemPrefab);
            item_go.transform.SetParent(catalog.transform, false);
            item_go.transform.position += new Vector3(0, -40*i++, 1);
            item_go.GetComponent<Text>().text = (string)item["name"];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
