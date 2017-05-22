using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SortByInt
{

	
}

public class SortByDip : IComparer<Advisor>
{
    public int Compare(Advisor x, Advisor y)
    {
        return x.diplomacy.CompareTo(y.diplomacy);
    }
}

public class SortBySte : IComparer<Advisor>
{
    public int Compare(Advisor x, Advisor y)
    {
        return x.stewardship.CompareTo(y.stewardship);
    }
}

public class SortByMar : IComparer<Advisor>
{
    public int Compare(Advisor x, Advisor y)
    {
        return x.martial.CompareTo(y.martial);
    }
}

public class SortByIntr : IComparer<Advisor>
{
    public int Compare(Advisor x, Advisor y)
    {
        return x.intrigue.CompareTo(y.intrigue);
    }
}

public class SortByLear : IComparer<Advisor>
{
    public int Compare(Advisor x, Advisor y)
    {
        return x.learning.CompareTo(y.learning);
    }
}

public class SortByAra : IComparer<Advisor>
{
    public int Compare(Advisor x, Advisor y)
    {
        return x.arcane.CompareTo(y.arcane);
    }
}



