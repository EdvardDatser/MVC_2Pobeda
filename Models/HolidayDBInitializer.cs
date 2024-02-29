using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kutse.Models
{
    public class HolidayDBInitializer : CreateDatabaseIfNotExists<HolidayContext>
    {
        protected override void Seed(HolidayContext HDdb)
        {
            base.Seed(HDdb);
        }
    }
}