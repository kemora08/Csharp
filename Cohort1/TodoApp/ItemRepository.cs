using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class ItemRepository
    {
        public static ItemContext context = new ItemContext();

        //ItemRepositoryConstructor
        public ItemRepository()
        {
            context.Database.EnsureCreated();
        }

        public static void AddItem(string description)
        {
            ToDoItem toDoItem = new ToDoItem(description);
            context.Add(toDoItem);
            context.SaveChanges();
        }
        public List<ToDoItem> GetItems(string filterCmd)
        {
            List<ToDoItem> List = new List<ToDoItem>().ToList();
            if(filterCmd == "All")
            {
                List = context.ToDoList.ToList();
            }
            else if (filterCmd == "Complete")
            {
                List = context.ToDoList.Where(item => item.Status == filterCmd).ToList();
            }
            else if (filterCmd == "Incomplete")
            {
                List = context.ToDoList.Where(item => item.Status == filterCmd).ToList();
            }
            return List;
        }
        public void UpdateItem(int itemID, string Description, string Status)
        {
            ToDoItem UpdatedToDoItem = context.ToDoList.Where(x => x.ID == itemID).FirstOrDefault();
            if(Description != "")
            {
                UpdatedToDoItem.Description = Description;
            }
            if(Status != "")
            {
                UpdatedToDoItem.Status = Status;
            }

            context.Update(UpdatedToDoItem);
            context.SaveChanges();
        }
        public void DeleteItem(int ItemID)
        {
            ToDoItem DeleteItem = context.ToDoList.Where(x => x.ID == ItemID).FirstOrDefault();
            context.Remove(DeleteItem);
            context.SaveChanges();
        }

        public void QuitProtocol()
        {
            context.SaveChanges();
        }

        public bool ItemIDVerify(int ItemID)
        {
            bool verifyID = context.ToDoList.Any(item => item.ID == ItemID);
            return verifyID;
        }
    }
}