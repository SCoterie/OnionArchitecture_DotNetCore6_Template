namespace OA.Models.ViewModel
{
    public class UserViewModel : UserCommonViewModel
    {
        public string? Id { get; set; }
    }
    public abstract class UserCommonViewModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
    }
    public class UserSignupViewModel : UserCommonViewModel
    {
        public string? Password { get; set; }
        public string? CnfPassword { get; set; }
    }
    public class UserUpdateViewModel : UserCommonViewModel
    {
        public string? Id { get; set; }
    }
}
