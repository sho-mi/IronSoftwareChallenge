using Keypad;

namespace OldKeyPadTests
{
    [TestClass]
    public class OldKeyPadTest
    {
        [DataTestMethod]
        [DataRow("227*#", "B")]
        [DataRow("33#", "E")]
        [DataRow("4433555 555666#", "HELLO")]
        [DataRow("4433555 55566602222088#", "HELLO 2 U")]
        [DataRow("8 88777444666*664#", "TURING")]
        [DataRow("7777446662244 4448#", "SHOBHIT")]
        [DataRow("4433555 555666 07777446662244 4448#", "HELLO SHOBHIT")]
        [DataRow("44335555555 555*0555666 07777446662244 4448#", "HEL LO SHOBHIT")]
        [DataRow("4433555555*665555555666 07777446662244 4448#", "HENLO SHOBHIT")]
        [DataRow("11111111*#", "")]
        [DataRow("11*0#", " ")]
        [DataRow("1#", "&")]
        [DataRow("1", "")]
        public void TestMethod1(string input, string expectedOutput)
        {
            var output = OldKeyPad.OldPhonePad(input);
            Assert.AreEqual(expectedOutput, output);

        }
    }
}