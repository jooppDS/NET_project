using task2;
using task2.test;

//Devicemanager dm = new Devicemanager("C:\\Users\\pc\\RiderProjects\\task2\\task2\\input.txt");

//dm.editDevice(new PersonalComputer(0,"new",true, "sigma"),2);
//Console.WriteLine(dm.ToString());
//dm.saveStorage("C:\\Users\\pc\\RiderProjects\\task2\\task2\\output.txt");


DeviceManagerTest test = new DeviceManagerTest();
test.AddTest();
test.RemoveTest();
test.EditTest();
test.PowerOffTest();
test.PowerOnTest();
test.DisplayTest();
test.SavingTest();