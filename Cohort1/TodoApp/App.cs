using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    internal class App
    {
        private ItemRepository Itemrepo;
        public ConsoleUtils ConsoleUtils;
        private string command;

        public App()
        {
            Itemrepo = new ItemRepository();
            ConsoleUtils = new ConsoleUtils();
        }
        private void DisplayAll()
        {
            string filterCmd = "All";

            List<ToDoItem> List = Itemrepo.GetItems(filterCmd);
            ConsoleUtils.PrintList(List);
        }
        private void DisplayFilter()
        {
            string filterCmd = "";
            string filter = ConsoleUtils.GetFilterType(filterCmd);

            switch (filter)
            {
                case "Complete":
                    List<ToDoItem> comList = Itemrepo.GetItems(filter);
                    ConsoleUtils.PrintList(comList);
                    break;

                case "Incomplete":
                    List<ToDoItem> incomList = Itemrepo.GetItems(filter);
                    ConsoleUtils.PrintList(incomList);
                    break;

                case "All":
                    List<ToDoItem> allList = Itemrepo.GetItems(filter);
                    ConsoleUtils.PrintList(allList);
                    break;

                default:
                    ConsoleUtils.BadFilter();
                    break;
            }
        }
        public void Start()
        {
            DisplayAll();
            string Command = ConsoleUtils.GetCommands();
            bool quit = false;
            bool update = false;
            string updateSelect = "";
            bool verifyID = true;
            bool verifyStat = true;

            while (!quit)
            {
                CommandValidate(Command);
                if (CommandValidate(Command) == false)
                {
                    ConsoleUtils.BadAction();
                }


                switch (Command)
                {
                    case "Add":
                        update = true;
                        string newDesc = ConsoleUtils.GetDescription(update);
                        ItemRepository.AddItem(newDesc);
                        DisplayAll();
                        break;

                    case "Delete":
                        do
                        {
                            int delItemID = ConsoleUtils.GetItemID(Command);
                            verifyID = Itemrepo.ItemIDVerify(delItemID);
                            if (verifyID == false)
                            {
                                DisplayAll();
                                ConsoleUtils.BadID();
                            }
                            else
                            {
                                Itemrepo.DeleteItem(delItemID);
                                DisplayAll();
                            }


                        } while (!verifyID);
                        DisplayAll();
                        break;

                    case "Update":
                        do
                        {
                            update = true;

                            int itemID = ConsoleUtils.GetItemID(Command);

                            verifyID = Itemrepo.ItemIDVerify(itemID);
                            if (verifyID == false)
                            {
                                ConsoleUtils.BadID();
                            }
                            else
                            {
                                updateSelect = ConsoleUtils.UpdateSelect(itemID);

                                if (updateSelect == "description")
                                {
                                    bool statUpdate = false;

                                    newDesc = ConsoleUtils.GetDescription(update);

                                    string newStat = ConsoleUtils.GetStatus(statUpdate);

                                    Itemrepo.UpdateItem(itemID, newDesc, newStat);
                                }
                                else if (updateSelect == "status")
                                {
                                    do
                                    {
                                        bool descUpdate = false;

                                        string newStat = ConsoleUtils.GetStatus(update);

                                        verifyStat = StatusValidate(newStat);
                                        if (verifyStat == false)
                                        {

                                            ConsoleUtils.BadStatus();
                                        }
                                        else
                                        {
                                            newDesc = ConsoleUtils.GetDescription(descUpdate);
                                            Itemrepo.UpdateItem(itemID, newDesc, newStat);
                                        }
                                    } while (verifyStat == false);
                                }
                                else
                                {
                                    ConsoleUtils.BadAction();
                                    verifyID = false;
                                }
                            }

                        } while (!verifyID);

                        DisplayAll();
                        break;

                    case "Filter":
                        DisplayFilter();
                        break;

                    case "Quit":
                        Itemrepo.QuitProtocol();
                        quit = true;
                        break;
                }
                if (quit == true)
                {
                    ConsoleUtils.QuitMessage();
                }
                else
                {
                    Command = ConsoleUtils.GetCommands();
                }

            }
        }
        public static bool CommandValidate(string command)
        {
            bool valid = false;
            if (command.ToLower() == "done" || command.ToLower() == "add" || command.ToLower() == "delete" || command.ToLower() == "update" ||
                command.ToLower() == "filter" || command.ToLower() == "quit")
            {
                valid = true;
            }
            return valid;
        }
        public static bool StatusValidate(string status)
        {
            bool valid = false;
            if (status.ToLower() == "complete" || status.ToLower() == "incomplete")
            {
                valid = true;
            }
            return valid;
        }



    }
}