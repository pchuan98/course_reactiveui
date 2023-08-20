using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Company.Core.Constant;
using Company.Core.Helper;
using Company.Core.Ioc;

// ReSharper disable once CheckNamespace
namespace Company.Core;

[ExposedService(LifeCycle.Singleton, typeof(ILangManager), AutoInitialize = true)]
public class LanguageManager : ILangManager
{
    private ResourceDictionary? Resource { get; set; }

    private string? Uri { get; set; }

    public LanguageManager()
    {
        Current = Language.Zh;
    }

    /// <inheritdoc/>
    public string this[string key]
    {
        get
        {
            if (Resource is not null && Resource.Contains(key))
                return Resource[key]!.ToString() ?? throw new NotSupportedException();

            return this[key];
        }
    }

    /// <inheritdoc/>
    public Language Current { get; private set; }

    /// <inheritdoc/>
    public void Set(Language language)
    {
        if (Uri is null)
        {
            var resources = Application.Current.Resources.MergedDictionaries;
            if (resources is null || resources.Count == 0) throw new NullReferenceException();
            var path = resources[0].Source.AbsolutePath;
            this.Uri = path.Remove(path.LastIndexOf("/", StringComparison.Ordinal));
        }


        var target = $"{Uri}/{language}.xaml";
        Resource = (ResourceDictionary)Application.LoadComponent(new Uri(target, UriKind.RelativeOrAbsolute));

        Application.Current.Resources.MergedDictionaries.RemoveAt(0);
        Application.Current.Resources.MergedDictionaries.Insert(0, Resource);

        Current = language;
    }
}