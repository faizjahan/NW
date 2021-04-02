using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform menuItem in transform)
        {
            Debug.Log(this.name);
            menuItem.gameObject.GetComponent<Button>().onClick.AddListener(() => HandlePanel(menuItem.name));
            Debug.Log(menuItem.name);
        }
        
    }

    private void HandlePanel(string title)
    {
        Debug.Log(title);
        switch (title)
        {
            case "CarButton":
                SceneManager.LoadScene("CarScene");
                break;
            case "HistoryButton":
                SceneManager.LoadScene("HistoryScene");
                break;
            case "ShopButton":
                SceneManager.LoadScene("ShopScene");
                break;
            case "HomeButton":
                SceneManager.LoadScene("MainScene");
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
