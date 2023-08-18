using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Application.Share.Models;
using Prism.Events;

namespace Company.Application.Share.Events;

public class LaunchSuccessEvent : PubSubEvent<LaunchModel>
{
}