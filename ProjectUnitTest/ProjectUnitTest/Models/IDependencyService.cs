using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectUnitTest.Models
{
    public interface IDependencyService
    {
        T Get<T>() where T : class;
    }
}
