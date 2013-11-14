using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWA.Models
{
    public interface IFolderRepository
    {
        IEnumerable<Folder> GetAll();
        Folder Get(int id);
        Folder Add(Folder item);
        void Remove(int id);
        bool Update(Folder item);
    }
}
