﻿using System.Web;
using System.Web.Optimization;

namespace CampReview.Api
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

        
        }
    }
}