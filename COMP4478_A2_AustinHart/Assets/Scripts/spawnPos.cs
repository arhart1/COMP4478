using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class spawnPos : MonoBehaviour
{
    public Sprite sp1;
    public Sprite sp2;
    public Sprite sp3;
    public Sprite sp4;
    public Sprite sp5;
    public Sprite sp6;
    public Sprite sp7;
    public Sprite sp8;
    public Sprite blank;

    public List<Sprite> spriteOrder = new List<Sprite>();
    public List<Sprite> mixed = new List<Sprite>();
    public Text gameText;
    public GameObject b;
    public bool spawned = false;

    public flip test;
    // Start is called before the first frame update
    void Start(){
        //Add every single sprite into a list twice, these are for which character goes to which card
        spriteOrder.Add(sp1);
        spriteOrder.Add(sp2);
        spriteOrder.Add(sp3);
        spriteOrder.Add(sp4);
        spriteOrder.Add(sp5);
        spriteOrder.Add(sp6);
        spriteOrder.Add(sp7);
        spriteOrder.Add(sp8);
        spriteOrder.Add(sp1);
        spriteOrder.Add(sp2);
        spriteOrder.Add(sp3);
        spriteOrder.Add(sp4);
        spriteOrder.Add(sp5);
        spriteOrder.Add(sp6);
        spriteOrder.Add(sp7);
        spriteOrder.Add(sp8);

        b =  GameObject.Find("Button");
        //Shuffle and set the game
        shuffle();
        setGame();
        StartCoroutine(blanked());
    }

    //Wait for 5 seconds and then flip the card
    public IEnumerator blanked(){
        for(int i = 5; i > 0; i--){
            gameText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        gameText.text = "";
        for(int i = 0; i < 16; i++){
            String name = "card" + (i+1).ToString();
            GameObject obj = GameObject.Find(name);
            test = obj.GetComponent<flip>();
            test.setBlank();
        }
    }

    //Iterate through the cards and set the character
    public void setGame(){
        b.SetActive(false);
        for(int i = 0; i < 16; i++){
            String name = "card" + (i+1).ToString();
            GameObject obj = GameObject.Find(name);
            test = obj.GetComponent<flip>();
            test.setChar();
        }
    }

    //Mix the order of the cards
    void shuffle(){
        var random = new System.Random();
        var list = spriteOrder.OrderBy(x => random.Next()).ToList();
        foreach(Sprite i in list){
           mixed.Add(i);
        }
    }

    public void OnButtonPress(){
        mixed = new List<Sprite>();
        shuffle();
        setGame();
        StartCoroutine(blanked());
    }

    // Update is called once per frame
    void Update(){
        
    }
}
