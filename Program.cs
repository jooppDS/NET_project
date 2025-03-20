using task2;


Devicemanager dm = new Devicemanager("C:\\Users\\pc\\RiderProjects\\task2\\task2\\input.txt");

dm.editDevice(new PersonalComputer(0,"new",true, "sigma"),2);
Console.WriteLine(dm.ToString());
dm.saveStorage("C:\\Users\\pc\\RiderProjects\\task2\\task2\\output.txt");
