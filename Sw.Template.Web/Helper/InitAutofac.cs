using Autofac;
using Sw.Template.Web.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

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

            _Builder.RegisterType<SysUserWindow>().Named<UserControl>("数据采集");//注册方式二
            _Builder.RegisterType<SysMenuWindow>().Named<UserControl>("专测联调");//注册方式二
            _Builder.RegisterType<SysUserWindow>().Named<UserControl>("用户管理");//注册方式二
            _Builder.RegisterType<SysUserWindow>().Named<UserControl>("系统配置");//注册方式二
            _Builder.RegisterType<SysUserWindow>().Named<UserControl>("系统自检");//注册方式二
            _Builder.RegisterType<SysUserWindow>().Named<UserControl>("菜单管理");//注册方式二
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
