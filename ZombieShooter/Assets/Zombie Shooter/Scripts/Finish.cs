using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {
    public GameObject WinPanel;
    public static int currentKills;
    public int Kills;//a number of kills needed to complete the level
    //(use 0 if you want to just reached the finish)
    //(make sure that the number of enemies on the level was not greater than the required amount of kills)
	void Start () {
        currentKills = 0;//reset
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag.Equals("Player") & currentKills >= Kills)//player reached the finish & killed enough enemies
        {
            WinPanel.SetActive(true);
            StartCoroutine(Win());
        }
    }

    IEnumerator Win()
    {
        AdManager.ShowInterstitialAd("1lcaf5895d5l1293dc",
            () => {
                Debug.LogError("--插屏广告完成--");

            },
            (it, str) => {
                Debug.LogError("Error->" + str);
            });
        WinPanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        PlayerPrefs.SetInt("money", MainMenu.MONEY);//saving money
        if (MainMenu.LEVELS <= Application.loadedLevel)//the last available level complited
        {
            MainMenu.LEVELS = Application.loadedLevel + 1;//the last available level number increase
            PlayerPrefs.SetInt("levels", MainMenu.LEVELS);//saving last available level number
        }
        Application.LoadLevel(0);//go to menu
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
