﻿using Autofac;
using Sw.Template.Web.View;
using Sw.Template.Web.View.Dialog;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Sw.Template.Web.Helper
{
    public class InitAutofac
    {
        static ContainerBuilder _Builder;//申明容器

        static IContainer _container;//申明一个字段这个字段用来对接容器
        static IContainer Container //将对接的内容传输入这个属性！
        {
            get
            {
                if (_container == null)
                {
                    _container = _Builder.Build();
                }
                return _container;
            }
        }

        public static void InitAutofacs()//初始化方法
        {
            _Builder = new ContainerBuilder();//实例化

            _Builder.RegisterType<SysUserWindow>().Named<UserControl>("员工管理");
            _Builder.RegisterType<SysMenuWindow>().Named<UserControl>("菜单管理");
            _Builder.RegisterType<SysRoleWindow>().Named<UserControl>("角色管理");

            _Builder.RegisterType<SysUserDialog>().Named<Window>("员工管理弹窗");
        }

        public static T GetFromFac<T>(string name)//定义一个方法在外部调用，使得可以调用已注入的服务
        {
            try
            {
                if (Container == null)
                {
                    InitAutofacs();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("IOC实例化出错!" + ex.Message);
            }

            return Container.ResolveNamed<T>(name);
        }
    }
}
