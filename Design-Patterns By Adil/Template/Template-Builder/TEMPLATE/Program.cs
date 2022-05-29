using System;
using System.Collections.Generic;
using System.Linq;

//behavioural design pattern

//template method let the subcalasses to redefine certain steps of algorithm without changing the
//structure of algorithm
//steps of algo will be the same but at particular step logic can vary
//
public abstract class Game
{
    //3 abstract methods
    public abstract void initialize();
    public abstract void  startPlay();
    public abstract void  stopPlay();

    //template method
    public virtual void Play()//making it final so that it cannot be overriden
        //so in c sharp there is no final keyword instead you use sealed on child class method
    {
        initialize();
        startPlay();
        stopPlay();
    }
}
public class Cricket : Game
{
    public override void initialize()
    {
        Console.WriteLine("Cricket game is initializing");
    }

    public override void startPlay()
    {
        Console.WriteLine("Cricket game has started");
    }

    public override void stopPlay()
    {
        Console.WriteLine("Cricket game has stopped");
    }
   
}
public class Football : Game
{
    public override void initialize()
    {
        Console.WriteLine("Fooball game is initializing");
    }

    public override void startPlay()
    {
        Console.WriteLine("Football game has started");
    }

    public override void stopPlay()
    {
        Console.WriteLine("Football game has stopped");
    }
    
}

public class Program {
    public static void Main(string[] args)
    {
        Game c = new Cricket();
        Game f = new Football();


        c.Play();
        Console.WriteLine("next");
        f.Play();
    }

}
