using System.Collections.Generic;

namespace Fitness.BL.Controller
{
    public abstract class BaseController
    {
        private readonly IDataManager DataManager = new SerializeDataManager();
        protected void Save<T>(List<T> item) where T: class
        {
            DataManager.Save(item);
        }

        protected List<T> Load<T>() where T : class => DataManager.Load<T>();
    }
}
