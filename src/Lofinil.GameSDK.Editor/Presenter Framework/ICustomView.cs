using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Editor
{
    // 可定制视图接口 这种视图不需要有操作粒子，其特征是提供部分呈现和行为的定制，通常作为辅助视图或者配合其他视图使用
    // NOTE CustomView通常是一个空的面板或窗口，如果上面有内容于定制内容混合，则不利于抽象
    public interface ICustomView : IView
    {
        // 设置标题文字
        void SetTitle(String title);

        // 
        void AddInformation(String info);

        // YesNo Chooser 代表一种选择是否的呈现和记录（但是不表示行为，只是说该呈现可能被改变，且变更的结果被记录留给后续访问）
        void AddYesNoChooser(String name, String text, bool initChoice);

        bool GetYesOrNo(String checkBoxName);

        // Pick One Chooser 代表一种从多项目中选择一项的呈现和记录（同样不表示行为）
        void AddPickOneChooser(String name, String[] options, int initChoice);

        int GetPickedOne(String name);

        // TODO Pick One Chooser2 另一种PickOne（同样不表示行为，出现它纯粹是为了兼容旧代码中的ComboBox和RadioGroup）
        void AddPickOneChooser2(String name, String[] options, int initChoice);

        String GetPickedOne2(String name);

        // Commander 代表可以立即执行某项行为的呈现，当然通常是个按钮
        void AddCommander(String text, Action callBack);


        void AddInput(String name, String title, String initVal);

        String GetInput(String name);

        void AddPathInput(String name, String title, String initVal);

        String GetPathInput(String name);

        void AddFileInput(String name, String title, String initVal, String filter);

        String GetFileInput(String name);

        // NOTE [ICustomView的清理工作] 该函数必须被实体类实现，在客户代码需要取消对该视图的所有操作时执行清理
        // 在自定义控件面板中通常意味着要把客户添加的控件给删除掉
        void Clear();
    }
}
