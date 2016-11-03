namespace Monk.Utils
{
    public class FileHelper
    {
        public static bool CheckValidExt(string allType, string chkType)
        {
            allType = allType.Replace(",", "|");
            bool flag = false;
            string[] sArray = allType.Split('|');
            foreach (string temp in sArray)
            {
                if (temp.ToLower() == chkType.ToLower())
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
    }
}