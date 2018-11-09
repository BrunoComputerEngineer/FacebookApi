using System;

namespace SeleniumTest.Enums
{
    [Flags]
    public enum UserTypeEnum
    {
        Insurer = 1,
        Admin = 2,
        SupplierOEM = 3,
        SupplierIAM = 4,
        SupplierOES = 5,
        BodyShop = 6,
        Expert = 7

    }
}
