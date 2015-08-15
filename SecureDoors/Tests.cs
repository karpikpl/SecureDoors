using System.IO;
using System.Text;
using NUnit.Framework;

namespace SecureDoors
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Solver_Should_GiveCorrectAnswer()
        {
            // Arrange
            Solver solver = new Solver();
            const string input =
 @"8
entry Abbey
entry Abbey
exit Abbey
entry Tyrone
exit Mason
entry Demetra
exit Latonya
entry Idella";
            const string expected = @"Abbey entered
Abbey entered (ANOMALY)
Abbey exited
Tyrone entered
Mason exited (ANOMALY)
Demetra entered
Latonya exited (ANOMALY)
Idella entered
";

            // Act
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(input)))
            using (var outMs = new MemoryStream())
            {
                solver.Solve(ms, outMs);
                outMs.Position = 0;
                var result = new StreamReader(outMs).ReadToEnd();

                // Assert
                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}
