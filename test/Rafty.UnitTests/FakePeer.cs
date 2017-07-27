namespace Rafty.UnitTests
{
    using System.Collections.Generic;
    using Concensus;

    internal class FakePeer : IPeer
    {
        private readonly bool _grantVote;
        private readonly bool _appendEntry;

        public FakePeer(bool grantVote)
        {
            _grantVote = grantVote;
        }

        public FakePeer(bool grantVote, bool appendEntry)
        {
            _grantVote = grantVote;
            _appendEntry = appendEntry;
        }

        public List<RequestVoteResponse> RequestVoteResponses { get; } = new List<RequestVoteResponse>();

        public List<AppendEntriesResponse> AppendEntriesResponses { get; } = new List<AppendEntriesResponse>();

        public RequestVoteResponse Request(RequestVote requestVote)
        {
            var response = new RequestVoteResponse(_grantVote, 1);
            RequestVoteResponses.Add(response);
            return response;
        }

        public AppendEntriesResponse Request(AppendEntries appendEntries)
        {
            var response = new AppendEntriesResponse(1, _appendEntry);
            AppendEntriesResponses.Add(response);
            return response;
        }
    }
}