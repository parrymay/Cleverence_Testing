using CleverenceTest;
using Task_2;

// Визуализация Задачи 1 (раскомментировать код в классе Server)
//for (int i = 0; i < 10; i++)
//{
//    Thread thread_1 = new(()=>Server.GetCount());
//    Thread thread_2 = new(() => Server.AddToCount(1));
//    Thread thread_3 = new(() => Server.GetCount());
//    thread_1.Name = $"thread {i}";
//    thread_2.Name = $"thread {i + 1}";
//    thread_3.Name = $"thread {i + 2}";
//    thread_1.Start();
//    thread_2.Start();
//    thread_3.Start();
//}



// Визуализация Задачи 2 
// Если timeout в методе Invoke < Thread.Sleep, делегат прерывается
// В случае работы без прерывания, completedOk = true и выводится сообщение "Hello!"

//EventHandler h = new EventHandler(TestMethod);
//AsyncCaller ac = new(h);
//bool completedOk = ac.Invoke(5000, null, EventArgs.Empty);
//Console.WriteLine(completedOk);

//void TestMethod(object? timeout, EventArgs eventArgs)
//{
//    Thread.Sleep(2000);
//    Console.WriteLine("Hello!");
//}