using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class match : MonoBehaviour
{
    public Sprite firstPick;
    public int firstPlace;
    public Sprite secondPick;
    public int secondPlace;
    public List<int> numsLeft;
    public Text gameText;
    private GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        numsLeft = new List<int> {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
        gameText.text = "";
        button = GameObject.Find("Button");
        button.GetComponentInChildren<TextMeshProUGUI>().text = "Play Again";
    }

    // Update is called once per frame
    void Update()
    {
        //If theres no more cards left to match, display the "Win" and reset everything
        if(numsLeft.Count == 0){
            Debug.Log("You Win!");
            gameText.text = "Winner!";
            button.SetActive(true);
            numsLeft = new List<int> {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
            firstPlace = -1;
            secondPlace = -1;
            firstPick = null;
            secondPick = null;
        }
        //If both picks equal something, check if they match
        if(firstPick !=null && secondPick!=null){
            //If they match, remove them from the list and keep going
            if(firstPick.name == secondPick.name){
                numsLeft.Remove(firstPlace);
                numsLeft.Remove(secondPlace);
                
            }else{
                //Otherwise, reset the game and start the blanked function
                GameObject handler = GameObject.Find("spawnChars");
                numsLeft = new List<int> {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
                handler.GetComponent<spawnPos>().setGame();
                StartCoroutine(handler.GetComponent<spawnPos>().blanked());
            }
            //Reset the picks
            firstPlace = -1;
            secondPlace = -1;
            firstPick = null;
            secondPick = null;
        } 
    }
}
