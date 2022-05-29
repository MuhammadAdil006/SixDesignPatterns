// The Subject interface declares common operations for both RealSubject and
// the Proxy. As long as the client works with RealSubject using this
// interface, you'll be able to pass it a proxy instead of a real subject.
public interface Interface
{
    void Request();
}
// The RealSubject contains some core business logic. Usually, RealSubjects
// are capable of doing some useful work which may also be very slow or
// sensitive - e.g. correcting input data. A Proxy can solve these issues
// without any changes to the RealSubject's code.
class RealSubject : Interface
{
    public bool isAccessible;
    public RealSubject(bool isAccess)
    {
        isAccessible = isAccess;
    }
    public void Request()
    {
        Console.WriteLine("Handling Request.......");
    }
}
// The Proxy has an interface identical to the RealSubject.
class Proxy : Interface
{
    private RealSubject _realSubject;
    public Proxy(RealSubject realSubject)
    {
        _realSubject = realSubject;
    }
    // The most common applications of the Proxy pattern are lazy loading,
    // caching, controlling the access, logging, etc. A Proxy can perform
    // one of these things and then, depending on the result, pass the
    // execution to the same method in a linked RealSubject object.
    public void Request()
    {
        if (CheckAccess(_realSubject)==true)
        {
            Console.WriteLine("Access Granted!");
            _realSubject.Request();
            LogAccess();
        }
        else
        {
            Console.WriteLine("Access Denied!");
        }
    }
    public bool CheckAccess(RealSubject rs)
    {
        if (rs.isAccessible == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void LogAccess()
    {
        Console.WriteLine("Log is Accessed with Proxy.");
    }
}

public class Client
{
    // The client code is supposed to work with all objects (both subjects
    // and proxies) via the Subject interface in order to support both real
    // subjects and proxies. In real life, however, clients mostly work with
    // their real subjects directly. In this case, to implement the pattern
    // more easily, you can extend your proxy from the real subject's class.
    public void ClientCode(Interface subject)
    {
        subject.Request();
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool Access;
        Client client = new Client();
        Console.WriteLine("Client1: Executing the client code without acccess:");
        //Client1 is not granted permission to access Log 
        RealSubject Client1 = new RealSubject(Access = false);
        Proxy proxy = new Proxy(Client1);
        client.ClientCode(proxy);
        //Client2 is granted permission to access Log
        Console.WriteLine("Client2: Executing the client code with acccess!");
        RealSubject Client2 = new RealSubject(Access = true);
        Proxy proxy_ = new Proxy(Client2);
        client.ClientCode(proxy_);
    }
}
    