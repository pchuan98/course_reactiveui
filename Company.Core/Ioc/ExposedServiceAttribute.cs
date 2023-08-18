using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Ioc;

public enum LifeCycle
{
    /// <summary>
    /// 
    /// </summary>
    Singleton,

    /// <summary>
    /// 
    /// </summary>
    Transient,
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ExposedServiceAttribute : Attribute
{
    public LifeCycle LifeCycle { get; set; }

    public bool AutoInitialize { get; set; }

    public Type[] Types { get; set; }

    public ExposedServiceAttribute(LifeCycle life = Ioc.LifeCycle.Transient, params Type[] types)
    {
        Types = types;
        LifeCycle = life;
    }
}