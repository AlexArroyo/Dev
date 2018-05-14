using System;
using System.Collections.Generic;
using Xunit;
using VotingApp.Domain;

namespace VotingApp.Test
{
    public class VotingTest
    {
        [Fact]
        public void Start_Voting_Test()
        {
            var voting = new Voting();

            voting.Start("C#", "Java");

            Assert.Equal(new Dictionary<string, int>{
                {"C#", 0},
                {"Java", 0},
            }, voting.Votes);
        }

        [Fact]
        public void Vote_Test()
        {
            var voting = new Voting();

            voting.Start("C#", "Java");
            voting.Vote("C#");

            Assert.Equal(new Dictionary<string, int>{
                {"C#", 1},
                {"Java", 0},
            }, voting.Votes);
        }

        [Fact]
        public void Finish_Test()
        {
            var voting = new Voting();

            voting.Start("C#", "Java");
            voting.Vote("C#");
            voting.Finish();

            Assert.Equal("C#", voting.Winner);
        }
    }
}
