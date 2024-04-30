using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveInteract : MonoBehaviour, IInteractable
{
         LevelGold levelGold;
         Interactor interactor;
        public float getGoldPercent = 49f;
        public Canvas canvastext;
        

        void Start()
        {
            levelGold = GameObject.Find("GM").GetComponent<LevelGold>();
            interactor = GameObject.Find("Cam_holder").GetComponent<Interactor>();
            canvastext.gameObject.SetActive(false);
        }

        void Update()
        {
            if (interactor.seeTarget == false)
            {
                canvastext.gameObject.SetActive(false);
            }
           
        }
    	public void Interact()
        {
            if (levelGold != null)
            {
                
                    int randomAmount = Random.Range(0, 100);
                    if (randomAmount <= getGoldPercent)
                    {
                        levelGold.IncreaseGold();
                    }
                    else
                    {
                        Debug.Log("Leider kein Gold für dich");
                    }
                
            }
            Destroy(gameObject);
        }

        public void Visible()
        {
             canvastext.gameObject.SetActive(true);
        }
}
