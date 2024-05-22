﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public string noteTextstr;
    public GameObject notice;
    public GameObject noteUI;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        text.text = noteTextstr;
        if (Input.GetKey(KeyCode.E))
        {
            noteUI.SetActive(true);
        }
        if (Input.GetKey(KeyCode.T))
        {
            noteUI.SetActive(false);
        }
        notice.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        notice.SetActive(false);
        noteUI.SetActive(false);
    }
}
