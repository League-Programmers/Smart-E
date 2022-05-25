namespace Smart_E.Models.Profile
{
    public class UpdateUserPostModal
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string PhoneNumber { get; set; }

        public bool Gender { get; set; }
    }
}
