namespace Smart_E.Models.AdministrationViewModels
{
    public class ProfileViewModel
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string Role { get; set; }

        public string Surname { get; set; }

        public string UserReference { get; set; }

        public  string Email { get; set; }

        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string JobDescription { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string ProfilePictureFileName { get; set; }

        public string PhoneNumber { get; set; }
        public string Status { get; internal set; }
    }
}
