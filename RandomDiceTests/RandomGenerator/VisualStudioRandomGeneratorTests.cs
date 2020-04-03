using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RandomDice.RandomGenerator.Tests
{
    [TestClass()]
    public class VisualStudioRandomGeneratorTests
    {
        [TestMethod()]
        public void randomGeneratorIntervalCheckTest()
        {
            IntervalRandomGenerator randomGenerator = new VisualStudioRandomGenerator();
            int lowerBound = -1;
            int upperBound = +1;
            int[] generatedInteger = { 0, 0, 0 };
            for (int i = 0; i < 100; i++)
            {
                int generatedNumber = randomGenerator.generateRandomNumber(lowerBound, upperBound);
                Assert.IsTrue((lowerBound <= generatedNumber && generatedNumber <= upperBound),"["+lowerBound+ "," + upperBound +"] Generated number:"+generatedNumber);
            }
        }
        [TestMethod()]
        public void randomGeneratorDistributionTest()
        {
            IntervalRandomGenerator randomGenerator = new VisualStudioRandomGenerator();
            int lowerBound = -1;
            int upperBound = +1;
            int[] generatedInteger = { 0, 0, 0 };
            for (int i = 0; i < 3500; i++)
            {
                int generatedNumber = randomGenerator.generateRandomNumber(lowerBound, upperBound);
                generatedInteger[generatedNumber + 1]++;
            }
            for(int i=0; i<generatedInteger.Length; i++)
            {
                Assert.IsTrue(1000<generatedInteger[i],"Missing dice value is "+(i-1)+". Total generated number from this value:"+ generatedInteger[i]);
            }            
        }
    }
}