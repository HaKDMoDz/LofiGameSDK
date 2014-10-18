using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Xml;
using System.IO;
using Lofinil.GameSDK.Engine;
using Lofinil.GameSDK.Editor.Module.View;

namespace Lofinil.GameSDK.Editor
{
    // TODO [隐藏生成XNB这一平台相关细节] XNAContentMaker私有化，由外层概念类（资源预处理管线之类的）包装
    // 创建临时XNA Content Project将原始素材编译成xnb
    public class XNAContentMaker
    {
        private static String sd_inFileName;
        private static String sd_inFileNameN;
        private static String sd_outFile;

        private static Process process;
        private static IWaitView waitView;

        public static void Test()
        {
        }

        public static void BuildSingleContent(ContentType resType, String inFile, String outFile)
        {
            FileInfo fi = new FileInfo(inFile);
            sd_inFileName = fi.Name;
            sd_inFileNameN = sd_inFileName.Replace(fi.Extension, "");
            sd_outFile = outFile;

            ////////
            // 拷贝源文件
            File.Copy(inFile, Path.Combine(EditorService.Instance.EditorDir, EditorStatics.MSBuild_InPath, sd_inFileName), true);

            ////////
            // 设置编译参数
            XmlDocument projDoc = new XmlDocument();
            projDoc.Load(Path.Combine(EditorService.Instance.EditorDir,EditorStatics.SContentBuilderPath));

            // Project.ItemGroup.Compile
            XmlElement compileEle = (XmlElement)projDoc.FirstChild.ChildNodes[2].ChildNodes[0];

            // Compile[Include] = inFile
            compileEle.Attributes[0].Value = sd_inFileName;

            // Compile.Name = filename
            compileEle.ChildNodes[0].InnerText = sd_inFileNameN;

            // Compile.Importer = ...
            compileEle.ChildNodes[1].InnerText = getImporterName(resType);

            // Compile.Processor = ...
            compileEle.ChildNodes[2].InnerText = getProcessorName(resType);

            projDoc.Save(Path.Combine(EditorService.Instance.EditorDir,EditorStatics.SContentBuilderPath));

            waitView = EditorService.Instance.QueryModule<ViewModule>().QueryView<IWaitView>();

            ////////
            // 执行编译
            process = new Process();
            process.StartInfo.FileName = EditorStatics.MSBuildExe;
            process.StartInfo.Arguments ="\"" + Path.Combine(EditorService.Instance.EditorDir, EditorStatics.SContentBuilderPath) + "\"";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;  // 表示进程标准输出不再同步读取，而是使用事件委托异步处理
            process.EnableRaisingEvents = true;
            process.Exited += delegate 
            {
                OnBuildFinish();
                waitView.TaskEndCallback(process.ExitCode);
            };
            process.OutputDataReceived += new DataReceivedEventHandler(buildDataReceived);

            waitView.SetTaskBeginCallback(beginBuild);
            waitView.StartTask();
        }

        private static void beginBuild()
        {
            process.Start();
            process.BeginOutputReadLine();
        }

        private static void buildDataReceived(Object sender, DataReceivedEventArgs e)
        {
            String line = e.Data;
            if (!String.IsNullOrEmpty(line))
                // 运行结束时会产生一个空行
                waitView.TextInfoCallback(line);
        }

        public static void OnBuildFinish()
        {
            ////////
            // 把编译输入拷贝入项目目录
            File.Copy(Path.Combine(EditorService.Instance.EditorDir, EditorStatics.MSBuild_OutPath, sd_inFileNameN + ".xnb"), sd_outFile, true);

            // ACHACK [删除MSBuild临时文件] 这里硬编码避免误删
            Directory.Delete(Path.Combine(EditorService.Instance.EditorDir,"MSBuild/obj"), true);
            Directory.Delete(Path.Combine(EditorService.Instance.EditorDir,"MSBuild/Out"), true);
            File.Delete(Path.Combine(EditorService.Instance.EditorDir,"MSBuild/cachefile--targetpath.txt"));
            File.Delete(Path.Combine(EditorService.Instance.EditorDir, "MSBuild", sd_inFileName));
        }

#region Helper Method
        private static String getImporterName(ContentType resType)
        {
            switch(resType)
            {
                case ContentType.Texture:
                    return "TextureImporter";
                case ContentType.Font:
                    return "FontImporter";
                case ContentType.Song:
                    return "SongImporter";
                case ContentType.Sound:
                    return "SoundEffectImporter";
            }
            return null;
        }

        private static String getProcessorName(ContentType resType)
        {
            switch(resType)
            {
                case ContentType.Texture:
                    return "TextureProcessor";
                case ContentType.Font:
                    return "FontProcessor";
                case ContentType.Song:
                    return "SongProcessor";
                case ContentType.Sound:
                    return "SoundProcessor";
            }
            return null;
        }
#endregion Helper Method
    }
}
