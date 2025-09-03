using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenUI : MonoBehaviour
{
    [SerializeField]
    private GameObject loseText;
    [SerializeField]
    private Button PlayButton;

    private void Awake()
    {
        loseText.SetActive(false);
        PlayButton.onClick.AddListener(Play);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowLoseScreen()
    {
        this.gameObject.SetActive(true);
        loseText.SetActive(true);
    }

    private void Play()
    {
        GameManager.Instance.StartGame();
        this.gameObject.SetActive(false);
    }
}
