using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Examples2.Data
{
    public class GenericFileRepository<T> where T : IEntity
    {
        private string _fileName;

        public GenericFileRepository(string fileName)
        {
            _fileName = fileName;
        }

        public T Get(int id)
        {
            var items = LoadEntities();
            return items.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return LoadEntities();
        }

        private IEnumerable<T> LoadEntities()
        {
            var savedJson = DependencyService.Get<IFile>().LoadText(_fileName);
            var desserializedItems = JsonConvert.DeserializeObject<IEnumerable<T>>(savedJson);
            return desserializedItems;
        }

        public void Save(T entity)
        {
            List<T> items;
            if (DependencyService.Get<IFile>().FileExists(_fileName))
            {
                items = LoadEntities().ToList();
                var item = items.FirstOrDefault(i => i.Id == entity.Id);
                if (item != null)
                {
                    items.Remove(item);
                }
            }
            else
            {
                items = new List<T>();
            }
            items.Add(entity);
            StoreEntities(items);
        }

        public void Save(IEnumerable<T> entities)
        {
            StoreEntities(entities);
        }

        private void StoreEntities(IEnumerable<T> items)
        {
            var serializedItems = JsonConvert.SerializeObject(items);

            DependencyService.Get<IFile>().SaveText(_fileName, serializedItems);
        }

        public void Delete(int id)
        {
            var items = LoadEntities().ToList();
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                items.Remove(item);
                StoreEntities(items);
            }
        }

        public void Delete(IEnumerable<T> entities)
        {
            var items = LoadEntities().ToList();
            var result = items.RemoveAll(i => entities.ToList().Any(e => e.Id == i.Id));
            if (result > 0)
            {
                StoreEntities(items);
            }

        }

    }
}
