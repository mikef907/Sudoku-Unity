using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

public class AddUniversalLink
{
    [PostProcessBuild]
    public static void ChangeXcodePlist(BuildTarget buildTarget, string pathToBuiltProject)
    {

        if (buildTarget == BuildTarget.iOS)
        {

            // Get plist
            string plistPath = pathToBuiltProject + "/Info.plist";
            PlistDocument plist = new PlistDocument();
            plist.ReadFromString(File.ReadAllText(plistPath));

            // Get root
            PlistElementDict rootDict = plist.root;

            // Change value of CFBundleURLTypes in Xcode plist
            var url = "CFBundleURLTypes";
            var arr = rootDict.CreateArray(url);
            var dict = arr.AddDict();
            dict.SetString("CFBundleURLName", "Seed");
            var schemesArr = dict.CreateArray("CFBundleURLSchemes");
            schemesArr.AddString("sudokuapp");
            dict.SetString("CFBundleTypeRole", "Editor");


            // Write to file
            File.WriteAllText(plistPath, plist.WriteToString());
        }
    }
}
