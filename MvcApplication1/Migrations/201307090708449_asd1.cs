namespace MvcApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Administrators", name: "emailAddress", newName: "email_address");
            RenameColumn(table: "dbo.Customers", name: "emailAddress", newName: "email_address");
            RenameColumn(table: "dbo.Customers", name: "phoneNumber", newName: "phone_number");
            RenameColumn(table: "dbo.Customers", name: "organisationNumber", newName: "organisation_number");
            RenameColumn(table: "dbo.Customers", name: "companyName", newName: "company_name");
            RenameColumn(table: "dbo.Customers", name: "firstName", newName: "first_name");
            RenameColumn(table: "dbo.Customers", name: "lastName", newName: "last_name");
            RenameColumn(table: "dbo.Customers", name: "personalNumber", newName: "personal_number");
            RenameColumn(table: "dbo.Customers", name: "propertyName", newName: "property_name");
            RenameColumn(table: "dbo.Employees", name: "infoText", newName: "info_text");
            RenameColumn(table: "dbo.Employees", name: "firstName", newName: "first_name");
            RenameColumn(table: "dbo.Employees", name: "lastName", newName: "last_name");
            RenameColumn(table: "dbo.Employees", name: "emailAddress", newName: "email_address");
            RenameColumn(table: "dbo.Employees", name: "mobilePhoneNumber", newName: "mobile_phone_number");
            RenameColumn(table: "dbo.Employees", name: "phoneNumber", newName: "phone_number");
            RenameColumn(table: "dbo.Employees", name: "bankName", newName: "bank_name");
            RenameColumn(table: "dbo.Employees", name: "bankClearingNumber", newName: "bank_clreaing_number");
            RenameColumn(table: "dbo.Employees", name: "bankAccountNumber", newName: "bank_account_number");
            RenameColumn(table: "dbo.Employees", name: "hourSalary", newName: "hour_salary");
            RenameColumn(table: "dbo.Employees", name: "personalNumber", newName: "personal_number");
            RenameColumn(table: "dbo.Employees", name: "sendSms", newName: "send_sms");
            RenameColumn(table: "dbo.Employees", name: "sendMail", newName: "send_mail");
            AddColumn("dbo.Missions", "start_date", c => c.DateTime());
            AddColumn("dbo.Missions", "start_time", c => c.DateTime());
            DropColumn("dbo.Missions", "startDateAndTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Missions", "startDateAndTime", c => c.DateTime());
            DropColumn("dbo.Missions", "start_time");
            DropColumn("dbo.Missions", "start_date");
            RenameColumn(table: "dbo.Employees", name: "send_mail", newName: "sendMail");
            RenameColumn(table: "dbo.Employees", name: "send_sms", newName: "sendSms");
            RenameColumn(table: "dbo.Employees", name: "personal_number", newName: "personalNumber");
            RenameColumn(table: "dbo.Employees", name: "hour_salary", newName: "hourSalary");
            RenameColumn(table: "dbo.Employees", name: "bank_account_number", newName: "bankAccountNumber");
            RenameColumn(table: "dbo.Employees", name: "bank_clreaing_number", newName: "bankClearingNumber");
            RenameColumn(table: "dbo.Employees", name: "bank_name", newName: "bankName");
            RenameColumn(table: "dbo.Employees", name: "phone_number", newName: "phoneNumber");
            RenameColumn(table: "dbo.Employees", name: "mobile_phone_number", newName: "mobilePhoneNumber");
            RenameColumn(table: "dbo.Employees", name: "email_address", newName: "emailAddress");
            RenameColumn(table: "dbo.Employees", name: "last_name", newName: "lastName");
            RenameColumn(table: "dbo.Employees", name: "first_name", newName: "firstName");
            RenameColumn(table: "dbo.Employees", name: "info_text", newName: "infoText");
            RenameColumn(table: "dbo.Customers", name: "property_name", newName: "propertyName");
            RenameColumn(table: "dbo.Customers", name: "personal_number", newName: "personalNumber");
            RenameColumn(table: "dbo.Customers", name: "last_name", newName: "lastName");
            RenameColumn(table: "dbo.Customers", name: "first_name", newName: "firstName");
            RenameColumn(table: "dbo.Customers", name: "company_name", newName: "companyName");
            RenameColumn(table: "dbo.Customers", name: "organisation_number", newName: "organisationNumber");
            RenameColumn(table: "dbo.Customers", name: "phone_number", newName: "phoneNumber");
            RenameColumn(table: "dbo.Customers", name: "email_address", newName: "emailAddress");
            RenameColumn(table: "dbo.Administrators", name: "email_address", newName: "emailAddress");
        }
    }
}
