namespace Telepresence.API.Contract.TelepresenceUser
{
    public class TelepresenceUserRegisterRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Identifier { get; set; }
    }
}
