using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public QuestManager questManager;
    public Animator talkPanel;
    public TypeEffect talk;
    public Text questTalk;
    public GameObject scanObject;
    public bool isAction;
    public TalkManager talkManager;
    public int talkIndex;
    public Image npcImage;
    public GameObject menuSet;
    public GameObject player;
    public GameObject saveSet;

    void Start()
    {
        GameLoad();
        questTalk.text = questManager.CheckQuest();

        if (questManager.questId == 0)
        {
            questManager.questId = 10;
        }
    }
    void Update()
    { 
        //Sub menu
        if(Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);
        }
    }
    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Talk(objData.id, objData.isNpc);

        talkPanel.SetBool("isShow" , isAction);
    }

    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = 0;
        string talkData = "";

        if (talk.isAni)
        {
            talk.SetMsg("");
            return;
        }
        else
        {
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        }

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            questTalk.text = questManager.CheckQuest(id);
            return;
        }

        if (isNpc)
        {
            talk.SetMsg(talkData.Split(':')[0]);

            npcImage.sprite = talkManager.GetNpcImage(id, int.Parse(talkData.Split(':')[1]));

            npcImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talk.SetMsg(talkData);
            npcImage.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }

    public void GameSave()
    {
        if(!PlayerPrefs.HasKey("PlayerX"))
        {
            PlayerPrefs.SetFloat("BasicPlayerX", player.transform.position.x);
            PlayerPrefs.SetFloat("BasicPlayerY", player.transform.position.y);
        }

        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetInt("QuestId", questManager.questId);
        PlayerPrefs.SetInt("QuestActionIndex", questManager.questActionIndex);
        PlayerPrefs.Save();

        menuSet.SetActive(false);

        Invoke("saveText", 2);
    }

    public void GameLoad()
    {
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questId = PlayerPrefs.GetInt("QuestId");
        int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");

        player.transform.position = new Vector2(x, y);
        questManager.questId = questId;
        questManager.questActionIndex = questActionIndex;
        questManager.ControlObject();
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void saveText()
    {
        saveSet.SetActive(false);
    }
}
