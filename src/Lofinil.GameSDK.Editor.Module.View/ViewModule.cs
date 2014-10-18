using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Editor.Module.View
{
    public class ViewModule : EditorModule
    {
        private List<IView> viewList;

        private List<IRegion> regionList;

        public ViewModule()
        {
            viewList = new List<IView>();
            regionList = new List<IRegion>();
        }

        // 注册的视图受到此管理器管理，并可以被共享
        public void RegisterView(IView view, bool isInstance)
        {
            viewList.Add(view);
        }

        // 将视图注册进Region
        public void RegisterView(IView view, String regionName)
        {
            throw new NotImplementedException("RegisterView to Region需要实际视图模块实现");
        }

        public void RegisterRegine(IRegion region)
        {
            regionList.Add(region);
        }

        // NOTE [QueryView] 允许客户代码（操作模式等）从编辑器呈现器集中请求一个视图进行操作。
        // viewType参数表示所请求视图的类型，args是附加参数在存在多个同类视图是用于确定是哪一个
        public T QueryView<T>(Object[] args) where T : IView
        {
            foreach (IView view in viewList)
            {
                if (view is T)
                {
                    return (T)view;
                }
            }
            return default(T);
        }

        public T QueryView<T>()
        {
            foreach (IView view in viewList)
            {
                if (view is T)
                {
                    return (T)view;
                }
            }
            return default(T);
        }

        public IRegion QueryRegion(String regionName)
        {
            return regionList.Find(r => r.Name == regionName);
        }

        public void ShowRegion(String regionName)
        {
            throw new NotImplementedException("ShowRegion需要实际视图模块实现");
        }
    }
}
