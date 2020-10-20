using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    class DbDataManager : IDataManager
    {
        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }

        public List<T> Load<T>() where T : class
        {
            using (var db = new FitnessContext())
            {
                return db.Set<T>().Where(x => true).ToList();
            }
        }
    }
}
