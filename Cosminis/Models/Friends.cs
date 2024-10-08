using System;
using System.Collections.Generic;
using CustomExceptions;

namespace Models;

public enum RelationshipStatus                            
{
    Pending, Accepted, Removed, Blocked
}

public class FriendsStatusWithEnum
{ 
    public int RelationshipId { get; set; }
    public int userFrom_fk { get; set; }
    public int userTo_fk { get; set; }
    public RelationshipStatus Status { get; set; }
    
    public string StatusToString(RelationshipStatus Status)                                   
    {
        Dictionary<RelationshipStatus, string> dictStatus = new Dictionary<RelationshipStatus, string>()
        {
            {RelationshipStatus.Pending, "Pending"},
            {RelationshipStatus.Accepted, "Accepted"},
            {RelationshipStatus.Removed, "Removed"},
            {RelationshipStatus.Blocked, "Blocked"},
        };

        if(dictStatus.ContainsKey(Status))
        {
            return dictStatus[Status];
        }
        throw new StatusNotFound();
    }

    public override string ToString()
    { 
        return 
            $"RelationshipId: {this.RelationshipId}, " + 
            $"UserId of requester: {this.userFrom_fk}, " + 
            $"UserId of responder: {this.userTo_fk}, " + 
            $"Status: {this.Status}"; 
    }  
}