namespace sampleWebAPI
{
    public class UserDto
    {
        public Guid guid { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public string vehicalnumber { get; set; }
        public IFormFile Document { get; set; }
        public IFormFile ProfilePhoto { get; set; }
    }
}