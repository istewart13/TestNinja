using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _mockFileDownloader;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void SetUp()
        {
            _mockFileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_mockFileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_UnableToDownloadFile_ReturnsFalse()
        {
            _mockFileDownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void DownloadInstaller_DownloadFileSuccessfully_ReturnsTrue()
        {
            var result = _installerHelper.DownloadInstaller("customer", "installer");
            Assert.That(result, Is.True);
        }
    }
}
