using Portal.ViewModels;
using System.Collections.Generic;

namespace Portal.Services
{
    public interface ICollectionService
    {
        public List<CollectionViewModel> GetAllCollections();
        public List<SidebarViewModel> GetAllSidebarLinks();
        public CollectionViewModel GetCollectionsById(int id);
    }
}
