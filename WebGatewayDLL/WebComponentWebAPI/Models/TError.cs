using System;
using System.Collections.Generic;
using System.Text;

namespace WebComponentWebAPI.Models
{
    public enum TError
    {
        WCF_RunError = -503,
        WCF_ConnError = -502,
        Ser_ErrorPost = -402,
        Ser_EvenHaveData = -401,
        Pro_HaveNoDataParam3 = -302,
        Pro_HaveNoData = -301,
        User_NoPower = -201,
        User_NoLogin = -200,
        Post_NoChange = -105,
        Post_ToLargSize = -104,
        Post_ParamError = -103,
        Post_NoParam = -100,
        RunGood = 1
    }
}
