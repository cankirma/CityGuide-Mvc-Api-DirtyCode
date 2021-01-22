namespace api.Dtos
{
    public class PhotoForReturnDto
    {
        public int Id { get; set; }
        public int Url { get; set; }
        public int Description { get; set; }
        public System.DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
    }
}