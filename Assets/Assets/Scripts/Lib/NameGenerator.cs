using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NameGenerator
{
    private List<string> maleFirstNames = new List<string>();
    private List<string> femaleFirstNames = new List<string>();
    private List<string> lastNames = new List<string>();

    private List<string> kingdomName = new List<string>();

    public string test = "";
    //public TextAsset nameFile;
    public NameGenerator()
    {
        setupMaleNames();
        setupFemaleNames();
        setupLastNames();
    }

    // Use this for initialization
    /*void Start()
    {
        setupMaleNames();
        setupFemaleNames();
        setupLastNames();
        int index = Random.Range(0, maleFirstNames.Count);
        int lastIndex = Random.Range(0, lastNames.Count);
        test = maleFirstNames[index] + " " + lastNames[lastIndex];
        Debug.Log(test);

        test = createName(Random.Range(1, 3));
        Debug.Log(test);
        test = createName(Random.Range(1, 3));
        Debug.Log(test);
        test = createName(Random.Range(1, 3));
        Debug.Log(test);

    }*/

    public string createName(int gender)
    {
        if (gender == 1)
        {
            //Male
            int index = Random.Range(0, maleFirstNames.Count);
            int lastIndex = Random.Range(0, lastNames.Count);
            return maleFirstNames[index] + " " + lastNames[lastIndex];
        }
        else
        {
            //Female
            int index = Random.Range(0, femaleFirstNames.Count);
            int lastIndex = Random.Range(0, lastNames.Count);
            return femaleFirstNames[index] + " " + lastNames[lastIndex];
        }
    }


    public void setupMaleNames()
    {
        TextAsset nameFile = (TextAsset)Resources.Load("MaleFirstName");
        string[] linesInFile = nameFile.text.Split('\n');

        foreach (string line in linesInFile)
        {
            maleFirstNames.Add(line);
        }
    }

    public void setupFemaleNames()
    {
        TextAsset nameFile = (TextAsset)Resources.Load("FemaleFirstName");
        string[] linesInFile = nameFile.text.Split('\n');

        foreach (string line in linesInFile)
        {
            femaleFirstNames.Add(line);
        }
    }

    public void setupLastNames()
    {
        TextAsset nameFile = (TextAsset)Resources.Load("LastName");
        string[] linesInFile = nameFile.text.Split('\n');

        foreach (string line in linesInFile)
        {
            lastNames.Add(line);
        }
    }
}
