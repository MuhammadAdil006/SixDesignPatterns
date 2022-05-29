// The Mediator interface declares a method used by components to notify the
// mediator about various events. The Mediator may react to these events and
// pass the execution to other components.
public interface Mediator
{
    void Notify(object sender, string ev);
}
// Concrete Mediators implement cooperative behavior by coordinating several
// components.
class ConcreteMediator : Mediator
{
    private ClassA _component1;
    private ClassB _component2;

    public ConcreteMediator(ClassA component1, ClassB component2)
    {
        _component1 = component1;
        _component1.SetMediator(this);
        _component2 = component2;
        _component2.SetMediator(this);
    }
    public void Notify(object sender, string ev)
    {
        if (ev == "A")
        {
            Console.WriteLine("Mediator reacts on A and triggers folowing operations:");
            _component2.DoC();
        }
        if (ev == "D")
        {
            Console.WriteLine("Mediator reacts on D and triggers following operations:");
            _component1.DoB();
            _component2.DoC();
        }
    }
}
// The Base Component provides the basic functionality of storing a
// mediator's instance inside component objects.
class BaseClass
{
    protected Mediator _mediator;
    public BaseClass()
    {
        _mediator = null;
    }
    public void SetMediator(Mediator mediator)
    {
        _mediator = mediator;
    }
}
// Concrete Components implement various functionality. They don't depend on
// other components. They also don't depend on any concrete mediator
// classes.
class ClassA : BaseClass
{
    public void DoA()
    {
        Console.WriteLine("Component 1 does A.");
        _mediator.Notify(this, "A");
    }
    public void DoB()
    {
        Console.WriteLine("Component 1 does B.");
        _mediator.Notify(this, "B");
    }
}
class ClassB : BaseClass
{
    public void DoC()
    {
        Console.WriteLine("Component 2 does C.");
        _mediator.Notify(this, "C");
    }
    public void DoD()
    {
        Console.WriteLine("Component 2 does D.");
        _mediator.Notify(this, "D");
    }
}
class Program
{
    static void Main(string[] args)
    {
        // The client code.
        ClassA component1 = new ClassA();
        ClassB component2 = new ClassB();
        new ConcreteMediator(component1, component2);
        Console.WriteLine("Client triggers operation A.");
        component1.DoA();
        Console.WriteLine();
        Console.WriteLine("Client triggers operation D.");
        component2.DoD();
    }
}