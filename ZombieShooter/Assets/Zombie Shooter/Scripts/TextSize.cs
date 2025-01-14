using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TextSize : MonoBehaviour {//proportional size of the text
    
    public int Size;//1-3 (coefficient)

	void Start () {
        if (GetComponent<TMP_Text>()!=null)
        {
            GetComponent<TMP_Text>().fontSize = Mathf.FloorToInt(Screen.width / 100) * Size;//stretching the size of the text to the width of screen
        }
        else if(GetComponent<Text>() != null)
        {
            GetComponent<Text>().fontSize = Mathf.FloorToInt(Screen.width / 100) * Size;//stretching the size of the text to the width of screen
        }
        
	}
    void Update() {//for testing
        //GetComponent<Text>().fontSize = Mathf.FloorToInt(Screen.width/100) * Size;//dynamic stretching the size of the text to the width of screen
    }
}
