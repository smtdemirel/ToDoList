namespace ToDo_Uygulaması
{
    public class TeamUserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public TeamUserModel(int id, string username)
        {
            this.Id = id;
            this.UserName = username;
        }

    }
}
