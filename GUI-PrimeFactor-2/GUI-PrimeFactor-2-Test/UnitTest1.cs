using Moq;
using Unity;
using GUI_PrimeFactor_2.MVVM.Model;


namespace GUI_PrimeFactor_2_Test
{
    [TestClass]
    public class PrimeFactorTest
    {
        private IUnityContainer _container;

        [TestInitialize]
        public void TestInitialize()
        {
            // Set up the Unity container for dependency injection
            _container = new UnityContainer();
        }
        /** 
         * For each algorithm, there should be atleast a test for the algorithm, and for PrimeFactorModel, for a case in which the algorithm should be called. 
         * In some cases there may need to be more tests.
         */


        /**
         * Test - PrimeFactorModel - for TrialDivisionAlgorithm case
         */
        [TestMethod]
        public void PrimeFactorModel_ReturnsCorrectNameAndFactors_WithDI()
        {
            // Arrange
            var mockAlgorithm = new Mock<IPrimeFactorAlgorithm>();
            mockAlgorithm.Setup(a => a.GetPrimeFactors(It.IsAny<int>())).Returns(new List<int> { 2, 7 });
            mockAlgorithm.Setup(a => a.AlgorithmName).Returns("Mock Algorithm");

            // Register the mock algorithm in the Unity container
            _container.RegisterInstance(mockAlgorithm.Object);

            // Resolve the model with the mock algorithm injected
            var model = _container.Resolve<PrimeFactorModel>();

            // Act
            var factors = model.GetPrimeFactors(28);
            var algorithmName = model.GetAlgorithmName();

            // Assert
            Assert.AreEqual("Mock Algorithm", algorithmName);
            CollectionAssert.AreEqual(new List<int> { 2, 7 }, factors);
        }
        /**
         * Test - TrialDivisionAlgorithm
         */
        [TestMethod]
        public void TrialDivisionAlgorithm_ReturnsCorrectNameAndFactors_WithDI()
        {
            // Arrange
            var mockAlgorithm = new Mock<IPrimeFactorAlgorithm>();
            mockAlgorithm.Setup(a => a.GetPrimeFactors(It.IsAny<int>())).Returns(new List<int> { 3, 11 });
            mockAlgorithm.Setup(a => a.AlgorithmName).Returns("Mock Algorithm");

            // Register the mock algorithm in the Unity container
            _container.RegisterInstance(mockAlgorithm.Object);

            // Resolve the model with the mock algorithm injected
            var model = _container.Resolve<TrialDivisionAlgorithm>();

            // Act
            var factors = model.GetPrimeFactors(99);
            var algorithmName = model.AlgorithmName;

            // Assert
            Assert.AreEqual("Mock Algorithm", algorithmName);
            CollectionAssert.AreEqual(new List<int> { 3, 11 }, factors);
        }
    }
}
