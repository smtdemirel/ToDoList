using System;

namespace ToDo_Uygulaması
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Takım ataması
            TeamUsersList.TeamList.Add(new TeamUserModel(1,"Ahmet"));
            TeamUsersList.TeamList.Add(new TeamUserModel(2,"Aylin"));
            TeamUsersList.TeamList.Add(new TeamUserModel(3,"Selin"));
            TeamUsersList.TeamList.Add(new TeamUserModel(4,"Mehmet"));
            TeamUsersList.TeamList.Add(new TeamUserModel(5,"Selami"));

            //Default Göre Ataması
            TodoLine.TodoLineList.Add(new CardModel("c#", "c# dersi", 1, CardSizeEnumModel.S.ToString()));
            TodoLine.TodoLineList.Add(new CardModel("sql", "sql dersi", 2, CardSizeEnumModel.M.ToString()));

            //Linelar Boarda Atanıyor, yani kart oluşturuluyor
            BoardModel.BoardModelDict.Add("TODO Line", TodoLine.TodoLineList);
            BoardModel.BoardModelDict.Add("IN PROGRESS Line", InProgress.InProgressList);
            BoardModel.BoardModelDict.Add("DONE Line", DoneLine.DoneLineList);

            OperationController.StartPrint();
            int select = int.Parse(Console.ReadLine());
            int control = OperationController.ControlFunction(select);
            while (control == 0)
            {
                OperationController.CallFunction(select);
                OperationController.PrintBoard();
                OperationController.StartPrint();
                select = int.Parse(Console.ReadLine());
                control = OperationController.ControlFunction(select);
            }
            Console.WriteLine("1-4 Aralığı Dışında bir Sayı Girildi, Çıkılıyor...");
            Console.WriteLine("Programı Sonlandırmak için Bir Tuşa Basınız...");
            //OperationController.PrintBoard();
            Console.ReadKey();
        }
    }
}
