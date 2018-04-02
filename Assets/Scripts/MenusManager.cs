using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenusManager : MonoBehaviour
{
    CanvasGroup CG_MainMenu;
    CanvasGroup CG_InGame;
    CanvasGroup CG_IG_Actions;
    CanvasGroup CG_IG_Audio;
    CanvasGroup CG_Pause;
    CanvasGroup CG_Options;

    public List<CanvasGroup> L_CanvasGroups = new List<CanvasGroup>();

    enum E_Menu { MainMenu, InGame, Pause, Options}
    E_Menu M_LastMenu = E_Menu.MainMenu;
    E_Menu M_ActualMenu = E_Menu.MainMenu;

	// Use this for initialization
	void Start ()
    {
        CG_MainMenu = GameObject.Find("Canvas/MainMenu").GetComponent<CanvasGroup>();
        CG_InGame = GameObject.Find("Canvas/InGame").GetComponent<CanvasGroup>();
        CG_IG_Actions = GameObject.Find("Canvas/InGame/IG_Actions").GetComponent<CanvasGroup>();
        CG_IG_Audio = GameObject.Find("Canvas/InGame/IG_AudioOnly").GetComponent<CanvasGroup>();
        CG_Pause = GameObject.Find("Canvas/Pause").GetComponent<CanvasGroup>();
        CG_Options = GameObject.Find("Canvas/Options").GetComponent<CanvasGroup>();

        L_CanvasGroups.Add(CG_MainMenu);//0
        L_CanvasGroups.Add(CG_InGame);//1
        L_CanvasGroups.Add(CG_Pause);//2
        L_CanvasGroups.Add(CG_Options);//3

        ModifyAlphaMenuInstantly(0);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ModifyAlphaMenuInstantly(int choice)
    {
        for (int i = 0; i < L_CanvasGroups.Count; i++)
        {
            if (i == choice)
            {
                L_CanvasGroups[i].alpha = 1;
                L_CanvasGroups[i].blocksRaycasts = true;
            }
            else
            {
                L_CanvasGroups[i].alpha = 0;
                L_CanvasGroups[i].blocksRaycasts = false;
            }
        }
    }

    public void ModifyAlphaMenuAnimated(int choice)
    {
        switch (choice)
        {
            case 0:
                DOTween.To(() => CG_MainMenu.alpha, x => CG_MainMenu.alpha = x, 1f, 1f).SetEase(Ease.InQuint);
                CG_MainMenu.blocksRaycasts = true;
                if (CG_InGame.alpha == 1)
                {
                    DOTween.To(() => CG_InGame.alpha, x => CG_InGame.alpha = x, 0f, 1f).SetEase(Ease.OutQuint);
                    CG_InGame.blocksRaycasts = false;
                }
                if (CG_Options.alpha == 1)
                {
                    DOTween.To(() => CG_Options.alpha, x => CG_Options.alpha = x, 0f, 1f).SetEase(Ease.OutQuint);
                    CG_Options.blocksRaycasts = false;
                }
                if (CG_Pause.alpha == 1)
                {
                    DOTween.To(() => CG_Pause.alpha, x => CG_Pause.alpha = x, 0f, 1f).SetEase(Ease.OutQuint);
                    CG_Pause.blocksRaycasts = false;
                }
                break;
            case 1:
                DOTween.To(() => CG_InGame.alpha, x => CG_InGame.alpha = x, 1f, 1f).SetEase(Ease.InQuint);
                CG_InGame.blocksRaycasts = true;
                if (CG_MainMenu.alpha == 1)
                {
                    DOTween.To(() => CG_MainMenu.alpha, x => CG_MainMenu.alpha = x, 0f, 1f).SetEase(Ease.OutQuint);
                    CG_MainMenu.blocksRaycasts = false;
                }
                if (CG_Options.alpha == 1)
                {
                    DOTween.To(() => CG_Options.alpha, x => CG_Options.alpha = x, 0f, 1f).SetEase(Ease.OutQuint);
                    CG_Options.blocksRaycasts = false;
                }
                if (CG_Pause.alpha == 1)
                {
                    DOTween.To(() => CG_Pause.alpha, x => CG_Pause.alpha = x, 0f, 1f).SetEase(Ease.OutQuint);
                    CG_Pause.blocksRaycasts = false;
                }
                break;
            case 2:
                DOTween.To(() => CG_Pause.alpha, x => CG_Pause.alpha = x, 1f, 1f).SetEase(Ease.InQuint);
                CG_Pause.blocksRaycasts = true;
                if (CG_MainMenu.alpha == 1)
                {
                    DOTween.To(() => CG_MainMenu.alpha, x => CG_MainMenu.alpha = x, 0f, 1f).SetEase(Ease.OutQuint);
                    CG_MainMenu.blocksRaycasts = false;
                }
                if (CG_Options.alpha == 1)
                {
                    DOTween.To(() => CG_Options.alpha, x => CG_Options.alpha = x, 0f, 1f).SetEase(Ease.OutQuint);
                    CG_Options.blocksRaycasts = false;
                }
                if (CG_InGame.alpha == 1)
                {
                    DOTween.To(() => CG_InGame.alpha, x => CG_InGame.alpha = x, 0f, 1f).SetEase(Ease.OutQuint);
                    CG_InGame.blocksRaycasts = false;
                }
                break;
            case 3:
                DOTween.To(() => CG_Options.alpha, x => CG_Options.alpha = x, 1f, 1f).SetEase(Ease.InQuint);
                CG_Options.blocksRaycasts = true;
                if (CG_MainMenu.alpha == 1)
                {
                    DOTween.To(() => CG_MainMenu.alpha, x => CG_MainMenu.alpha = x, 0f, 1f).SetEase(Ease.OutQuint);
                    CG_MainMenu.blocksRaycasts = false;
                }
                if (CG_Pause.alpha == 1)
                {
                    DOTween.To(() => CG_Pause.alpha, x => CG_Pause.alpha = x, 0f, 1f).SetEase(Ease.OutQuint);
                    CG_Pause.blocksRaycasts = false;
                }
                if (CG_InGame.alpha == 1)
                {
                    DOTween.To(() => CG_InGame.alpha, x => CG_InGame.alpha = x, 0f, 1f).SetEase(Ease.OutQuint);
                    CG_InGame.blocksRaycasts = false;
                }
                break;
        }
    }

    public void AnimatedTransToAudio()
    {
        DOTween.To(() => CG_IG_Audio.alpha, x => CG_IG_Audio.alpha = x, 1f, 2f).SetEase(Ease.InQuint).SetDelay(0.25f);
        if(CG_IG_Actions.alpha == 1)
        {
            DOTween.To(() => CG_IG_Actions.alpha, x => CG_IG_Actions.alpha = x, 0f, 2f).SetEase(Ease.InOutQuint).SetDelay(0.25f);
        }
    }

    public void AnimatedTransToAction()
    {
        DOTween.To(() => CG_IG_Actions.alpha, x => CG_IG_Actions.alpha = x, 1f, 2f).SetEase(Ease.InQuint).SetDelay(0.25f);
        if (CG_IG_Audio.alpha == 1)
        {
            DOTween.To(() => CG_IG_Audio.alpha, x => CG_IG_Audio.alpha = x, 0f, 2f).SetEase(Ease.InOutQuint).SetDelay(0.25f);
        }
    }

    public void StartGame()
    {
        Debug.Log("PLAY");
        M_LastMenu = E_Menu.MainMenu;
        M_ActualMenu = E_Menu.InGame;
        ModifyAlphaMenuAnimated(1);
        AnimatedTransToAudio();
    }

    public void OpenOptions()
    {
        if(M_ActualMenu == E_Menu.MainMenu)
        {
            M_LastMenu = E_Menu.MainMenu;
        }

        if (M_ActualMenu == E_Menu.InGame)
        {
            M_LastMenu = E_Menu.InGame;
        }

        if (M_ActualMenu == E_Menu.Pause)
        {
            M_LastMenu = E_Menu.Pause;
        }

        M_ActualMenu = E_Menu.Options;
        ModifyAlphaMenuAnimated(3);
    }

    public void CloseOptions()
    {
        if (M_LastMenu == E_Menu.MainMenu)
        {
            M_ActualMenu = E_Menu.MainMenu;
            ModifyAlphaMenuAnimated(0);
        }

        if (M_LastMenu == E_Menu.InGame)
        {
            M_ActualMenu = E_Menu.InGame;
            ModifyAlphaMenuAnimated(1);
        }

        if (M_LastMenu == E_Menu.Pause)
        {
            M_ActualMenu = E_Menu.Pause;
            ModifyAlphaMenuAnimated(2);
        }

        M_LastMenu = E_Menu.Options;
    }

    public void OpenPause()
    {
        M_ActualMenu = E_Menu.Pause;
        ModifyAlphaMenuAnimated(2);
    }

    public void ClosePauseIG()
    {
        M_ActualMenu = E_Menu.InGame;
        ModifyAlphaMenuAnimated(1);
    }

    public void ClosePauseExit()
    {
        M_ActualMenu = E_Menu.MainMenu;
        ModifyAlphaMenuAnimated(0);
    }
}
