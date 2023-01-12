using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NumberPresenter.Core;

namespace NumberPresenter.Terminal
{
    public class DependencyContainer
    {
        private ServiceProvider _serviceProvider;

        public DependencyContainer()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IRomanService, RomanService>();
            services.AddSingleton<INumberService, NumberService>();
            _serviceProvider = services.BuildServiceProvider();
        }

        public T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
