using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAWA.Models;

namespace PAWA.DAL
{
    public class FolderRepository : IFolderRepository
    {
        private List<Folder> folders = new List<Folder>();
        private int _nextId = 1;

        public FolderRepository()
        {
            Add(new Folder { UserID = 1, FolderName = "Folder1", InFolderID = 1 });
            Add(new Folder { UserID = 1, FolderName = "Folder2", InFolderID = 1 });
            Add(new Folder { UserID = 1, FolderName = "Folder3", InFolderID = 1 });
        }

        public IEnumerable<Folder> GetAll()
        {
            return folders;
        }

        public Folder Get(int id)
        {
            return folders.Find(p => p.FolderID == id);
        }

        public Folder Add(Folder item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.FolderID = _nextId++;
            item.CreateDateTime = DateTime.Now;
            folders.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            folders.RemoveAll(p => p.FolderID == id);
        }

        public bool Update(Folder item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = folders.FindIndex(p => p.FolderID == item.FolderID);
            if (index == -1)
            {
                return false;
            }
            folders.RemoveAt(index);
            folders.Add(item);
            return true;
        }
    }
}