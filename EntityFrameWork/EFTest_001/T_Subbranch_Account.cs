//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFTest_001
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Subbranch_Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Permission { get; set; }
        public Nullable<int> OwnerId { get; set; }
        public string AreaLv1 { get; set; }
        public string AreaLv2 { get; set; }
        public Nullable<System.DateTime> LastLoginTime { get; set; }
        public Nullable<int> LoginCount { get; set; }
        public Nullable<short> Status { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string Remark { get; set; }
        public string EnterpriseId { get; set; }
        public string ExtInfo { get; set; }
        public Nullable<int> FrontAccountId { get; set; }
        public int RoleId { get; set; }
        public Nullable<int> ShowMark { get; set; }
        public string TransferShowMark { get; set; }
        public Nullable<int> AccountType { get; set; }
        public string LogoUrl { get; set; }
    }
}