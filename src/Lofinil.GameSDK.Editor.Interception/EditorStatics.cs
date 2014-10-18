using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Editor
{
    public static class EditorStatics
    {
        // 杂项
        public static string ProjectExt = ".lfp";
        public static string StageExt = ".stage";
        public static string ResourceSetExt = ".lfrs";
        public static string ProfileExt = ".lfprof";

        // 绝对路径
        public static string MSBuildExe = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"; 

        // 编辑器相对目录
        public static string SContentBuilderPath = "MSBuild/SContentBuilder.contentproj";
        public static string MSBuild_InPath = "MSBuild";
        public static string MSBuild_OutPath = "MSBuild/Out";

        public static String BuildPath = "Bin";

        // 项目相对目录
        // public static string CommonResImpSetPath = "Config/ResImpSet.xml";   // 已转入项目文件
    }
}
