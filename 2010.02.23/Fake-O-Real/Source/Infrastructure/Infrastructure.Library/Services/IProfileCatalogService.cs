﻿//----------------------------------------------------------------------------------------
// patterns & practices - Smart Client Software Factory - Guidance Package
//
// This file was generated by this guidance package as part of the solution template
//
// The IProfileCatalogService interface abstract the implementation to retrieve the 
// profile catalog from a given Url
// 
// For more information see: 
// ms-help://MS.VSCC.v90/MS.VSIPCC.v90/ms.practices.scsf.2008apr/SCSF/html/03-01-010-How_to_Create_Smart_Client_Solutions.htm
//
// Latest version of this Guidance Package: http://go.microsoft.com/fwlink/?LinkId=62182
//----------------------------------------------------------------------------------------

using System;
namespace FakeOReal.Infrastructure.Library.Services
{
    public interface IProfileCatalogService
    {
        string GetProfileCatalog(string[] roles);
        string Url { get; set; }
    }
}
