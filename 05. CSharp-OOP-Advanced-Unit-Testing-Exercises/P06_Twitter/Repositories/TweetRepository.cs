using P06_Twitter.Contracts;
using System;
using System.IO;

namespace P06_Twitter.Repositories
{
    public class TweetRepository : ITweetRepository
    {
        public readonly string filePath = @"..\..\..\ServerFile.txt";

        /*Creates a "server" txt file, containing the sent tweets, because I didn't understand 
        what exaclty it was supposed to do by reading the problem description.*/
        public void SaveTweet(string content) 
        {
            File.AppendAllText(this.filePath, $"{content}{Environment.NewLine}");
        }
    }
}
