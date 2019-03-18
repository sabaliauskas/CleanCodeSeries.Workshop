﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeSeries.Workshop.Lesson2.Functions.EventHandlers
{
    class QuotationImportWindow
    {
        private Quotation quotation;

        public QuotationImportWindow(Quotation quotation)
        {
            this.quotation = quotation;
        }

        public void ButtonImportQuotation_OnClick(object sender, EventArgs e)
        {
            var importer = new QuotationImporter(new DBContext());
            Logger.Log("Import started");
            importer.context.StartTransaction();
            try
            {
                importer.ValidateHeader(quotation);
                importer.ValidateLines(quotation);
                importer.CreateHeader(quotation);
                importer.CreateLines(quotation);
                importer.context.CommitTransaction();
            }
            catch(Exception e)
            {
                importer.context.Rollback();
            }
            Logger.Log("Import done");
        }
    }
}
