using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void ClickBtn()
    {
        AdManager.ShowVideoAd("192if3b93qo6991ed0",
            (bol) => {
                if (bol)
                {
                    Player.HP = Player.maxHP;
                    Player.instance.SetRevivePanel(false);
                    

                    AdManager.clickid = "";
                    AdManager.getClickid();
                    AdManager.apiSend("game_addiction", AdManager.clickid);
                    AdManager.apiSend("lt_roi", AdManager.clickid);


                }
                else
                {
                    StarkSDKSpace.AndroidUIManager.ShowToast("观看完整视频才能获取奖励哦！");
                }
            },
            (it, str) => {
                Debug.LogError("Error->" + str);
                //AndroidUIManager.ShowToast("广告加载异常，请重新看广告！");
            });

    }

    public void ClickNo()
    {
        Player.instance.SetRevivePanel(false);
        Player.instance.LoadDie();

    }

   

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

}
