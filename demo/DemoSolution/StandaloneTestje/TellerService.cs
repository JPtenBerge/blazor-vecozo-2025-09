namespace StandaloneTestje;

public class TellerService : ITellerService
{
    public int Teller { get; set; }

    public void Increment()
    {
        Teller++;
    }
}
