using Task_1;
using Task_2;

//Задание 1
//Есть "сервер" в виде статического класса.  
//У него есть переменная count (тип int) и два метода, которые позволяют эту переменную читать и писать: GetCount() и AddToCount(int value). 
//К серверу стучатся множество параллельных клиентов, которые в основном читают, но некоторые добавляют значение к count. 

//Нужно реализовать GetCount / AddToCount так, чтобы: 
//читатели могли читать параллельно, без выстраивания в очередь по локу;
//писатели писали только последовательно и никогда одновременно;
//пока писатели добавляют и пишут, читатели должны ждать окончания записи.

// Визуализация Задачи 1 (раскомментировать код в классе Server)
for (int i = 0; i < 10; i++)
{
    Thread thread_1 = new(() => Server.GetCount());
    Thread thread_2 = new(() => Server.AddToCount(1));
    Thread thread_3 = new(() => Server.GetCount());
    thread_1.Name = $"thread {i}";
    thread_2.Name = $"thread {i + 1}";
    thread_3.Name = $"thread {i + 2}";
    thread_1.Start();
    thread_2.Start();
    thread_3.Start();
}


//Задание 2
//В.net есть возможность звать делегаты как синхронно: 
//EventHandler h = new EventHandler(this.myEventHandler);
//h.Invoke(null, EventArgs.Empty);
//так и асинхронно:
//var res = h.BeginInvoke(null, EventArgs.Empty, null, null);

//Нужно реализовать возможность полусинхронного вызова делегата (написать реализацию класса AsyncCaller),
//который бы работал таким образом: 

//EventHandler h = new EventHandler(this.myEventHandler);
//ac = new AsyncCaller(h);
//bool completedOK = ac.Invoke(5000, null, EventArgs.Empty);

//"Полусинхронного" в данном случае означает, что делегат будет вызван, и вызывающий поток будет ждать,
//пока вызов не выполнится.  Но если выполнение делегата займет больше 5000 миллисекунд, то ac.Invoke выйдет
//и вернет в completedOK значение false.


// Визуализация Задачи 2 
// Если timeout в методе Invoke < Thread.Sleep, делегат прерывается
// В случае работы без прерывания, completedOk = true и выводится сообщение "Hello!"

EventHandler h = new EventHandler((object? sleep, EventArgs eventArgs) =>
{
    Thread.Sleep(1000);
    Console.WriteLine("Hello");
});
AsyncCaller ac = new(h);
bool completedOk = ac.Invoke(5000, null, EventArgs.Empty);
Console.WriteLine(completedOk);