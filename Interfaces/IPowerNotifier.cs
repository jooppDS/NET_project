namespace task2.Interfaces;

public interface IPowerNotifier {
    public void Notify(long power) {
        Console.WriteLine("Low power: " + power + "%");
    }
}