using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Nation
{
    public List<LandBase> listLandBase = new List<LandBase>();

    public Kingdom kingdom;
    public Empire empire;

    public string nameNation;
    NationLib lib = new NationLib();

    public Nation(bool isPlayer)
    {
        if(isPlayer == true)
        {
            
        }
        else
        {
            int chance = UnityEngine.Random.Range(1, 11);
            if (chance > 8)
            {
                empire = new Empire();
                nameNation = lib.createNationName(4);
                empire.landName = nameNation;
            }
            else
            {
                kingdom = new Kingdom();
                nameNation = lib.createNationName(3);
            }
        }
    }

    public string toString()
    {
        string s = "";
        s = s + "Nation name: " + nameNation + "\n";
        return s;
    }
	
}

public class Empire : LandBase //May be empire for npc but not for player
{
    int kingdomSlot;
    public List<Kingdom> listKingdom = new List<Kingdom>();

    public Empire() : base()
    {
        kingdomSlot = UnityEngine.Random.Range(3, 7);

        setupLand(4);
    }

    public override void setupLand(int rank)
    {
        base.setupLand(rank);

        //landName = lib.createNationName(4);// dont think i need this

        for (int i = 0; i < kingdomSlot; i++)
        {
            Kingdom k = new Kingdom();
            listKingdom.Add(k);
        }

        population = calculatePopulation();
    }

    public override float calculateIncome()
    {
        float total = 0;
        for (int x = 0; x < listKingdom.Count; x++)
        {
            total += listKingdom[x].calculateIncome();
        }
        return total;
    }

    public override int calculatePopulation()
    {
        int total = 0;
        for (int x = 0; x < listKingdom.Count; x++)
        {
            total += listKingdom[x].calculatePopulation();
        }
        return total;
    }

    public override string toString()
    {
        string s = base.toString();

        s = s + "Expected Income " + calculateIncome() + "\n";
        s = s + "Population " + calculatePopulation() + "\n";
        s = s + "Num of Kingdoms: " + listKingdom.Count + "\n";
        for (int i = 0; i < listKingdom.Count; i++)
        {
            s = s + "####################" + (i + 1) + "#####################\n";
            s = s + "Kingdom: " + listKingdom[i].landName + "\n";
            s = s + "##########################################\n";
        }
        return s;
    }
}


public class Kingdom : LandBase
{
    int duchySlot;
    public List<Duchy> listDuchy = new List<Duchy>();

    public Kingdom() : base()
    {
        duchySlot = UnityEngine.Random.Range(4, 15);

        setupLand(3);
    }

    public override void setupLand(int rank)
    {
        base.setupLand(rank);

        landName = lib.createKingdomName();

        for (int i = 0; i < duchySlot; i++)
        {
            Duchy d = new Duchy();
            listDuchy.Add(d);
        }

        population = calculatePopulation();
    }

    public override float calculateIncome()
    {
        float total = 0;
        for (int x = 0; x < listDuchy.Count; x++)
        {
            total += listDuchy[x].calculateIncome();
        }
        return total;
    }

    public override int calculatePopulation()
    {
        int total = 0;
        for (int x = 0; x < listDuchy.Count; x++)
        {
            total += listDuchy[x].calculatePopulation();
        }
        return total;
    }

    public override string toString()
    {
        string s = base.toString();

        s = s + "Expected Income " + calculateIncome() + "\n";
        s = s + "Population " + calculatePopulation() + "\n";
        s = s + "Num of Duchies: " + listDuchy.Count + "\n";
        for (int i = 0; i < listDuchy.Count; i++)
        {
            s = s + "####################" + (i + 1) + "#####################\n";
            s = s + "Duchy: " + listDuchy[i].landName + "\n";
            s = s + "##########################################\n";
        }
        return s;
    }

    /*public Prefab countsManor;
    public Pre
    public string kingdomName;

    public int population;

    public double income;
    public int recruitablePopPercent;

    static int BASE_INCOME = 1;

    public int recruitablePopulation()
    {
        return population * recruitablePopPercent;
    }

    public int calculateIncome()
    {

        return population * BASE_INCOME *Player.steward.stewardship;
    }*/
}

public class Duchy : LandBase
{
    int countySlot;
    public List<County> listCounty = new List<County>();

    public Duchy() : base()
    {
        countySlot = UnityEngine.Random.Range(2, 6);

        setupLand(2);

    }

    public override void setupLand(int rank)
    {
        base.setupLand(rank);

        landName = lib.createKingdomName();

        for (int i = 0; i < countySlot; i++)
        {
            County c = new County();
            listCounty.Add(c);
        }

        population = calculatePopulation();
    }

    public override float calculateIncome()
    {
        float total = 0;
        for (int x = 0; x < listCounty.Count; x++)
        {
            total += listCounty[x].calculateIncome();
        }
        return total;
    }

    public override int calculatePopulation()
    {
        int total = 0;
        for (int x = 0; x < listCounty.Count; x++)
        {
            total += listCounty[x].calculatePopulation();
        }
        return total;
    }

    public override string toString()
    {
        string s = base.toString();

        s = s + "Expected Income " + calculateIncome() + "\n";
        s = s + "Population " + calculatePopulation() + "\n";
        s = s + "Num of Counties: " + listCounty.Count + "\n";
        for (int i = 0; i < listCounty.Count; i++)
        {
            s = s + "####################" + (i + 1) + "#####################\n";
            s = s + "County: " + listCounty[i].landName + "\n";
            s = s + "##########################################\n";
        }
        return s;
    }
}

public class County : LandBase
{
    int territorySlotsPercent;
    int territorySlot;
    public List<Territory> listTerritory = new List<Territory>();

    public County() : base()
    {
        territorySlotsPercent = UnityEngine.Random.Range(1, 101);

        setupLand(1);

    }

