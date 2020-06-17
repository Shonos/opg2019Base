using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opg_201910_interview.BusinessLogic;
using opg_201910_interview.Models;

namespace opg_2019_interview_daroya_test
{
    [TestClass]
    public class ClientBBusinessLogicTests
    {
        [TestMethod]
        public void ClientB_Config_Should_Return_ClientB_Instance()
        {
            // Arrange
            IOptions<ClientSettingsModel> options = Options.Create(new ClientSettingsModel()
            {
                ClientId = 2001,
                FileDirectoryPath = "UploadFiles/ClientB"
            });

            // Act
            var businessLogicInstance = ClientFactory.GetClientBusinessLogic(options);

            // Assert
            Assert.IsInstanceOfType(businessLogicInstance, typeof(ClientBBusinessLogic));
        }

        [TestMethod]
        public void Should_Enumerate_Correct_Number_Of_Files()
        {
            // Arrange
            IOptions<ClientSettingsModel> options = Options.Create(new ClientSettingsModel()
            {
                ClientId = 2001,
                FileDirectoryPath = "UploadFiles/ClientB"
            });

            // Act
            var files = ClientFactory.GetClientBusinessLogic(options).EnumerateFiles();

            // Assert
            Assert.AreEqual(files.Count, 5); // 5 correct files on directory
        }




    }
}
