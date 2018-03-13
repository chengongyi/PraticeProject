using System;

namespace PostSharpExample
{
    public class CoreBusiness
    {
        [Logging(BusinessName="预定房间")]
        public static void Describe(string memberName, string roomNumber)
        {
            System.Windows.Forms.MessageBox.Show(String.Format("尊敬的会员{0}，恭喜您预定房间{1}成功！", memberName, roomNumber), "提示");
        }
    }
}
