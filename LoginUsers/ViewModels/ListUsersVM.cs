namespace LoginUsers.ViewModels
{
    public class ListUsersVM
    {
        public List<UserDto> Users { get; set; } = new List<UserDto>();
        public string Message { get; set; }
    }

    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }

    }


}
