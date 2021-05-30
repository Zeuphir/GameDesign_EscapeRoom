using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    public string[] NAMES;
    public Sprite[] SPRITES;
    public Sprite[] SMALL;
    public int[] SELECTED;
    public GameObject[] plates;
    public GameObject[] pushables;
    public GameObject[] imageHolder;
    public GameObject[] cats;
    public string[] Dialogues;

    void Awake()
    {
        List<int> picked = new List<int>(); 
        while (picked.Count != 6)
        {
            int rand = Random.Range(0, 18);
            if (!picked.Contains(rand))
            {
                picked.Add(rand);
            }
        }
        SELECTED = picked.ToArray();

        List<int> allpushables = new List<int>() {0,1,2,3,4,5};
        List<int> realpushables = new List<int>();
        List<int> falsepushable = new List<int>();

        while (realpushables.Count != 4)
        {
            int rand = Random.Range(0, allpushables.Count);
            realpushables.Add(allpushables[rand]);
            allpushables.RemoveAt(rand);
        }

        for (int i = 0; i < allpushables.Count; i++)
        {
            falsepushable.Add(allpushables[i]);
        }

        for (int i = 0; i < 4; i++)
        {
            // set the valid trigger to the 4 pressure plates
            plates[i].GetComponent<PressurePlate>().SETValidTrigger(NAMES[realpushables[i]]);

            // set small sprite
            pushables[realpushables[i]].GetComponent<SpriteRenderer>().sprite = SMALL[SELECTED[i]];

            // set Image sprite
            imageHolder[realpushables[i]].GetComponent<ImageHolder>().setImageSprite(SPRITES[SELECTED[i]]);

        }

        // the false ones
        pushables[falsepushable[0]].GetComponent<SpriteRenderer>().sprite = SMALL[SELECTED[4]];
        pushables[falsepushable[1]].GetComponent<SpriteRenderer>().sprite = SMALL[SELECTED[5]];
        imageHolder[falsepushable[0]].GetComponent<ImageHolder>().setImageSprite(SPRITES[SELECTED[4]]);
        imageHolder[falsepushable[1]].GetComponent<ImageHolder>().setImageSprite(SPRITES[SELECTED[5]]);

        // dialogues cat
        List<string> catd1 = new List<string>();
        catd1.Add(Dialogues[18]);
        catd1.Add(Dialogues[SELECTED[0]]);
        catd1.Add(Dialogues[SELECTED[1]]);
        cats[0].GetComponent<DialogueHolder>().setDLines(catd1.ToArray());

        List<string> catd2 = new List<string>();
        catd2.Add(Dialogues[18]);
        catd2.Add(Dialogues[SELECTED[2]]);
        catd2.Add(Dialogues[SELECTED[3]]);
        cats[1].GetComponent<DialogueHolder>().setDLines(catd2.ToArray());
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
