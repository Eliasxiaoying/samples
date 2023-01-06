namespace _17_ModelBindSample.Models;

/// <summary>
/// 地理位置
/// </summary>
public class Geolocation
{
    /// <summary>
    /// 经度
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// 纬度
    /// </summary>
    public double Latitude { get; set; }

    public Geolocation(double lat, double lon)
    {
        Latitude = lat;
        Longitude = lon;
    }

    public Geolocation()
    {
        
    }

    /// <summary>
    /// 经纬度坐标表示
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"({Longitude},{Latitude})";
    }
}