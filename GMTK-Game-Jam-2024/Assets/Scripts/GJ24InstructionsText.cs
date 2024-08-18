using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GJ24InstructionsText : MonoBehaviour
{
    TMP_Text _instructionsText;
    void Start()
    {
        _instructionsText = GetComponent<TMP_Text>();
        _instructionsText.text = "The foolish earthlings have got everything wrong! Cars smaller than buildings? We must help them! \n\n" +
                                 "Thankfully our ray gun can shrink and grow objects to their correct size\n\n" +
                                 "Our ship has marked objects required to be changed\n\n" +
                                 "Objects to be <color=#FF0000>shrunk</color> are marked <color=#FF0000>red</color>\n\n" +
                                 "Objects to be <color=#494BFF>grown</color> are marked <color=#494BFF>blue</color>\n\n" +
                                 "Objects at their <color=#00FF00>correct</color> size are marked <color=#00FF00>green</color>\n\n" +
                                 "Be careful <color=#FF6400>not to crash</color> into anything whilst growing objects!\n\n" +
                                 "Watch out! The stupid earthlings don’t realise we’re trying to help them! Their <color=#FF6400>tanks</color> are trying to <color=#FF6400>shoot us</color> down and are protected by <color=#FF6400>anti-correction shields</color>\n\n" +
                                 "However, not to fear! We are detecting strange, but useful glowing items known as <color=#FF6400>power ups</color> to help you in your mission\n\n" +
                                 "Make sure you are filling your <color=#FF6400>shrink/grow quota</color> or our emperor will be <color=#FF6400>most displeased!</color>\n\n";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
