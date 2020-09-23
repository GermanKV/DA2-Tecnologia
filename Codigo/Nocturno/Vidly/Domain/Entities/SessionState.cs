using System;

namespace Domain
{
    public class SessionState
    {
        public int Id { get; set; }
        public Guid Token { get; set; }

        public int UserId { get; set; }
        
        public User User { get; set; }
    }
}