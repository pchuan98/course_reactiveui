using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using Company.Application.Share.Events;
using Company.Application.Share.Models;
using Company.Core.Ioc;
using HandyControl.Controls;
using Prism.Commands;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Company.Application.Launch.ViewModels;

public class LaunchViewModel : ReactiveObject
{
    [Reactive]
    public LaunchModel LaunchModel { get; set; } = new();

    public DelegateCommand CheckCommand => new DelegateCommand(() =>
    {
        MessageBox.Show("开始执行测试");

        var timer = new DispatcherTimer(priority: DispatcherPriority.Render)
        {
            Interval = TimeSpan.FromMilliseconds(10),
        };

        timer.Tick += (s, e) =>
        {
            if (LaunchModel.Index < LaunchModel.Count) LaunchModel.Index++;
            else
            {
                timer.Stop();
                Thread.Sleep(2);

                PrismProvider.Aggregator.GetEvent<LaunchSuccessEvent>().Publish(LaunchModel);
            }

            // publish
            LaunchModel.Info = $"Current load : {LaunchModel.Index}/{LaunchModel.Count}";
        };

        timer.Start();
    });
}