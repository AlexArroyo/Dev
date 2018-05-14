using System;
using System.Collections.Generic;
using System.Linq;

namespace VotingApp.Domain
{
    public class Voting
    {
        public Voting()
        {
        }

        public Dictionary<string, int> Votes { get; private set; }
        public string Winner { get; private set;}

        public void Start(params string[] options)
        {
            Votes = options.ToDictionary(x => x, _ => 0);
        }

        public void Vote(string option) => Votes[option]++;

        public void Finish() 
        {
            var maxVotes = Votes.Max(x => x.Value);
            Winner = Votes.First(x => x.Value == maxVotes).Key;
        }

        public object GetState() => new
        {
            Votes,
            Winner
        };
    }

}
