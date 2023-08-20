using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Core.Constant;

// ReSharper disable once CheckNamespace
namespace Company.Core;

public interface ILangManager
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    string this[string key] { get; }

    /// <summary>
    /// 当前语言类型
    /// </summary>
    public Language Current => throw new Exception();

    /// <summary>
    /// 设置语言类型
    /// </summary>
    /// <param name="language"></param>
    void Set(Language language);
}