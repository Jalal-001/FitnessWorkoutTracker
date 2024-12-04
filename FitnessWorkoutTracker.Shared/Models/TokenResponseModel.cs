namespace FitnessWorkoutTracker.Shared.Models
{
    public class TokenResponseModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime TokenExpireDate { get; set; }

        public TokenResponseModel()
        {

        }
        public TokenResponseModel(string accessToken, string refreshToken, DateTime tokenExpireDate)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            TokenExpireDate = tokenExpireDate;
        }
    }
}
