using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class HistoryScene : MonoBehaviour
{
    public GameObject orderPrefab;
    public GameObject orderList;
    public GameObject transaction;

    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, dynamic> parsed = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(PlayerPrefs.GetString("menu_json"));
        JToken history = parsed["panels"][0];
        JToken orders = history["transactions"];
        int i = 0;
        foreach (JToken item in orders)
        {
            GameObject item_go = (GameObject)Instantiate(orderPrefab);
            item_go.transform.SetParent(transaction.transform, false);
            item_go.transform.position += new Vector3(0, -40 *i, 1);
            item_go.GetComponent<Text>().text = (string)item["order_id"];

            GameObject order_go = (GameObject)Instantiate(orderList);
            order_go.transform.SetParent(transaction.transform, false);
            order_go.transform.position += new Vector3(0, -40 * i++, 1);
            order_go.GetComponent<Text>().text = (string)item["order"];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
