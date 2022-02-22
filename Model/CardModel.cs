namespace ToDo_Uygulaması
{
    public class CardModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int PeopleId { get; set; }
        public string Size { get; set; }
        public CardModel(string title, string content, int peopleId, string size)
        {
            this.Title = title;
            this.Content = content;
            this.PeopleId = peopleId;   
            this.Size = size;
        }
    }
}
