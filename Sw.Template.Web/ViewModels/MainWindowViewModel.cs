using Sw.Template.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sw.Template.Web.ViewModels
{
    public class MainWindowViewModel
    {
        private readonly ISysUserMenuService _sysUserMenuService;
        public MainWindowViewModel(ISysUserMenuService sysUserMenuService)
        {
            this._sysUserMenuService = sysUserMenuService;
        }
    }
}
