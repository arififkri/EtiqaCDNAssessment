namespace etiqaAPI.Dto.UserDto
{
    public class EditUserDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public int PhoneNumber { get; set; }

        public string skillsets { get; set; }

        public string Hobby { get; set; }

    }
}