    public County(bool isPlayer) : base()//used to created the players county TODO set it up for the player object and stuff
    {
        territorySlotsPercent = UnityEngine.Random.Range(1, 101);

        setupLand(1);
    }

    public override void setupLand(int rank)
    {
        base.setupLand(rank);

        territorySlot = getNumofSlots();
        landName = lib.createCountyName();


        if (territorySlot == 1)
        {
            Territory t = new Territory(landName, 4);
            listTerritory.Add(t);
        }
        else
        {
            for (int i = 0; i < territorySlot; i++)
            {
                int num = i + 1;
                Territory t = new Territory(landName, num);
                listTerritory.Add(t);
            }
        }

        population = calculatePopulation();

    }

    int getNumofSlots()
    {
        if (territorySlotsPercent >= 97)
        {
            return 6;
        }
        else if (territorySlotsPercent >= 90 && territorySlotsPercent < 97)
        {
            return 5;
        }
        else if (territorySlotsPercent >= 80 && territorySlotsPercent < 90)
        {
            return 4;
        }
        else if (territorySlotsPercent >= 45 && territorySlotsPercent < 80)
        {
            return 3;
        }
        else if (territorySlotsPercent >= 15 && territorySlotsPercent < 45)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

    public override float calculateIncome()
    {
        float total = 0;
        for (int x = 0; x < listTerritory.Count; x++)
        {
            total += listTerritory[x].calculateIncome();
        }
        return total;
    }

    public override int calculatePopulation()
    {
        int total = 0;
        for (int x = 0; x < listTerritory.Count; x++)
        {
            total += listTerritory[x].calculatePopulation();
        }
        return total;
    }

    public override string toString()
    {
        string s = base.toString();
        
        s = s + "Expected Income " + calculateIncome() + "\n";
        s = s + "Population " + calculatePopulation() + "\n";
        s = s + "Num of Territories: " + listTerritory.Count + "\n";
        for(int i = 0; i < listTerritory.Count; i++)
        {
            s = s + "####################" + (i + 1) + "#####################\n";
            s = s + "Territory: " + listTerritory[i].landName + "\n";
            s = s + "##########################################\n";
        }
        return s;
    }
}

public class Territory : LandBase
{
    public int type { get; set; }
    public string territoryType { get; set; }

    private int nameID;

    private string holdName;

    public Territory(string countyName, int setType) : base()
    {
        holdName = countyName;
        type = setType;
        setupLand(0);
        
    }


    public override void setupLand(int rank)
    {
        base.setupLand(rank);

        if (type > 3)
        {
            nameID = 2;
            type = UnityEngine.Random.Range(1, 4);
        }
        else
        {
            nameID = 1;
        }

        setUpTerritory();
        setUpName();
    }

    public override float calculateIncome()
    {
        return tax * population;
    }

    public override int calculatePopulation()
    {
        return population;
    }

    void setUpName()
    {
        if (nameID == 1)
        {
            switch (type)
            {
                case 1:
                    landName = lib.createCastleName(holdName);
                    break;
                case 2:
                    landName = lib.createCityName(holdName);
                    break;
                case 3:
                    landName = lib.createTempleName(holdName);
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (type)
            {
                case 1:
                    landName = lib.createCastleName();
                    break;
                case 2:
                    landName = lib.createCityName();
                    break;
                case 3:
                    landName = lib.createTempleName();
                    break;
                default:
                    break;
            }
        }
    }

    void setUpTerritory()
    {
        switch(type)
        {
            case 1:
                tax = 1;
                territoryType = "Castle";
                break;
            case 2:
                tax = 3;
                territoryType = "City";
                break;
            case 3:
                tax = 2;
                territoryType = "Temple";
                break;
            default:
                break;

        }
    }

    public override string toString()
    {
        string s = base.toString();
        s = s + "Hold Type: " + territoryType + "\n";
        s = s + "Expected Income " + calculateIncome() + "\n";
        s = s + "Population " + calculatePopulation() + "\n";
        return s;
    }


}

public abstract class LandBase
{
    public string landName { get; set; }

    public Soul Owner { get; set; }

    public int population { get; set; }

    public int tax { get; set; }

    public NationLib lib = new NationLib();

    public LandBase()
    {

    }

    public virtual void setupLand(int rank)
    {
        if (Owner == null)
        {
            Owner = lib.createNPC(rank);
        }
    }

    public abstract float calculateIncome();

    public abstract int calculatePopulation();

