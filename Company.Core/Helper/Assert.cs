using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Helper;

public static class Assert
{
    public static void NotNull<T>(T obj, [CallerMemberName] string memberName = "")
    {

        if (obj != null) return;

        var msg = "";

        throw new NullReferenceException(msg);
    }
}