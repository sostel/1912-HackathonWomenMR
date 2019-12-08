using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pet : MonoBehaviour
{


    public List<Need> needs;

    // debug
    public TextMeshPro debugLabel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (debugLabel != null)
        {
            string labelText = "Stats \n";
            for (int i = 0; i < needs.Count; ++i)
            {
                labelText += "\n";
                labelText += needs[i].needName;
                labelText += "; ";
                labelText += needs[i].value;
            }

            debugLabel.SetText(labelText);
        }
    }
}
