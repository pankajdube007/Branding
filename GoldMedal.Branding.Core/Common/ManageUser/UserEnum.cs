using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserRole
/// </summary>
public static class UserEnum
{
    public enum UserRoleEnum
    {
        Admin,
        InternalUser,
        SalesExecutive,
        Accounts,
        Vendor,
        Dealer,
        Distributor
    }
    public enum UserInfoEnum
    {
        UserLogID,
        UserLogNameOrEmail,
        UserName,
        StateID,
        Status,
        IsSuccess,
        IsBlock,
        UniqueKey,
        LogNo,
        Usercat,
        FinalApproval,
        OrganizationShow,
        MissOther ,
        Designation,
         BrnchName ,
       StateName ,
        HomeBranchId ,
        OtherBranchid,
        PaymentLockDate ,
       SalesLockDate 
}
}