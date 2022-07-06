using CleverenceTest;
using System.Reflection;

namespace Count.Test
{
    public class ServerTest
    {
        [Fact]
        public void AddCount_3_StartCount_0_3returned()
        {
            //Arrange
            int input = 3;
            int expected = 3;
            int startCount = 0;
            Type type = typeof(Server);
            var countField = type.GetProperty("Count", BindingFlags.Static | BindingFlags.NonPublic);
            countField.SetValue(null, startCount);

            //Act
            Server.AddToCount(3);
            int count = (int)countField.GetValue(null);

            //Assert
            Assert.Equal(expected, count);
        }

        [Fact]
        public void AddCount_3_StartCount_5_8returned()
        {
            //Arrange
            int input = 3;
            int expected = 8;
            int startCount = 5;
            Type type = typeof(Server);
            var countField = type.GetProperty("Count", BindingFlags.Static | BindingFlags.NonPublic);
            countField.SetValue(null, startCount );

            //Act
            Server.AddToCount(3);
            int count = (int)countField.GetValue(null);

            //Assert
            Assert.Equal(expected, count);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(5, 5)]
        [InlineData(100, 100)]
        public void GetCount_expected(int expected, int startCount)
        {
            // Arrange
            Type type = typeof(Server);
            var countField = type.GetProperty("Count", BindingFlags.Static | BindingFlags.NonPublic);
            countField.SetValue(null, startCount);

            // Act
            var result = Server.GetCount();

            // Assert
            Assert.Equal(expected, startCount);
        }
    }
}