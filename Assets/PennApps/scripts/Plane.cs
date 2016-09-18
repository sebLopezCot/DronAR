using System.Collections;

public class Plane {

    public string altitude { get; set; }
    public string temperature { get; set; }
    public string timestamp { get; set; }
    public string lat0 { get; set; }
    public string lon0 { get; set; }
    public string lat1 { get; set; }
    public string lon1 { get; set; }
    public string eta { get; set; }

    public Plane(string timestamp, string lat0, string lon0, string lat1, string lon1, string altitude, string eta, string temperature) {
        this.altitude = altitude;
        this.temperature = temperature;
        this.timestamp = timestamp;
        this.lat0 = lat0;
        this.lon0 = lon0;
        this.lat1 = lat1;
        this.lon1 = lon1;
        this.eta = eta;
    }

}
