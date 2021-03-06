﻿using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Ramps;
using System.Collections;

namespace Assets.Scripts.Levels
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private Image black_screen;
        [SerializeField]
        private GameObject settings_btn;
        [SerializeField]
        private GameObject create_ramp_btn;
        [SerializeField]
        private GameObject rotate_btn;
        [SerializeField]
        private GameObject delete_btn;
        [SerializeField]
        private GameObject move_btn;
        [SerializeField]
        private GameObject edit_btn;
        [SerializeField]
        private GameObject start_stop_simulation_btn;
        [SerializeField]
        private GameObject move_menu;
        [SerializeField]
        private GameObject rotate_menu;
        [SerializeField]
        private GameObject create_menu;
        [SerializeField]
        private GameObject ramp_type_dropdown;
        [SerializeField]
        private GameObject edit_menu;
        [SerializeField]
        private GameObject win_panel;
        [SerializeField]
        private GameObject retry_btn;
        [SerializeField]
        private GameObject next_level_btn;
        [SerializeField]
        private TMPro.TextMeshProUGUI win_text;
        [SerializeField]
        private GameObject[] coin_images;
        [SerializeField]
        private Sprite play_sprite;
        [SerializeField]
        private Sprite stop_sprite;
        [SerializeField]
        private Sprite settings_sprite;
        [SerializeField]
        private Sprite back_sprite;
        [SerializeField]
        private Sprite coin_sprite;
        [SerializeField]
        private Sprite no_coin_sprite;
        [SerializeField]
        private GameObject acceleration_panel;

        private void Start()
        {
            FadeBlackScreen();
        }

        public void FadeBlackScreen()
        {
            IEnumerator FadeBlackScreen()
            {
                for (float i = 1; i >= 0; i -= Time.deltaTime)
                {
                    // set color with i as alpha
                    black_screen.color = new Color(0, 0, 0, i);
                    yield return null;
                }
            }

            StartCoroutine(FadeBlackScreen());
        }

        public void AppearBlackScreen()
        {
            IEnumerator AppearBlackScreen()
            {
                for (float i = 0; i <= 1; i += Time.deltaTime)
                {
                    // set color with i as alpha
                    black_screen.color = new Color(0, 0, 0, i);
                    yield return null;
                }
            }
            StartCoroutine(AppearBlackScreen());
        }

        public void DisplayHideLevelManager(bool display)
        {
            if (display)
                settings_btn.GetComponent<Image>().sprite = back_sprite;
            else
                settings_btn.GetComponent<Image>().sprite = settings_sprite;
            create_ramp_btn.SetActive(display);
            rotate_btn.SetActive(display);
            delete_btn.SetActive(display);
            move_btn.SetActive(display);
            edit_btn.SetActive(display);
        }

        public void DisplayHideEditLevelBtn(bool display)
        {
            settings_btn.SetActive(display);
        }

        public void SetStopImage()
        {
            start_stop_simulation_btn.GetComponent<Image>().sprite = stop_sprite;
        }

        public void SetPlayImage()
        {
            start_stop_simulation_btn.GetComponent<Image>().sprite = play_sprite;
        }

        public void DisplayHideSimulation(bool display)
        {
            start_stop_simulation_btn.SetActive(display);
        }

        public void DisplayHideCoinIndicators(bool value)
        {
            for (int i = 0; i < coin_images.Length; i++)
                coin_images[i].SetActive(value);
        }

        public void FillCoinIndicator(int i)
        {
            if (i < Constants.COIN_NUMBER)
                coin_images[i].GetComponent<Image>().sprite = coin_sprite;
        }

        public void ResetCoinIndicator()
        {
            for (int i = 0; i < Constants.COIN_NUMBER; i++)
                coin_images[i].GetComponent<Image>().sprite = no_coin_sprite;
        }

        public void DisplayWinPopUp(int coins_picked)
        {
            retry_btn.GetComponent<Button>().interactable = true;
            next_level_btn.GetComponent<Button>().interactable = true;
            switch (coins_picked)
            {
                case 0:
                    win_text.text = "Puoi fare meglio!";
                    break;
                case 1:
                    win_text.text = "Bravino!";
                    break;
                case 2:
                    win_text.text = "Bravo!";
                    break;
                default:
                    win_text.text = "Bravissimo!";
                    break;
            }
            LeanTween.scaleX(win_panel, 1f, 0.25f);
            LeanTween.scaleY(win_panel, 1f, 0.25f);
        }

        public void HideWinPopUp()
        {
            retry_btn.GetComponent<Button>().interactable = false;
            next_level_btn.GetComponent<Button>().interactable = false;
            LeanTween.scaleX(win_panel, 0f, 0.25f);
            LeanTween.scaleY(win_panel, 0f, 0.25f);
        }

        public void DisplayHideMove(bool display)
        {
            settings_btn.SetActive(!display);
            move_menu.SetActive(display);
        }

        public void DisplayHideRotate(bool display)
        {
            settings_btn.SetActive(!display);
            rotate_menu.SetActive(display);
        }

        public void DisplayHideCreateRamp(bool display)
        {
            settings_btn.SetActive(!display);
            create_menu.SetActive(display);
            ramp_type_dropdown.SetActive(display);
            ramp_type_dropdown.GetComponent<Dropdown>().value = 0;
        }

        public void DisplayHideEditRamp(bool display)
        {
            settings_btn.SetActive(!display);
            edit_menu.SetActive(display);
        }

        public void EnableDisableInteractionPlaySettingsButtons(bool value)
        {
            start_stop_simulation_btn.GetComponent<Button>().interactable = value;
            settings_btn.GetComponent<Button>().interactable = value;
        }

        public void EnableDisableInteractionDeleteBtn(bool value)
        {
            delete_btn.GetComponent<Button>().interactable = value;
        }

        public void EnableDisableInteractionRampTypeDropdown(bool value)
        {
            ramp_type_dropdown.GetComponent<Dropdown>().interactable = value;
        }

        public void EnableDisableInteractionCreateRampBtn(bool value)
        {
            create_ramp_btn.GetComponent<Button>().interactable = value;
        }

        public void EnableDisableInteractionMoveBtn(bool value)
        {
            move_btn.GetComponent<Button>().interactable = value;
        }

        public void EnableDisableInteractionRotateBtn(bool value)
        {
            rotate_btn.GetComponent<Button>().interactable = value;
        }

        public void EnableDisableInteractionEditBtn(bool value)
        {
            edit_btn.GetComponent<Button>().interactable = value;
        }

        public void EnableDisableInteractionMenuEditBtn(bool value)
        {
            if (value)
            {
                create_ramp_btn.GetComponent<Button>().interactable = false;
                move_btn.GetComponent<Button>().interactable = true;
                delete_btn.GetComponent<Button>().interactable = true;
                delete_btn.GetComponent<Button>().interactable = true;
                rotate_btn.GetComponent<Button>().interactable = true;
                edit_btn.GetComponent<Button>().interactable = true;
            }
            else
            {
                create_ramp_btn.GetComponent<Button>().interactable = true;
                move_btn.GetComponent<Button>().interactable = false;
                delete_btn.GetComponent<Button>().interactable = false;
                delete_btn.GetComponent<Button>().interactable = false;
                rotate_btn.GetComponent<Button>().interactable = false;
                edit_btn.GetComponent<Button>().interactable = false;
            }
            EnableDisableInteractionRampTypeDropdown(!value);
        }

        public RampType GetRampType()
        {
            Dropdown dropdown = ramp_type_dropdown.GetComponent<Dropdown>();
            return (RampType)dropdown.value;
        }

        public void ShowAccelerationText()
        {
            acceleration_panel.SetActive(true);
        }

        public void HideAccelerationText()
        {
            if(acceleration_panel)
                acceleration_panel.SetActive(false);
        }
    }
}
