namespace madden.Services;

public class ServiceManagement : IServiceManagement
{
    public void GenerateMerchandise()
    {
        Console.WriteLine("Generate Merchandise at: " + DateTime.Now.ToString("yyy-MM-dd HH:nn:ss"));
    }

    public void SendEmail()
    {
        throw new NotImplementedException();
    }

    public void SyncData()
    {
        throw new NotImplementedException();
    }

    public void UpdateDatabase()
    {
        throw new NotImplementedException();
    }
}