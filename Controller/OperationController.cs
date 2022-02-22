using System;

namespace ToDo_Uygulaması
{
    public static class OperationController
    {
        public static void AddUser()
        {

        }
        public static string PeopleIdToName(int id)
        {
            foreach(var item in TeamUsersList.TeamList)
            {
                if(item.Id == id)
                {
                    return item.UserName;
                }
            }
            return null;
        }
        public static void UserPrint()
        {
            Console.WriteLine("***Kişi Listesi***");
            foreach(var item in TeamUsersList.TeamList)
            {
                Console.WriteLine("Kişi Numarası: {0} , Kişi Adı: {1}", item.Id, item.UserName);
            }
            Console.WriteLine("***Kişiler Sonu***");
        }
        public static void CallFunction(int number)
        {
            if(number == 1)
            {
                PrintBoard();
            }else if(number == 2)
            {
                AddCard();
            }else if(number == 3)
            {
                DeleteCard();
            }else if(number == 4)
            {
                MoveCard();
            }
        }
        public static int ControlFunction(int number)
        {
            if(number >=1 && number <= 4)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public static void StartPrint()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz:)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");
        }
        public static string EnumToSize(int number)
        {
            if(number == 1)
            {
                return CardSizeEnumModel.XS.ToString();
            }else if(number == 2)
            {
                return CardSizeEnumModel.S.ToString();
            }else if(number == 3)
            {
                return CardSizeEnumModel.M.ToString();
            }else if (number == 4)
            {
                return CardSizeEnumModel.L.ToString();
            }
            else
            {
                return CardSizeEnumModel.XL.ToString();
            }
        }
        public static void PrintBoard()
        {
            foreach (var item in BoardModel.BoardModelDict)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine("************************");
                int counter = item.Value.Count;
                if (counter == 0)
                {
                    Console.WriteLine("~ BOŞ ~");
                }
                foreach (var item2 in item.Value)
                {
                    counter--;
                    Console.WriteLine("Başlık: {0}", item2.Title);
                    Console.WriteLine("İçerik: {0}", item2.Content);
                    Console.WriteLine("Atanan Kişi Numarası: {0} , Atanan Kişi Adı: {1}",item2.PeopleId, PeopleIdToName(item2.PeopleId));
                    Console.WriteLine("Büyüklük: {0}", item2.Size);
                    if (counter >= 1)
                    {
                        Console.WriteLine("-");
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }
        public static void AddCard()
        {
            Console.WriteLine("Başlık Giriniz: ");
            string title = Console.ReadLine();
            Console.WriteLine("İçerik Giriniz: ");
            string content = Console.ReadLine();
            Console.WriteLine("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5): ");
            Console.WriteLine("Eğer 1-5 Aralığı Dışında değer girerseniz default olarak XL atanacaktır.");
            int sizeNumber = int.Parse(Console.ReadLine());
            string size = EnumToSize(sizeNumber);
            UserPrint();
            Console.WriteLine("Eklemek İstediğiniz Kişi Listede Mevcut mu?");
            Console.WriteLine("Mevcutsa y, Değilse n giriniz.");
            Console.WriteLine("y/n");
            string userControl = Console.ReadLine();
            if(userControl == "y") { 
            Console.WriteLine("Lütfen Görev Eklemek İstediğiniz Kişi Id Numarasını Giriniz: ");
            int peopleId = int.Parse(Console.ReadLine());
            int control = 0;
            foreach (var item in TeamUsersList.TeamList)
            {
                if(item.Id == peopleId)
                {
                    Console.WriteLine("Kişi mevcut ekleme başarılı...");
                    TodoLine.TodoLineList.Add(new CardModel(title,content,peopleId,size));
                    control++;
                }
            }
            if(control == 0)
            {
                Console.WriteLine("Kişi bulunamadı, işlemden çıkılıyor...");
            }
            }
            else if(userControl == "n")
            {
                Console.WriteLine("Kişi Eklemek İster misiniz? y/n");
                string userAddControl = Console.ReadLine();
                if (userAddControl == "y")
                {
                    UserPrint();
                    Console.WriteLine("Kişi Adı Giriniz: ");
                    string UserAddUsername = Console.ReadLine();
                    int UserAddId = ((TeamUsersList.TeamList.Count) + 1);
                    TeamUsersList.TeamList.Add(new TeamUserModel(UserAddId, UserAddUsername));
                    Console.WriteLine("Kişi mevcut ekleme başarılı...");
                    TodoLine.TodoLineList.Add(new CardModel(title, content, UserAddId, size));
                }
                else
                {
                    Console.WriteLine("Çıkılıyor...");
                }
            }
            else
            {
                Console.WriteLine("Hatalı Karakter girildi, çıkılıyor...");
            }
        }
        public static void DeleteCard()
        {
            int control = 0;
            int check = 0;
            string title = "";
            while (control == 0)
            {
                Console.WriteLine(" Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
                Console.WriteLine(" Lütfen kart başlığını yazınız:  ");
                title = Console.ReadLine();
                foreach (var item in BoardModel.BoardModelDict)
                {
                    foreach (var item2 in item.Value)
                    {
                        if (item2.Title == title)
                        {
                            Console.WriteLine("Kart bulundu siliniyor...");
                            item.Value.Remove(item2);
                            control++;
                            break;
                        }
                    }
                }
                if(control == 0)
                {
                    Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("* Silmeyi sonlandırmak için: (1)");
                    Console.WriteLine("* Yeniden denemek için : (2)");
                    check = int.Parse(Console.ReadLine());
                    if(check == 1)
                    {
                        control++;
                    }
                    

                }

            }
            
        }
        public static void MoveCard()
        {
            int control = 0;
            int check = 0;
            int lineNumber;
            string title = "";
            while (control == 0)
            {
                Console.WriteLine("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.");
                Console.WriteLine("Lütfen kart başlığını yazınız:");
                title = Console.ReadLine();

                foreach (var item in BoardModel.BoardModelDict)
                {
                    if(control == 0) { 
                    foreach (var item2 in item.Value)
                    {
                        if (item2.Title == title)
                        {
                            Console.WriteLine("Bulunan Kart Bilgileri:");
                            Console.WriteLine("**************************************");
                            Console.WriteLine("Başlık: {0}",item2.Title);
                            Console.WriteLine("İçerik: {0}", item2.Content);
                            Console.WriteLine("Atanan Kişi: {0}", item2.PeopleId);
                            Console.WriteLine("Büyüklük: {0}", item2.Size);
                            Console.WriteLine("Line: {0}", item.Key);
                            Console.WriteLine("Lütfen taşımak istediğiniz Line Numarasını giriniz:");
                            Console.WriteLine("(1) TODO");
                            Console.WriteLine("(2) IN PROGRESS");
                            Console.WriteLine("(3) DONE");
                            lineNumber = int.Parse(Console.ReadLine());
                            if(lineNumber == 1)
                            {
                                TodoLine.TodoLineList.Add(new CardModel(item2.Title, item2.Content, item2.PeopleId, item2.Size));
                                item.Value.Remove(item2);
                                control++;
                                break;
                            }
                            else if(lineNumber == 2)
                            {
                                InProgress.InProgressList.Add(new CardModel(item2.Title, item2.Content, item2.PeopleId, item2.Size));
                                item.Value.Remove(item2);
                                control++;
                                break;
                            }
                            else if (lineNumber == 3)
                            {
                                DoneLine.DoneLineList.Add(new CardModel(item2.Title, item2.Content, item2.PeopleId, item2.Size));
                                item.Value.Remove(item2);
                                control++;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Hatalı giriş çıkılıyor...");
                                control++;
                                break;
                            }
                        }
                        if (control > 0)
                        {
                            break;
                        }
                    }
                    }
                }
                if (control == 0)
                {
                    Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("* Silmeyi sonlandırmak için: (1)");
                    Console.WriteLine("* Yeniden denemek için : (2)");
                    check = int.Parse(Console.ReadLine());
                    if (check == 1)
                    {
                        control++;
                    }


                }

            }

        }
    }
}
