using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VotingApp.Domain;

namespace VotingApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class VotingController : Controller
    {
        private readonly int votingstep;
        private readonly Voting _voting;
        private readonly ILogger<VotingController> _logger;

        public VotingController(Voting voting, ILogger<VotingController> logger, IConfiguration config)
        {
            votingstep = config.GetValue<int>("VOTING_STEP", 1);
            logger.LogInformation($"Voting step {votingstep}");
            _voting = voting;
            _logger = logger;
        }

        [HttpGet]
        public object Get() => _voting.GetState();

        [HttpPost]
        public object Post([FromBody]string[] values)
        {
            _logger.LogInformation("Starting Voting");
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
