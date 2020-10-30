using MahApps.Metro.Controls;
using Sw.Template.Web.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sw.Template.Web.View
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : UserControl
    {
        private HamburgerMenuGlyphItem selectedMenuItem;
        /// <summary>
        /// 选中的菜单项目
        /// </summary>
        public HamburgerMenuGlyphItem SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set { selectedMenuItem = value; ChangeContent(); }
        }
        /// <summary>
        /// 当前显示的模块
        /// </summary>
        public virtual UserControl SelectedView { get; set; }

        /// <summary>
        /// 所有菜单项目
        /// </summary>
        public virtual ObservableCollection<HamburgerMenuGlyphItem> HamburgerMenuItems { get; set; }

        public virtual bool IsEnableNavi { get; set; } = true;
        public MainView()
        {
            // 获取当前用户权限模块
            HamburgerMenuItems = GetUserPower();

            InitializeComponent();
        }
        /// <summary>
        /// 接收导航栏是否可用消息
        /// </summary>
        /// <param name="obj"></param>
        private void OnReceiveNavi(bool obj)
        {
            IsEnableNavi = obj;
        }
        private void ChangeContent()
        {
            SelectedView = InitAutofac.GetFromFac<UserControl>(SelectedMenuItem.Label);
        }
        ObservableCollection<HamburgerMenuGlyphItem> GetUserPower()
        {
            ObservableCollection<HamburgerMenuGlyphItem> items = new ObservableCollection<HamburgerMenuGlyphItem>();

            //var powerlist = AppDbContext.DBContext.Power.Where(x => x.UserId == SystemInfo.CurrentUser.Id).ToList();
            //foreach (var item in powerlist)
            //{
            //    var module = AppDbContext.DBContext.Module.Where(x => x.Id == item.ModuleId).FirstOrDefault();
            //    HamburgerMenuGlyphItem it = new HamburgerMenuGlyphItem()
            //    {
            //        Tag = module.Icon,
            //        Label = module.ModuleName
            //    };
            //    items.Add(it);
            //}

            return items;
        }
    }
}
