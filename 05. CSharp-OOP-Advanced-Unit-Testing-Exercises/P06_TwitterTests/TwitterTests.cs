using Moq;
using NUnit.Framework;
using P06_Twitter.Contracts;
using P06_Twitter.IO.Writers;
using P06_Twitter.Models;
using P06_Twitter.Repositories;
using System.IO;
using System.Linq;

namespace P06_TwitterTests
{
    public class TwitterTests
    {
        private const string Message = "A pretty random test message.";
        private IWriter writer;
        private ITweetRepository repository;
        private readonly string filePath = @"..\..\..\ServerFile.txt";

        [SetUp]
        public void InitializeTest()
        {
            this.writer = new ConsoleWriter();
            this.repository = new TweetRepository();
        }

        [Test]
        public void MicrowaveMethodSendTweetToServerShouldCreateAServerFile()
        {
            var microwaveOven = new MicrowaveOven(writer, repository);

            microwaveOven.SendTweetToServer(Message);

            FileAssert.Exists(filePath);

            string[] serverFileContents = File.ReadLines(filePath).ToArray();

            Assert.IsTrue(serverFileContents.ToString().Length > 0);
            Assert.Contains(Message, serverFileContents);
        }

        [Test]
        public void MicrowaveShouldInvokeItsRepositoryToSendMessagesToServer()
        {
            var repo = new Mock<ITweetRepository>();

            repo.Setup(r => r.SaveTweet(It.IsAny<string>()));

            var microwaveOven = new MicrowaveOven(writer, repo.Object);

            microwaveOven.SendTweetToServer(Message);

            repo.Verify(r => r.SaveTweet(It.IsAny<string>()), Times.Once, "Microwave did not invoke its Repository");
        }

        [Test]
        public void MicrowaveInvokesItsWriterToWriteMessages()
        {

            var writer = new Mock<IWriter>();

            writer.Setup(w => w.WriteLine(It.IsAny<string>()));

            var microwaveOven = new MicrowaveOven(writer.Object, repository);

            microwaveOven.WriteTweet(Message);

            writer.Verify(w => w.WriteLine(It.Is<string>(s => s == Message)), Times.Once, "Microwave did not invoke its writer");
        }


        [Test]
        public void TweetShouldInvokeClientToWriteMessage()
        {
            var client = new Mock<IClient>();

            client.Setup(w => w.WriteTweet(It.IsAny<string>()));

            Tweet tweet = new Tweet(client.Object);

            tweet.ReceiveMessage(Message);

            client.Verify(c => c.WriteTweet(It.IsAny<string>()), Times.Once, "Tweet did not invoke its client");

        }

        [Test]
        public void TweetShouldInvokeClientToSendToServer()
        {

            var client = new Mock<IClient>();

            client.Setup(w => w.WriteTweet(It.IsAny<string>()));

            Tweet tweet = new Tweet(client.Object);

            tweet.ReceiveMessage(Message);

            client.Verify(c => c.SendTweetToServer(It.IsAny<string>()), Times.Once, "Tweet did not invoke its client");

        }
    }
}
