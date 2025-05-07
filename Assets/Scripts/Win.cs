using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public SpriteRenderer one;
    public SpriteRenderer two;
    public SpriteRenderer three;
    public SpriteRenderer four;
    public SpriteRenderer five;
    public SpriteRenderer six;
    public SpriteRenderer seven;
    public SpriteRenderer eight;
    public SpriteRenderer nine;
    public SpriteRenderer ten;
    public SpriteRenderer eleven;
    public SpriteRenderer twelve;
    public SpriteRenderer thirteen;
    public SpriteRenderer fourteen;
    public SpriteRenderer fifteen;
    public SpriteRenderer sixteen;
    public SpriteRenderer seventeen;
    public SpriteRenderer eighteen;

    public int completeLevel1;
    public int completeLevel2;
    public int completeLevel3;
    public int completeLevel4;
    public int completeLevel5;
    public int completeLevel6;
    public int completeLevel7;
    public int completeLevel8;
    public int completeLevel9;
    public int completeLevel10;
    public int completeLevel11;
    public int completeLevel12;
    public int completeLevel13;
    public int completeLevel14;
    public int completeLevel15;
    public int completeLevel16;
    public int completeLevel17;
    public int completeLevel18;

    
    void Start()
    {   
        completeLevel1 = PlayerPrefs.GetInt("a", 0);
        completeLevel2 = PlayerPrefs.GetInt("b", 0);
        completeLevel3 = PlayerPrefs.GetInt("c", 0);
        completeLevel4 = PlayerPrefs.GetInt("d", 0);
        completeLevel5 = PlayerPrefs.GetInt("f", 0);
        completeLevel6 = PlayerPrefs.GetInt("e", 0);
        completeLevel7 = PlayerPrefs.GetInt("g", 0);
        completeLevel8 = PlayerPrefs.GetInt("h", 0);
        completeLevel9 = PlayerPrefs.GetInt("j", 0);
        completeLevel10 = PlayerPrefs.GetInt("k", 0);
        completeLevel11 = PlayerPrefs.GetInt("l", 0);
        completeLevel12 = PlayerPrefs.GetInt("q", 0);
        completeLevel13 = PlayerPrefs.GetInt("w", 0);
        completeLevel14 = PlayerPrefs.GetInt("r", 0);
        completeLevel15 = PlayerPrefs.GetInt("t", 0);
        completeLevel16 = PlayerPrefs.GetInt("y", 0);
        completeLevel17 = PlayerPrefs.GetInt("u", 0);
        completeLevel18 = PlayerPrefs.GetInt("i", 0);
    }   
    void Update()
    {
        if (Board.Complete == true)
        {
            completeLevel1 = 1;
        }
        if (Board.Complete1 == true)
        {
            completeLevel2 = 1;
        }
        if (Board.Complete2 == true)
        {
            completeLevel3 = 1;
        }
        if (Board.Complete3 == true)
        {
            completeLevel4 = 1;
        }
        if (Board.Complete4 == true)
        {
            completeLevel5 = 1;
        }
        if (Board.Complete5 == true)
        {
            completeLevel6 = 1;
        }
        if (Board.Complete6 == true)
        {
            completeLevel7 = 1;
        }
        if (Board.Complete7 == true)
        {
            completeLevel8 = 1;
        }
        if (Board.Complete8 == true)
        {
            completeLevel9 = 1;
        }
        if (Board.Complete9 == true)
        {
            completeLevel10 = 1;
        }
        if (Board.Complete10 == true)
        {
            completeLevel11 = 1;
        }
        if (Board.Complete11 == true)
        {
            completeLevel12 = 1;
        }
        if (Board.Complete12 == true)
        {
            completeLevel13 = 1;
        }
        if (Board.Complete13 == true)
        {
            completeLevel14 = 1;
        }
        if (Board.Complete14 == true)
        {
            completeLevel15 = 1;
        }
        if (Board.Complete15 == true)
        {
            completeLevel16 = 1;
        }
        if (Board.Complete16 == true)
        {
            completeLevel17 = 1;
        }
        if (Board.Complete17 == true)
        {
            completeLevel18 = 1;
        }

    
        if(completeLevel1 > PlayerPrefs.GetInt("a", 0))
        {
            PlayerPrefs.SetInt("a", completeLevel1);
        }
        if (completeLevel1 == 1)
        {
            one.enabled = true;
        }

        if(completeLevel2 > PlayerPrefs.GetInt("b", 0))
        {
            PlayerPrefs.SetInt("b", completeLevel2);
        }
        if (completeLevel2 == 1)
        {
            two.enabled = true;
        }

        if(completeLevel3 > PlayerPrefs.GetInt("c", 0))
        {
            PlayerPrefs.SetInt("c", completeLevel3);
        }
        if (completeLevel3 == 1)
        {
            three.enabled = true;
        }

        if(completeLevel4 > PlayerPrefs.GetInt("d", 0))
        {
            PlayerPrefs.SetInt("d", completeLevel4);
        }
        if (completeLevel4 == 1)
        {
            four.enabled = true;
        }

        if(completeLevel5 > PlayerPrefs.GetInt("f", 0))
        {
            PlayerPrefs.SetInt("f", completeLevel5);
        }
        if (completeLevel5 == 1)
        {
            five.enabled = true;
        }

        if(completeLevel6 > PlayerPrefs.GetInt("e", 0))
        {
            PlayerPrefs.SetInt("e", completeLevel6);
        }
        if (completeLevel6 == 1)
        {
            six.enabled = true;
        }

        if(completeLevel7 > PlayerPrefs.GetInt("g", 0))
        {
            PlayerPrefs.SetInt("g", completeLevel7);
        }
        if (completeLevel7 == 1)
        {
            seven.enabled = true;
        }

        if(completeLevel8 > PlayerPrefs.GetInt("h", 0))
        {
            PlayerPrefs.SetInt("h", completeLevel8);
        }
        if (completeLevel8 == 1)
        {
            eight.enabled = true;
        }

        if(completeLevel9 > PlayerPrefs.GetInt("j", 0))
        {
            PlayerPrefs.SetInt("j", completeLevel9);
        }
        if (completeLevel9 == 1)
        {
            nine.enabled = true;
        }

        if(completeLevel10 > PlayerPrefs.GetInt("k", 0))
        {
            PlayerPrefs.SetInt("k", completeLevel10);
        }
        if (completeLevel10 == 1)
        {
            ten.enabled = true;
        }

        if(completeLevel11 > PlayerPrefs.GetInt("l", 0))
        {
            PlayerPrefs.SetInt("l", completeLevel11);
        }
        if (completeLevel11 == 1)
        {
            eleven.enabled = true;
        }

        if(completeLevel12 > PlayerPrefs.GetInt("q", 0))
        {
            PlayerPrefs.SetInt("q", completeLevel12);
        }
        if (completeLevel12 == 1)
        {
            twelve.enabled = true;
        }

        if(completeLevel13 > PlayerPrefs.GetInt("w", 0))
        {
            PlayerPrefs.SetInt("w", completeLevel13);
        }
        if (completeLevel13 == 1)
        {
            thirteen.enabled = true;
        }

        if(completeLevel14 > PlayerPrefs.GetInt("r", 0))
        {
            PlayerPrefs.SetInt("r", completeLevel14);
        }
        if (completeLevel14 == 1)
        {
            fourteen.enabled = true;
        }

        if(completeLevel15 > PlayerPrefs.GetInt("t", 0))
        {
            PlayerPrefs.SetInt("t", completeLevel15);
        }
        if (completeLevel15 == 1)
        {
            fifteen.enabled = true;
        }

        if(completeLevel16 > PlayerPrefs.GetInt("y", 0))
        {
            PlayerPrefs.SetInt("y", completeLevel16);
        }
        if (completeLevel16 == 1)
        {
            sixteen.enabled = true;
        }

        if(completeLevel17 > PlayerPrefs.GetInt("u", 0))
        {
            PlayerPrefs.SetInt("u", completeLevel17);
        }
        if (completeLevel17 == 1)
        {
            seventeen.enabled = true;
        }

        if(completeLevel18 > PlayerPrefs.GetInt("i", 0))
        {
            PlayerPrefs.SetInt("i", completeLevel18);
        }
        if (completeLevel18 == 1)
        {
            eighteen.enabled = true;
        }

    }    
}
