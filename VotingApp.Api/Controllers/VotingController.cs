using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Domain;

namespace VotingApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class VotingController : Controller
    {
        private readonly Voting _voting;
        public VotingController(Voting voting)
        {
            _voting = voting;
        }

        [HttpGet]
        public object Get() => _voting.GetState();

        [HttpPost]
        public object Post([FromBody]string[] values)
        {
            _voting.Start(values);
            return _voting.GetState();
        }

        [HttpPut]
        public object Put([FromBody]string value)
        {
            _voting.Vote(value);
            return _voting.GetState();
        }

        [HttpDelete]
        public object Delete()
        {
            _voting.Finish();
            return _voting.GetState();
        }
    }
}
