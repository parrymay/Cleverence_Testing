namespace Task_2
{
    public class AsyncCaller
    {
        private EventHandler EventHandler { get; set; }
        private static readonly CancellationTokenSource cts = new CancellationTokenSource();
        public AsyncCaller(EventHandler eventHandler)
        {
            EventHandler = eventHandler;
        }

        public bool Invoke(int timeout, object? sender, EventArgs e)
        {
            bool res;
            try
            {
                cts.CancelAfter(timeout);
                // .Net Core не поддерживает BeginInvoke()
                Task task_1 = Task.Run(() => EventHandler(sender, e));
                task_1.Wait(cts.Token);
            }
            catch (OperationCanceledException) { }
            finally
            {
                res = !cts.IsCancellationRequested;
                cts.Dispose();
            }
            return res;
        }

    }
}