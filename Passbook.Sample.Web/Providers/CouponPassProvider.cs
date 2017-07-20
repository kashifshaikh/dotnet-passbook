﻿using System;
using System.Collections.Generic;
using Passbook.Generator;
using Passbook.Generator.Configuration;
using Passbook.Generator.Fields;

namespace Passbook.Sample.Web
{
    public class CouponPassProvider : Passbook.Web.PassProvider
    {
        public override string PassTypeIdentifier
        {
            get { return "pass.com.angus-systems.vs"; }
        }

        public override bool IsUpdating()
        {
            return false;
        }

        public override Passbook.Generator.PassGeneratorRequest GetPass(string serialNumber)
        {
            PassGeneratorRequest request = new PassGeneratorRequest();

            request.PassTypeIdentifier = PassTypeIdentifier;
            request.SerialNumber = Guid.NewGuid().ToString("D");

            TemplateModel parameters = new TemplateModel();

            request.AddBarcode(BarcodeType.PKBarcodeFormatPDF417, "01927847623423234234", "UTF-8", "01927847623423234234");

            request.LoadTemplate("Coupon", parameters);

            return request;
        }
    }
}

