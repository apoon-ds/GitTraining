using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitTrainingApp.DAL;

namespace GitTrainingApp.Infrastructures
{
    class RepositoryFactory
    {
        private IMainRepository _MainRepository = null;

        public IMainRepository MainRepository
        {
            get
            {
                if (_MainRepository == null)
                    _MainRepository = new MainRepository();

                return _MainRepository;
            }
        }

        private static RepositoryFactory _Current = null;
        public static RepositoryFactory Current
        {
            get
            {
                if (_Current == null)
                    _Current = new RepositoryFactory();

                return _Current;
            }
        }
    }
}
