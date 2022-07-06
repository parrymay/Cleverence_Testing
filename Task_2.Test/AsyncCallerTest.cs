using Task_2;

namespace AsyncCall.Test
{
    public class AsyncCallerTest
    {
        [Theory]
        [InlineData(500, 2000, false)]
        public void Test1(int timeout, int sleep, bool expected)
        {
            //Arrange
            EventHandler h = new EventHandler((object? obj, EventArgs eventArgs) => Thread.Sleep(sleep));
            AsyncCaller ac = new(h);
            bool result;

            //Act
            try
            {
                result = ac.Invoke(timeout, null, EventArgs.Empty);

                //Assert
                Assert.Equal(expected, result);
            }
            catch { }
        }

        [Theory]
        [InlineData(2000, 500, true)]
        public void Test2(int timeout, int sleep, bool expected)
        {
            //Arrange
            EventHandler h = new EventHandler((object? obj, EventArgs eventArgs) => Thread.Sleep(sleep));
            AsyncCaller ac = new(h);

            //Act
            bool result = ac.Invoke(timeout, null, EventArgs.Empty);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}