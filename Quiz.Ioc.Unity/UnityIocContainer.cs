using Microsoft.Practices.Unity.Configuration;
using Quiz.Common.Entities.IoC;
using System;
using Unity;

namespace Quiz.IoC.Unity
{
    public class UnityIocContainer : IIocContainer
    {
        private IUnityContainer _unityContainer;

        public UnityIocContainer() {

            _unityContainer = new UnityContainer();
            _unityContainer.LoadConfiguration();

        }

        internal UnityIocContainer(IUnityContainer unityContainer) {

            if (unityContainer == null)
                throw new ArgumentNullException("unityContainer");
            _unityContainer = unityContainer;
        }

        public IIocContainer CreateChildContainer()
        {
            return new UnityIocContainer(_unityContainer.CreateChildContainer());
        }

        public object GetInternalContainer()
        {
            return _unityContainer;
        }

        public T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }

        public T Resolve<T>(string name)
        {
            return _unityContainer.Resolve<T>(name);
        }
    }
}