    public virtual string toString()
    {
        string s = "";
        s = s + "Name: " + landName + "\n";
        s = s + "Owner: " + Owner + "\n";
        return s;
    }
}

public class NationLib
{
    string[] nationNames1 = new string[] { "ae", "ea", "ai", "au", "ou", "a", "e", "i", "o", "u", "a", "e", "i", "o", "u", "a", "e", "i", "o", "u", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
    string[] nationNames2 = new string[] { "ae", "eo", "ea", "ai", "ui", "ou", "a", "e", "i", "o", "u", "a", "e", "i", "o", "u", "a", "e", "i", "o", "u" };
    string[] nationNames3 = new string[] { "b", "c", "d", "g", "h", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z", "br", "cr", "dr", "gr", "kr", "pr", "tr", "vr", "wr", "st", "sl", "ch", "sh", "ph", "kh", "th" };
    string[] nationNames4 = new string[] { "b", "c", "d", "g", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z", "b", "c", "d", "g", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z", "b", "c", "d", "f", "g", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z", "bb", "cc", "dd", "ff", "gg", "kk", "ll", "mm", "nn", "pp", "rr", "ss", "tt", "zz", "br", "cr", "dr", "gr", "kr", "pr", "sr", "tr", "zr", "st", "sl", "ch", "sh", "ph", "kh", "th" };
    string[] nationNames5 = new string[] { "ba", "bet", "bia", "borg", "burg", "ca", "caea", "can", "cia", "curia", "dal", "del", "dia", "dian", "do", "dor", "dora", "dour", "galla", "gary", "gia", "gon", "han", "kar", "kha", "kya", "les", "lia", "lon", "lan", "lum", "lux", "lyra", "mid", "mor", "more", "nad", "nait", "nao", "nate", "nada", "neian", "nem", "nia", "nid", "niel", "ning", "ntis", "nyth", "pan", "phate", "pia", "pis", "ra", "ral", "rean", "rene", "renth", "ria", "rian", "rid", "rin", "ris", "rith", "rus", "ryn", "sal", "san", "sea", "seon", "sha", "sian", "site", "sta", "ston", "teron", "terra", "tha", "thage", "then", "thia", "tia", "tis", "tish", "ton", "topia", "tor", "tus", "valon", "varia", "vell", "ven", "via", "viel", "wen", "weth", "wyth", "ya", "zar", "zia" };
    //string[] nationNames6 = new string[] { "Kingdom", "Empire", "Dynasty" };
    string[] nationNames6 = new string[] { "Kingdom", "Dynasty" };


    string[] kingdomN1 = new string[] { "b", "c", "d", "f", "g", "h", "i", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z", "", "", "", "", "" };
    string[] kingdomN2 = new string[] { "a", "e", "o", "u" };
    string[] kingdomN3 = new string[] { "br", "cr", "dr", "fr", "gr", "pr", "str", "tr", "bl", "cl", "fl", "gl", "pl", "sl", "sc", "sk", "sm", "sn", "sp", "st", "sw", "ch", "sh", "th", "wh", "thr" };
    string[] kingdomN4 = new string[] { "ae", "ai", "ao", "au", "a", "ay", "ea", "ei", "eo", "eu", "e", "ey", "ua", "ue", "ui", "uo", "u", "uy", "ia", "ie", "iu", "io", "iy", "oa", "oe", "ou", "oi", "o", "oy" };
    string[] kingdomN5 = new string[] { "stan", "dor", "vania", "nia", "lor", "cor", "dal", "bar", "sal", "ra", "la", "lia", "jan", "rus", "ze", "tan", "wana", "sil", "so", "na", "le", "bia", "ca", "ji", "ce", "ton", "ssau", "sau", "sia", "ca", "ya", "ye", "yae", "tho", "stein", "ria", "nia", "burg", "nia", "gro", "que", "gua", "qua", "rhiel", "cia", "les", "dan", "nga", "land", "ciel", "cial" };
    string[] kingdomN6 = new string[] { "ia", "a", "en", "ar", "istan", "aria", "ington", "ua", "ijan", "ain", "ium", "us", "esh", "os", "ana", "il", "ad", "or", "ea", "eau", "ax", "on", "ana", "ary", "ya", "ye", "yae", "ait", "ein", "urg", "al", "ines", "ela", "ace" };

    string[] cityName1 = new string[] { "amber", "angel", "spirit", "basin", "lagoon", "basin", "arrow", "autumn", "bare", "bay", "beach", "bear", "bell", "black", "bleak", "blind", "bone", "boulder", "bridge", "brine", "brittle", "bronze", "castle", "cave", "chill", "clay", "clear", "cliff", "cloud", "cold", "crag", "crow", "crystal", "curse", "dark", "dawn", "dead", "deep", "deer", "demon", "dew", "dim", "dire", "dirt", "dog", "dragon", "dry", "dusk", "dust", "eagle", "earth", "east", "ebon", "edge", "elder", "ember", "ever", "fair", "fall", "false", "far", "fay", "fear", "flame", "flat", "frey", "frost", "ghost", "glimmer", "gloom", "gold", "grass", "gray", "green", "grim", "grime", "hazel", "heart", "high", "hollow", "honey", "hound", "ice", "iron", "kil", "knight", "lake", "last", "light", "lime", "little", "lost", "mad", "mage", "maple", "mid", "might", "mill", "mist", "moon", "moss", "mud", "mute", "myth", "never", "new", "night", "north", "oaken", "ocean", "old", "ox", "pearl", "pine", "pond", "pure", "quick", "rage", "raven", "red", "rime", "river", "rock", "rogue", "rose", "rust", "salt", "sand", "scorch", "shade", "shadow", "shimmer", "shroud", "silent", "silk", "silver", "sleek", "sleet", "sly", "small", "smooth", "snake", "snow", "south", "spring", "stag", "star", "steam", "steel", "steep", "still", "stone", "storm", "summer", "sun", "swamp", "swan", "swift", "thorn", "timber", "trade", "west", "whale", "whit", "white", "wild", "wilde", "wind", "winter", "wolf" };
    string[] cityName2 = new string[] { "acre", "band", "barrow", "bay", "bell", "born", "borough", "bourne", "breach", "break", "brook", "burgh", "burn", "bury", "cairn", "call", "chill", "cliff", "coast", "crest", "cross", "dale", "denn", "drift", "fair", "fall", "falls", "fell", "field", "ford", "forest", "fort", "front", "frost", "garde", "gate", "glen", "grasp", "grave", "grove", "guard", "gulch", "gulf", "hall", "hallow", "ham", "hand", "harbor", "haven", "helm", "hill", "hold", "holde", "hollow", "horn", "host", "keep", "land", "light", "maw", "meadow", "mere", "mire", "mond", "moor", "more", "mount", "mouth", "pass", "peak", "point", "pond", "port", "post", "reach", "rest", "rock", "run", "scar", "shade", "shear", "shell", "shield", "shore", "shire", "side", "spell", "spire", "stall", "wich", "minster", "star", "storm", "strand", "summit", "tide", "town", "vale", "valley", "vault", "vein", "view", "ville", "wall", "wallow", "ward", "watch", "water", "well", "wharf", "wick", "wind", "wood", "yard" };

    string[] castleName1 = new string[] { "Dragonspire", "Redmont", "Farrador", "Dannamore", "Windamere", "Braewood", "Perrigwyn", "Cantlyn", "Tessaway", "Brawnlyn", "Aeskrow", "Balling", "Boltan", "Boltangate", "Caestshire", "Celnaer", "Slyborn", "Calbridge", "Dewmire", "Craester Arms", "Croglang", "Darton", "Darenby", "Dunstead", "Shardore", "Goodmond", "Salkire", "Hordrigg", "Hopeshire", "Haerton", "Cullin", "Murton", "Iredale", "Cornby", "Croilton", "Kirkoswald", "Levans", "Little Cardle", "Carderby", "Ormshire", "Dockerly", "Pierceton", "Crandalholme", "Faerchester", "Sella", "Skelside", "Selsmire", "Staerdale", "Direwood", "Waernell", "Worthwood", "Wilton", "Bellbroke", "Brivey", "Breuce", "Ashington", "Haword", "Clifton", "Highcalere", "Mireworth", "New Wandour", "Bornesher", "Werth", "Wishborne", "Arcton", "Allerton", "Auglire", "Avolire", "Bellton", "Bilesworth", "Bode", "Aedon", "Garring", "Baedcove", "Crireton", "Cloveshire", "Custaeton", "Crachton", "Droskyn", "Elkmire", "Ernmore", "Uwile", "Farleigh", "Harley", "Werthingham", "Zatherop", "Blire", "Pradingly", "Highburn", "Hillfield", "Kernwith", "Cowle", "Knaerwood", "Nascombe", "Midford", "Malgrave", "Otterberg", "Kentillie", "Reave", "Ryre", "St. Clare", "Sipdon", "Seanton", "Santhope", "Dudley", "Swanton", "Streganna", "Wardhurst", "Whitehaven", "Wattingham", "Whitstone", "Wallersley", "Willbridge", "Appley", "Baldon", "Blaise", "Bolltree", "Baston", "Bryalshire", "Broadcove", "Castlebourne", "Clarn", "Clapton", "Dinton", "Draydon", "Darnstall", "Dustorn", "Portam", "Headow", "Garley", "Naesbrey", "Parton", "Redford", "Yardway", "Weavington", "Cladborough", "Parthley", "Rundhey", "Bargsea", "Sevenberg", "Shaldorn", "Starm", "Saelmere", "Nightwell", "Starnborough", "Stowe", "Strathenberg", "Sandorne", "Wardford", "Bangleswade", "Baltso", "Cainhorn", "Chilgrave", "Eastcairn", "Galbury", "Flatwick", "Hingham", "Cardell", "Cordington", "Ranhold", "Rissingshire", "Khurleigh", "Talsworth", "Tarlington", "Cottenhorn", "Yielden", "Sangeries", "Barthmont", "Dewbury", "Hampstead", "Yorthendon", "Darlington", "Windsor", "Calber", "Pardwell", "Cunningham", "Laventhorpe", "Cublerton", "Broadborough", "Eallesborough", "Arvendon", "Karmble", "Marseden", "Tarville", "Wolveshire", "Coarshire", "Alderth", "Borun", "Hurwell", "Lambridge", "Charvaley", "Earlton", "Ely", "Hartington", "Carsley", "Catterborough", "Warltonwood", "Larton", "Elden", "Cambolton", "Mortling", "Fanthorpe", "Farnborough", "Croftvalley", "Eldford", "Dandlestone", "Faerdham", "Gourdley", "Merclefield", "Goulpass", "Craentich", "Norhall", "Whitich", "Paelford", "Corlach", "Adwick", "Sparrington", "Baerston", "Chastershire", "Chourmondeley", "Dordington", "Hurlton", "Parkforton", "Coltherstone", "Calden", "Cadworth", "Startlam", "Aeckland", "Bawres", "Barnacton", "Darham", "Lorton", "Faemley", "Mortham", "Scarwood", "Wulworth", "Witton", "Boussiney", "Borthrough", "Curdingham", "Harlston", "Arpton", "Pernstow", "Caerhayes", "Curnbrey", "Faerseton", "Parandor", "Fangdor", "Eastormel", "Artanges", "Termarth", "Oldingham", "Howers", "Aegremonth", "Haeresceugh", "Haertley", "Ayes", "Carcoswald", "Lamberside", "Lardel", "Merryport", "Perlington", "Staedbergh", "Tortmain", "Ardleby", "Armathain", "Earnside", "Easkerton", "Bartham", "Barncowl", "Barkenburgh", "Brackhill", "Barthwaite", "Bourgh", "Borugham", "Burneside", "Carlisle", "Gatterlen", "Clafton", "Ackermouth", "Carby", "Bacre", "Hartlon", "Warington", "Darwaeton", "Darrumburgh", "Harbyborough", "Hayton", "Harzelslack", "Hewgill", "Haarton", "Aysel", "Kaerndal", "Karthmere", "Carnstock", "Fowther", "Middleborough", "Gancaster", "Naeworth", "Newbining", "Pendragon", "Enrilth", "Rose", "Scatterby", "Mizeareigh", "Torpin", "Aebarrow", "Withall", "Arltington", "Wray", "Yeanworth", "Lakewell", "Darbey", "Daffield", "Galsop", "Garsley", "Heathersage", "Helmesfield", "Oakenfield", "Haersley", "Calbourne", "Mearley", "Palsbury", "Bellsover", "Candor", "Elverston", "Headdon", "Merkworth", "Parverhill", "Raebershire", "Wringcaster", "Harmpton", "Bernstaple", "Darpley", "Blackdown", "Eagleview", "Harwood", "Oakwell", "Millford", "Tarsington", "Caenleigh", "Eaveton", "Pomparley", "Backleigh", "Dawnton", "Darthill", "Dorgoil", "Gadleigh", "Heamyock", "Kingshill", "Leydford", "Merliscire", "Oakhampton", "Plympford", "Sraederham", "Rouguemont", "Talverton", "Waelcombe", "Taetnire", "Moldermouth", "Lorechester", "Callborough", "Marshwood", "Elderstock", "Riverfoot", "Starminster", "Waerham", "Bellesea", "Corftey", "Raefus", "Woodsford", "Eaghton", "Heathyard", "Yanborough", "Darfield", "Maetrine", "Warsle", "Perlsea", "Glottenham", "Islefield", "Bordium", "Herstings", "Laeves", "Pevanshire", "Rye", "Capvering", "Cainfield", "Angarth", "Baerth", "Pelsley", "Carleigh", "Calchester", "Cadleigh", "Hardingham", "Waerlden", "Barmsfield", "Harle", "Sirenchester", "Barknor", "Howlester", "Fowlsfield", "Brittlebean", "Miserth", "Narlington", "Ruarden", "Carneath", "Greenhill", "Tarnton", "Wenchcombe", "Barkely", "Beverstone", "Barviel", "Stadely", "Tornbury", "Alterwood", "Starkport", "Rachdale", "Dornham", "Lanchester", "Backton", "Arlcliff", "Calsley", "Herst", "Nartley", "Ardiham", "Forechester", "Windshire", "Wolvesley", "Almerry", "Ashtanshire", "Barnsil", "Berdwardshire", "Dorston", "Ardismouth", "Barlishmire", "Eryas", "Haerford", "Kalepeck", "Langen", "Lyonhall", "Mercle", "Arcop", "Fernyard", "Stappleton", "Warcton", "Burmstone", "Barmpton", "Calford", "Croft", "Dawnton", "Goulrich", "Cannersly", "Permbridge", "Stonehill", "Wintershold", "Windkeep", "Archdale", "Treehold", "Summerswind", "Ultrona", "Langdale", "Longdale", "Bruckstone", "Euthoria", "Azgul", "Stormholme", "Riverdale", "Ulentor", "Mirador", "Bundor", "Gandum", "Mandoom", "Daroonga", "Grimtol", "Gumtar", "Muria", "Maelony", "Galadhor", "Gundor", "Logoria", "Taergoria", "Whitmore", "Warlton", "Arnstey", "Berlington", "Starford", "Parlton", "Tharfield", "Windmontley", "Barkhamsted", "East Lowes", "West Lowes", "Curlisbrooke", "Narris", "Yarlmouth", "Cormwell", "Minbury", "Brancheley", "Falkerstone", "Queensborough", "Stowerling", "Tharnham", "Earlington", "Calterburry", "Chirlingstone", "Charhelm", "Eynsworth", "Leyebourne", "Saltwood", "Raychester", "Sarsinghurst", "Tornbridge", "Alnor", "Waelmore" };
    string[] castleName2 = new string[] { "Castle", "Keep", "Hold", "Palace", "Fort", "Stronghold", "Citadel", "Fortress" };

    string[] templeNames1 = new string[] { "br", "cr", "dr", "fr", "gr", "kr", "pr", "tr", "str", "vr", "bl", "cl", "gl", "kl", "pl", "sl", "ch", "sh", "th", "ph", "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
    string[] templeNames2 = new string[] { "a", "e", "i", "o", "u", "ae", "ea", "eo", "ai" };
    string[] templeNames3 = new string[] { "b", "c", "d", "g", "h", "k", "l", "m", "n", "p", "q", "r", "s", "t", "w", "br", "cr", "dr", "fr", "gr", "kr", "pr", "tr", "str", "vr", "bl", "cl", "gl", "kl", "pl", "sl", "ch", "sh", "th", "ph" };
    string[] templeNames4 = new string[] { "bania", "bara", "ceris", "cise", "cys", "dahre", "dana", "daris", "deia", "dhari", "dhuru", "firi", "fys", "geris", "gura", "hagar", "haja", "hara", "hari", "hati", "hava", "haya", "jia", "kami", "kata", "kaya", "keria", "laris", "leia", "leian", "leion", "lerion", "levia", "loka", "luna", "mana", "mano", "mao", "mena", "mina", "nero", "neron", "nesh", "neya", "nira", "nis", "nora", "nova", "nuga", "peron", "phenia", "polis", "porith", "ppeion", "qira", "rana", "reon", "ris", "shara", "szara", "talis", "taris", "tera", "theion", "thenon", "theoa", "theon", "vana", "veras", "vira", "wani", "weia", "za", "zaki", "zale" };

    string[] templeNames5 = new string[] { "Altar", "Chapel", "Church", "House", "Mosque", "Monastery", "Pagoda", "Pantheon", "Pantheon", "Sanctuary", "Sanctuary", "Sanctum", "Shrine", "Shrine", "Sanctum", "Synagogue", "Temple", "Temple" };
    string[] templeNames6 = new string[] { "Agony", "Air", "Allegiance", "Ambition", "Amnesia", "Ancestors", "Anguish", "Answers", "Aspiration", "Ataraxia", "Blight", "Bliss", "Bonds", "Braveness", "Chance", "Clairvoyance", "Coincidences", "Chaos", "Collapse", "Comfort", "Confessions", "Confidence", "Connections", "Consequences", "Contemplation", "Conviction", "Corruption", "Courage", "Creed", "Darkness", "Death", "Decay", "Dedication", "Defeat", "Delight", "Demise", "Desire", "Despair", "Destinations", "Destinies", "Determination", "Devotion", "Disaster", "Discipline", "Divine Will", "Divinity", "Doom", "Dreams", "Earth", "Emergencies", "Emotions", "Endurance", "Enlightenment", "Equality", "Equanimity", "Eternity", "Exile", "Exiles", "Exodus", "Exploration", "Extinction", "Faith", "Fate", "Fealty", "Felicity", "Fire", "Foresight", "Forgiveness", "Fortune", "Frenzy", "Friendship", "Grace", "Grief", "Harm", "Healing", "Honor", "Hope", "Humility", "Hunger", "Ice", "Infinity", "Insight", "Integrity", "Introspection", "Isolation", "Judgement", "Karma", "Kinship", "Knowledge", "Lament", "Legends", "Life", "Light", "Lore", "Loss", "Love", "Luck", "Meditation", "Mending", "Mercy", "Mourning", "Myths", "Nature", "Necrosis", "Oblivion", "Opportunities", "Paradise", "Passion", "Patience", "Peace", "Perception", "Perfection", "Perpetuity", "Placidity", "Pledges", "Plight", "Possibilities", "Order", "Premonitions", "Probabilities", "Promise", "Prospects", "Purgatory", "Purpose", "Pursuance", "Pursuit", "Quests", "Quietude", "Reflection", "Refugees", "Regrets", "Rejuvenation", "Reliance", "Remorse", "Repose", "Resolutions", "Resolve", "Restoration", "Revelations", "Reverence", "Reverie", "Revival", "Sagas", "Sanctity", "Seclusion", "Secrets", "Sentiment", "Serenity", "Silence", "Snow", "Solitude", "Souls", "Spirits", "Tenacity", "Termination", "Thirst", "Time", "Tolerance", "Tragedy", "Tranquility", "Triumph", "Truth", "Twilight", "Utopia", "Verdicts", "Vigor", "Visions", "Vitality", "Vows", "Water", "Willpower", "Wisdom", "Withdrawal", "Zeal", "the Afterlife", "the Blessed", "the Brave", "the Eclipse", "the Forest", "the Forsaken", "the Future", "the Lake", "the Light", "the Mountain", "the Night", "the Ocean", "the Oracle", "the Outcasts", "the Past", "the Present", "the Prophet", "the River", "the Sea", "the Senses", "the Shadows", "the Solstice", "the Universe", "the Void", "the Volcano", "the World", "the Ancients" };
    string[] templeNames7 = new string[] { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
    string[] templeNames8 = new string[] { "a", "e", "u", "i", "o", "y" };
    string[] templeNames9 = new string[] { "b", "c", "d", "f", "g", "h", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
    string[] templeNames10 = new string[] { "agi", "aldir", "aos", "arus", "borh", "bris", "bum", "bus", "dall", "dar", "darr", "des", "dis", "dite", "dohr", "don", "dos", "dros", "dum", "dur", "emis", "enar", "esis", "eus", "eyar", "eyr", "her", "ion", "ione", "ius", "jun", "ldir", "lios", "lo", "lous", "mes", "mir", "mjir", "mos", "mus", "nia", "nir", "nos", "nus", "ohr", "orr", "rasil", "reus", "ros", "ruer", "rus", "ses", "stus", "tar", "tarr", "teus", "thar", "ther", "tia", "ton", "tos", "tyx", "ysus" };

    string[] templeNames11 = new string[] { "Amaranthine", "Ancestral", "Ancient", "Angel", "Angelic", "Animus", "Argent", "Astral", "August", "Azure", "Blessed", "Blue", "Bright", "Cardinal", "Celestial", "Ceremonial", "Ceremony", "Cerulean", "Clairvoyance", "Corrupted", "Crying", "Dark", "Death", "Devout", "Divine", "Elder", "Eternal", "Ethereal", "Exalted", "Fading", "Father", "Foul", "Ghost", "Glowing", "Golden", "Guilty", "Hallowed", "Harbinger", "Heavenly", "Herald", "Holy", "Honor", "Immortal", "Impious", "Impure", "Ivory", "Legendary", "Light", "Lucent", "Luminescent", "Matriarch", "Mirror", "Mother", "Mythic", "Noble", "Omen", "Oracle", "Origin", "Pale", "Parent", "Patriarch", "Pearl", "Perpetual", "Phantom", "Phoenix", "Pious", "Premonition", "Primal", "Prophecy", "Prophet", "Pure", "Putrid", "Radiant", "Red", "Revelation", "Revered", "Righteous", "Sacred", "Sanctified", "Sanguine", "Shadow", "Silver", "Solemn", "Soul", "Source", "Spirit", "Tainted", "Timeless", "Tribal", "True", "Twin", "Unholy", "Venerable", "Vile", "Virtuous", "Vitality", "Weeping", "White", "Wicked", "Wisdom" };
    string[] templeNames12 = new string[] { "Altar", "Basin", "Beach", "Boulder", "Brook", "Burials", "Catacombs", "Cave", "Cavern", "Chamber", "Chapel", "Church", "Cliff", "Coast", "Column", "Crag", "Creek", "Crypts", "Crystal", "Den", "Enclave", "Estuary", "Field", "Fjord", "Flowers", "Forest", "Fountain", "Garden", "Gazebo", "Geyser", "Grave", "Graves", "Grotto", "Grove", "Hill", "Hot Spring", "Island", "Isle", "Jungle", "Lagoon", "Lake", "Maple", "Marsh", "Meadow", "Menhir", "Monolith", "Monument", "Mosque", "Mountain", "Oak", "Oasis", "Obelisk", "Orchard", "Pagoda", "Pantheon", "Pasture", "Peak", "Pillar", "Pillars", "Pinnacle", "Pond", "Pool", "Pyramid", "Realm", "Reef", "Reliquary", "Ridge", "River", "Rock", "Rocks", "Sanctuary", "Sanctum", "Shore", "Shrine", "Slab", "Statue", "Stone", "Summit", "Synagogue", "Temple", "Terrace", "Thicket", "Tomb", "Topiary", "Totem", "Tower", "Tree", "Trees", "Vertex", "Willow", "Woods", "Yew" };

    public NPC createNPC(int rank)
    {
        int gender = UnityEngine.Random.Range(1, 3);
        NameGenerator gen = new NameGenerator();
        string npcName = gen.createName(gender);
        int npcrelation = UnityEngine.Random.Range(0, 101);
        int playerrelation = UnityEngine.Random.Range(0, 101);
        return new NPC(npcName, gender, npcrelation, playerrelation, rank);
    }

    public string createNationName(int rank)
    {

        int nationChance = UnityEngine.Random.Range(1, 3);
        string name;

        System.Random rand = new System.Random();

        /*int rnd = rand.Next(0, nationNames1.Length);
        int rnd2 = rand.Next(0, nationNames3.Length);
        int rnd3 = rand.Next(0, nationNames2.Length);
        int rnd4 = rand.Next(0, nationNames5.Length);
        int rnd5 = rand.Next(0, nationNames6.Length);
        int rnd6 = rand.Next(0, nationNames5.Length);
        int rnd7 = rand.Next(0, nationNames6.Length);*/

        if (rank > 3)
        {
            switch (nationChance)
            {

                case 1:
                    int rnd = rand.Next(0, nationNames1.Length);
                    int rnd2 = rand.Next(0, nationNames3.Length);
                    int rnd3 = rand.Next(0, nationNames2.Length);
                    int rnd4 = rand.Next(0, nationNames5.Length);
                    
                    name = "" + nationNames1[rnd] + nationNames3[rnd2] + nationNames2[rnd3] + nationNames5[rnd4] + " Empire";
                    return UppercaseWords(name);
                case 2:
                    rnd = rand.Next(0, nationNames1.Length);
                    rnd2 = rand.Next(0, nationNames3.Length);
                    rnd3 = rand.Next(0, nationNames2.Length);
                    if (rnd < 5)
                    {
                        while (rnd3 < 6)
                        {
                            rnd3 = rand.Next(0, nationNames2.Length);
                        }
                    }
                    rnd4 = rand.Next(0, nationNames4.Length);
                    int rnd5 = rand.Next(0, nationNames2.Length);
                    if (rnd3 < 6)
                    {
                        while (rnd5 < 6)
                        {
                            rnd5 = rand.Next(0, nationNames2.Length);
                        }
                    }
                    int rnd6 = rand.Next(0, nationNames5.Length);
                    
                    name = "" + nationNames1[rnd] + nationNames3[rnd2] + nationNames2[rnd3] + nationNames4[rnd4] + nationNames2[rnd5] + nationNames5[rnd6] + " Empire";
                    return UppercaseWords(name);

                default:
                    return "";
            }
        }
        else
        {
            switch (nationChance)
            {
                case 1:
                    int rnd = rand.Next(0, nationNames1.Length);
                    int rnd2 = rand.Next(0, nationNames3.Length);
                    int rnd3 = rand.Next(0, nationNames2.Length);
                    int rnd4 = rand.Next(0, nationNames5.Length);
                    int rnd5 = rand.Next(0, nationNames6.Length);
                    name = "" + nationNames1[rnd] + nationNames3[rnd2] + nationNames2[rnd3] + nationNames5[rnd4] + " " + nationNames6[rnd5];
                    return UppercaseWords(name);
                case 2:
                    rnd = rand.Next(0, nationNames1.Length);
                    rnd2 = rand.Next(0, nationNames3.Length);
                    rnd3 = rand.Next(0, nationNames2.Length);
                    if (rnd < 5)
                    {
                        while (rnd3 < 6)
                        {
                            rnd3 = rand.Next(0, nationNames2.Length);
                        }
                    }
                    rnd4 = rand.Next(0, nationNames4.Length);
                    rnd5 = rand.Next(0, nationNames2.Length);
                    if (rnd3 < 6)
                    {
                        while (rnd5 < 6)
                        {
                            rnd5 = rand.Next(0, nationNames2.Length);
                        }
                    }
                    int rnd6 = rand.Next(0, nationNames5.Length);
                    int rnd7 = rand.Next(0, nationNames6.Length);
                    name = "" + nationNames1[rnd] + nationNames3[rnd2] + nationNames2[rnd3] + nationNames4[rnd4] + nationNames2[rnd5] + nationNames5[rnd6] + " " + nationNames6[rnd7];
                    return UppercaseWords(name);

                default:
                    return "";
            }
        }
        
    }

    public string createKingdomName()
    {
        int kingdomChance = UnityEngine.Random.Range(1, 6);
        string name;

        System.Random rand = new System.Random();

        //int rnd = Math.Floor(Math.r.random() * kingdomN1.length);
        //int rnd2 = Math.Floor(Math.random() * kingdomN2.length);
        //int rnd3 = Math.Floor(Math.random() * kingdomN3.length);
        //int rnd4 = Math.Floor(Math.random() * kingdomN4.length);
        //int rnd5 = Math.Floor(Math.random() * kingdomN5.length);
        int rnd;
        int rnd2;
        int rnd3;
        int rnd4;
        int rnd5;
        //no rnd6 as it is not used

        switch(kingdomChance)
        {
            case 1:
                rnd = rand.Next(0, kingdomN1.Length);
                rnd2 = rand.Next(0, kingdomN2.Length);
                rnd3 = rand.Next(0, kingdomN3.Length);
                rnd4 = rand.Next(0, kingdomN4.Length);
                rnd5 = rand.Next(0, kingdomN5.Length);
                name = "" + kingdomN1[rnd] + kingdomN2[rnd2] + kingdomN3[rnd3] + kingdomN4[rnd4] + kingdomN5[rnd5];
                return UppercaseWords(name); 
            case 2:
                rnd = rand.Next(0, kingdomN1.Length);
                rnd2 = rand.Next(0, kingdomN2.Length);
                rnd3 = rand.Next(0, kingdomN3.Length);
                rnd4 = rand.Next(0, kingdomN6.Length);
                name = "" + kingdomN1[rnd] + kingdomN2[rnd2] + kingdomN3[rnd3] + kingdomN6[rnd4];
                return UppercaseWords(name);
            case 3:
                rnd = rand.Next(0, kingdomN3.Length);
                rnd2 = rand.Next(0, kingdomN4.Length);
                rnd3 = rand.Next(0, kingdomN5.Length);
                name = "" + kingdomN3[rnd] + kingdomN4[rnd2] + kingdomN5[rnd3];
                return UppercaseWords(name);
            case 4:
                rnd = rand.Next(0, kingdomN2.Length);
                rnd2 = rand.Next(0, kingdomN3.Length);
                rnd3 = rand.Next(0, kingdomN6.Length);
                name = "" + kingdomN2[rnd] + kingdomN3[rnd2] + kingdomN6[rnd3];
                return UppercaseWords(name);
            case 5:
                rnd = rand.Next(0, kingdomN3.Length);
                rnd2 = rand.Next(0, kingdomN4.Length);
                rnd3 = rand.Next(0, kingdomN1.Length);
                rnd4 = rand.Next(0, kingdomN3.Length);
                rnd5 = rand.Next(0, kingdomN6.Length);
                name = "" + kingdomN3[rnd] + kingdomN4[rnd2] + kingdomN1[rnd3] + "  " + kingdomN3[rnd4] + kingdomN6[rnd5];
                return UppercaseWords(name);
            default:
                return "";
        }
    }

    public string createCountyName()
    {
        string name;

        System.Random rand = new System.Random();

        int rnd = rand.Next(0, cityName1.Length);
        int rnd2 = rand.Next(0, cityName2.Length);
        while (cityName1[rnd].Equals(cityName2[rnd2], StringComparison.Ordinal))
        {
            rnd2 = rand.Next(0, cityName2.Length); 
        }
        name = cityName1[rnd] + cityName2[rnd2];
        return UppercaseWords(name);
    }

    public string createCityName()
    {
        string name;
        System.Random rand = new System.Random();
        int rnd = rand.Next(0, 2);

        if (rnd == 0)
        {
            name = "City of " + createCountyName();
        }
        else
        {
            name = createCountyName() + " City";
        }
        return UppercaseWords(name);
    }

    public string createCityName(string countyName)
    {
        string name;
        System.Random rand = new System.Random();
        int rnd = rand.Next(0, 2);

        if (rnd == 0)
        {
            name = "City of " + countyName;
        }
        else
        {
            name = countyName + " City";
        }
        return UppercaseWords(name);
    }

    public string createCastleName()
    {
        string name;
        System.Random rand = new System.Random();

        int rnd = rand.Next(0, castleName1.Length);
        int rnd2 = rand.Next(0, castleName2.Length);
        name = castleName1[rnd] + " " + castleName2[rnd2];
        return UppercaseWords(name);
    }

    public string createCastleName(string countyName)
    {
        string name;
        System.Random rand = new System.Random();

        int rnd2 = rand.Next(0, castleName2.Length);
        name = countyName + " " + castleName2[rnd2];
        return UppercaseWords(name);
    }

    public string createTempleName()
    {
        string name;

        System.Random rand = new System.Random();
        int chance = rand.Next(1, 5);
        if(chance == 1)
        {
            int rnd = rand.Next(0, templeNames5.Length);
            int rnd2 = rand.Next(0, templeNames6.Length);
            name = templeNames5[rnd] + " of " + templeNames6[rnd2];
        }
        else if(chance == 2)
        {
            int rnd = rand.Next(0, templeNames5.Length);
            int rnd2 = rand.Next(0, templeNames7.Length);
            int rnd3 = rand.Next(0, templeNames8.Length);
            int rnd4 = rand.Next(0, templeNames9.Length);
            int rnd5 = rand.Next(0, templeNames10.Length);
            name = templeNames5[rnd] + " of " + templeNames7[rnd2] + templeNames8[rnd3] + templeNames9[rnd4] + templeNames10[rnd5];
        }
        else if(chance == 3)
        {
            int rnd = rand.Next(0, templeNames11.Length);
            int rnd2 = rand.Next(0, templeNames12.Length);
            name = "The " + templeNames11[rnd] + " " + templeNames12[rnd2];
        }
        else
        {
            int rnd = rand.Next(0, templeNames1.Length);
            int rnd2 = rand.Next(0, templeNames2.Length);
            int rnd3 = rand.Next(0, templeNames3.Length);
            if (rnd < 20)
            {
                while (rnd3 > 14)
                {
                    rnd3 = rand.Next(0, templeNames3.Length);
                }
            }
            int rnd4 = rand.Next(0, templeNames2.Length);
            if (rnd2 > 4)
            {
                while (rnd4 > 4)
                {
                    rnd4 = rand.Next(0, templeNames2.Length);
                }
            }
            int rnd5 = rand.Next(0, templeNames4.Length);
            name = "The " + templeNames1[rnd] + templeNames2[rnd2] + templeNames3[rnd3] + templeNames2[rnd4] + templeNames4[rnd5];
        }
        return UppercaseWords(name);
    }

    public string createTempleName(string countyName)
    {
        string name;

        System.Random rand = new System.Random();
        int chance = rand.Next(0, 2);
        int rnd = rand.Next(0, templeNames5.Length);
        int rnd1 = rand.Next(0, templeNames6.Length);

        if(chance == 0)
        {
            name = templeNames5[rnd] + " of " + countyName;
        }
        else
        {
            name = countyName + " " + templeNames5[rnd] + " of " + templeNames6[rnd1];
        }

        return UppercaseWords(name);
    }

    string UppercaseWords(string value)
    {
        char[] array = value.ToCharArray();
        // Handle the first letter in the string.
        if (array.Length >= 1)
        {
            if (char.IsLower(array[0]))
            {
                array[0] = char.ToUpper(array[0]);
            }
        }
        // Scan through the letters, checking for spaces.
        // ... Uppercase the lowercase letters following spaces.
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i - 1] == ' ')
            {
                if (char.IsLower(array[i]))
                {
                    array[i] = char.ToUpper(array[i]);
                }
            }
        }
        return new string(array);
    }
}