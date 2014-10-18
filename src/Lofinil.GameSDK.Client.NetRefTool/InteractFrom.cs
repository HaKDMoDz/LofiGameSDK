using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Lofinil.GameSDK.Engine;

namespace NetRefTool
{
    public partial class InteractFrom : Form
    {
        public Type Type;

        public MethodInfo[] MethodInfos;

        public List<MethodInfo> AccessorMInfos = new List<MethodInfo>();

        public List<MethodInfo> ActionMInfos = new List<MethodInfo>();

        public List<MethodInfo> CheckerMInfos = new List<MethodInfo>();

        public InteractFrom()
        {
            InitializeComponent();
        }

        private void InteractFrom_Shown(object sender, EventArgs e)
        {
            lbClassName.Text = Type.Name;

            if (NETFramework.IsModule(Type))
                rbModule.Checked = true;
            else if (NETFramework.IsComponent(Type, true))
                rbComponent.Checked = true;

            if (NETFramework.IsPrefab(Type))
                cbPrefab.Checked = true;

            MethodInfos = Type.GetMethods();

            foreach(MethodInfo info in MethodInfos)
            {
                InteractAttribute ia = NETFramework.GetInteractAttribute(info);
                if(ia != null)
                {
                    if(NETFramework.IsAccessor(info))
                        AccessorMInfos.Add(info);
                    else if(NETFramework.IsAction(info))
                        ActionMInfos.Add(info);
                    else if(NETFramework.IsChecker(info))
                        CheckerMInfos.Add(info);
                }
            }

            RefreshAccessor();
            RefreshAction();
            RefreshChecker();
        }

        private void RefreshAccessor()
        {
            dgvAccessor.Rows.Clear();
            if(AccessorMInfos.Count > 0)
                dgvAccessor.Rows.Add(AccessorMInfos.Count);

            for (int i = 0; i < AccessorMInfos.Count; i++)
            {
                MethodInfo mInfo = AccessorMInfos[i];
                InteractAttribute ia = NETFramework.GetInteractAttribute(mInfo);
                DataGridViewRow row = dgvAccessor.Rows[i];
                (row.Cells[0] as DataGridViewTextBoxCell).Value = ia.ExternDesc;
                (row.Cells[1] as DataGridViewButtonCell).Value = ia.ReturnDesc;
                (row.Cells[1] as DataGridViewButtonCell).Tag = mInfo.ReturnType;


                // NOTE DataGridView无法动态控制Cell数量，若使用这个控件，就要限制参数数量
                ParameterInfo[] parInfos = mInfo.GetParameters();
                // int addSelCnt = parInfos.Count() - row.Cells.Count + 2; // 2 for Desc and Return
                // row.Cells.AddRange(new DataGridViewButtonCell[addSelCnt]);

                for (int j = 0; j < parInfos.Count(); j++)
                {
                    (row.Cells[j+2] as DataGridViewButtonCell).Tag = parInfos[j].ParameterType;
                    if (ia.ParamsDesc.Count() > j)
                        (row.Cells[j + 2] as DataGridViewButtonCell).Value = ia.ParamsDesc[j];
                    else
                        (row.Cells[j + 2] as DataGridViewButtonCell).Value = parInfos[j].Name;
                }

            }
        }

        private void RefreshAction()
        {
            dgvAction.Rows.Clear();
            if (ActionMInfos.Count > 0)
                dgvAction.Rows.Add(ActionMInfos.Count);

            for (int i = 0; i < ActionMInfos.Count; i++)
            {
                MethodInfo mInfo = ActionMInfos[i];
                InteractAttribute ia = NETFramework.GetInteractAttribute(mInfo);
                DataGridViewRow row = dgvAction.Rows[i];
                (row.Cells[0] as DataGridViewTextBoxCell).Value = ia.ExternDesc;

                ParameterInfo[] parInfos = mInfo.GetParameters();
                for (int j = 0; j < parInfos.Count(); j++)
                {
                    (row.Cells[j + 1] as DataGridViewButtonCell).Tag = parInfos[j].ParameterType;
                    if (ia.ParamsDesc.Count() > j)
                        (row.Cells[j + 1] as DataGridViewButtonCell).Value = ia.ParamsDesc[j];
                    else
                        (row.Cells[j + 1] as DataGridViewButtonCell).Value = parInfos[j].Name;
                }
            }
        }

        private void RefreshChecker()
        {
            dgvChecker.Rows.Clear();
            if (CheckerMInfos.Count > 0)
                dgvChecker.Rows.Add(CheckerMInfos.Count);

            for (int i = 0; i < CheckerMInfos.Count; i++)
            {
                MethodInfo mInfo = CheckerMInfos[i];
                InteractAttribute ia = NETFramework.GetInteractAttribute(mInfo);
                DataGridViewRow row = dgvChecker.Rows[i];
                (row.Cells[0] as DataGridViewTextBoxCell).Value = ia.ExternDesc;

                ParameterInfo[] parInfos = mInfo.GetParameters();
                for (int j = 0; j < parInfos.Count(); j++)
                {
                    (row.Cells[j + 1] as DataGridViewButtonCell).Tag = parInfos[j].ParameterType;
                    if (ia.ParamsDesc.Count() > j)
                        (row.Cells[j + 1] as DataGridViewButtonCell).Value = ia.ParamsDesc[j];
                    else
                        (row.Cells[j + 1] as DataGridViewButtonCell).Value = parInfos[j].Name;
                }
            }
        }

        private void RefreshInteract()
        {
            //Type t = Type;
            //lsbInteract.Items.Clear();
            //lsbDesc.Items.Clear();

            //if (t == null)
            //    return;

            //int showType = 0;
            //if (rbAction.Checked)
            //    showType = 0;       // Action
            //else if (rbAccess.Checked)
            //    showType = 1;       // Access
            //else if (rbCheck.Checked)
            //    showType = 2;       // Check

            //bool showAll = cbAll.Checked;

            //MethodInfo[] mInfos = t.GetMethods();
            //foreach (MethodInfo info in mInfos)
            //{
            //    switch (showType)
            //    {
            //        case 0:
            //            if (!IsAction(info)) continue;
            //            break;
            //        case 1:
            //            if (!IsAccessor(info)) continue;
            //            break;
            //        case 2:
            //            if (!IsChecker(info)) continue;
            //            break;
            //    }

            //    lsbInteract.Items.Add(info);
            //    lsbDesc.Items.Add(GetInteractDect(info));
            //}
        }
    }
}
