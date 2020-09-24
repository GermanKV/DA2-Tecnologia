using SessionInterface;

namespace BusinessLogic
{
    public class SessionLogic : ISessionLogic
    {
        public bool IsCorrectToken(string token)
        {
            return true;
        }
    }
}