using System.Collections.Generic;

public class Properties
{
    public string name { get; set; }
}

public class Crs
{
    public string type { get; set; }
    public Properties properties { get; set; }
}

public class Geometry
{
    public string type { get; set; }
    public List<List<List<double>>> coordinates { get; set; }
}

public class Properties2
{
    public string name { get; set; }
    public string nas_ime { get; set; }
    public int season_id { get; set; }
    public string field_id { get; set; }
}

public class Feature
{
    public string type { get; set; }
    public int id { get; set; }
    public Geometry geometry { get; set; }
    public Properties2 properties { get; set; }
}

public class GetFiledsBySeasonId
{
    public string type { get; set; }
    public Crs crs { get; set; }
    public List<Feature> features { get; set; }
}