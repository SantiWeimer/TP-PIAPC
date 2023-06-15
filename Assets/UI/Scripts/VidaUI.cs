using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VidaUI : MonoBehaviour
{
    public int vidaui;
    
    private TextMeshProUGUI textMesh;

    private void Start() {

        textMesh = GetComponent<TextMeshProUGUI>();
        
    }

    private void Update() {
        
        textMesh.text = vidaui.ToString("0");
        
    }


}
