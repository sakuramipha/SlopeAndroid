using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class URLButton : MonoBehaviour
{
    [SerializeField] private string URL = "";
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnPointerClick);
    }

    private void OnPointerClick()
    {
        if(URL == "" || URL == null)
        {
            Debug.LogError("URL is null or empty!");
            return;
        }
        Application.OpenURL(URL);
    }
}
