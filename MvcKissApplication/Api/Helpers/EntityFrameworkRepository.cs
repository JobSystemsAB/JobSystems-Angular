using MvcKissApplication.Database.Helpers;
using MvcKissApplication.Database.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcKissApplication.Api.Helpers
{
    public class EntityFrameworkRepository : IRepository
    {
        private EntityFrameworkContext db = new EntityFrameworkContext();

        public EntityFrameworkRepository()
        { 
        }

        #region ADMINISTRATOR

        public IEnumerable<Administrator> getAllAdministrators()
        {
            return db.administrators;
        }

        public Administrator getAdministrator(int id)
        {
            return db.administrators.FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<Administrator> getAdministrators(int[] ids)
        {
            return db.administrators.Where(x => ids.Contains(x.id));
        }

        public Administrator getAdministrator(string email, string password)
        {
            return db.administrators.FirstOrDefault(x => x.emailAddress.ToLower() == email.ToLower() && x.password == password);
        }

        public Administrator createAdministrator(Administrator model)
        {
            db.administrators.Add(model);
            db.SaveChanges();
            return model;
        }

        public void deleteAdministrator(int id)
        {
            var model = db.administrators.Find(id);
            db.administrators.Remove(model);
            db.SaveChanges();
        }

        #endregion

        #region CATEGORY

        public IEnumerable<Category> getAllCategories()
        {
            return db.categories;
        }

        public Category getCategory(int id)
        {
            return db.categories.FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<Category> getCategories(int[] ids)
        {
            return db.categories.Where(x => ids.Contains(x.id));
        }

        public Category createCategory(Category model)
        {
            db.categories.Add(model);
            db.SaveChanges();
            return model;
        }

        public void deleteCategory(int id)
        {
            var model = db.categories.Find(id);
            db.categories.Remove(model);
            db.SaveChanges();
        }

        #endregion

        #region CATEGORY INPUT

        public IEnumerable<CategoryInput> getAllCategoryInputs()
        {
            return db.categoryInputs;
        }

        public CategoryInput getCategoryInput(int id)
        {
            return db.categoryInputs.FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<CategoryInput> getCategoryInputs(int[] ids)
        {
            return db.categoryInputs.Where(x => ids.Contains(x.id));
        }

        public CategoryInput createCategoryInput(CategoryInput model)
        {
            db.categoryInputs.Add(model);
            db.SaveChanges();
            return model;
        }

        public void deleteCategoryInput(int id)
        {
            var model = db.categoryInputs.Find(id);
            db.categoryInputs.Remove(model);
            db.SaveChanges();
        }

        #endregion

        #region COMPANY CUSTOMER

        public IEnumerable<CompanyCustomer> getAllCompanyCustomers()
        {
            return db.companyCustomers;
        }

        public CompanyCustomer getCompanyCustomer(int id)
        {
            return db.companyCustomers.FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<CompanyCustomer> getCompanyCustomers(int[] ids)
        {
            return db.companyCustomers.Where(x => ids.Contains(x.id));
        }

        public CompanyCustomer createCompanyCustomer(CompanyCustomer model)
        {
            db.companyCustomers.Add(model);
            db.SaveChanges();
            return model;
        }

        public void deleteCompanyCustomer(int id)
        {
            var model = db.companyCustomers.Find(id);
            db.companyCustomers.Remove(model);
            db.SaveChanges();
        }

        #endregion

        #region CUSTOMER
        
        public IEnumerable<Customer> getAllCustomers()
        {
            List<Customer> result = new List<Customer>();
            result.AddRange(db.privateCustomers);
            result.AddRange(db.companyCustomers);
            return result;
        }

        public Customer getCustomer(int id)
        {
            Customer result = db.privateCustomers.FirstOrDefault(x => x.id == id);
            if (result == null)
            {
                result = db.companyCustomers.FirstOrDefault(x => x.id == id);
            }

            return result;          
        }

        public Customer getCustomer(string email, string password)
        {
            return db.customers.FirstOrDefault(x => x.emailAddress.ToLower() == email.ToLower() && x.password == password);
        }

        public IEnumerable<Customer> getCustomers(int[] ids)
        {
            return db.customers.Where(x => ids.Contains(x.id));
        }

        #endregion

        #region EMPLOYEE

        public IEnumerable<Employee> getAllEmployees()
        {
            return db.employees;
        }

        public Employee getEmployee(int id)
        {
            return db.employees.FirstOrDefault(x => x.id == id);
        }

        public Employee getEmployee(string email, string password)
        {
            return db.employees.FirstOrDefault(x => x.emailAddress.ToLower() == email.ToLower() && x.password == password);
        }

        public IEnumerable<Employee> getEmployees(int[] ids)
        {
            return db.employees.Where(x => ids.Contains(x.id));
        }

        public Employee createEmployee(Employee model)
        {
            db.employees.Add(model);
            db.SaveChanges();
            return model;
        }

        public void deleteEmployee(int id)
        {
            var model = db.employees.Find(id);
            db.employees.Remove(model);
            db.SaveChanges();
        }

        #endregion

        #region MISSION

        public IEnumerable<Mission> getAllMissions()
        {
            return db.missions;
        }

        public Mission getMission(int id)
        {
            return db.missions.FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<Mission> getMissions(int[] ids)
        {
            return db.missions.Where(x => ids.Contains(x.id));
        }

        public Mission createMission(Mission model)
        {
            db.missions.Add(model);
            db.SaveChanges();
            return model;
        }

        public void deleteMission(int id)
        {
            var model = db.missions.Find(id);
            db.missions.Remove(model);
            db.SaveChanges();
        }

        #endregion

        #region PRIVATE CUSTOMER

        public IEnumerable<PrivateCustomer> getAllPrivateCustomers()
        {
            return db.privateCustomers;
        }

        public PrivateCustomer getPrivateCustomer(int id)
        {
            return db.privateCustomers.FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<PrivateCustomer> getPrivateCustomers(int[] ids)
        {
            return db.privateCustomers.Where(x => ids.Contains(x.id));
        }

        public PrivateCustomer createPrivateCustomer(PrivateCustomer model)
        {
            db.privateCustomers.Add(model);
            db.SaveChanges();
            return model;
        }

        public void deletePrivateCustomer(int id)
        {
            var model = db.privateCustomers.Find(id);
            db.privateCustomers.Remove(model);
            db.SaveChanges();
        }

        #endregion

        #region TEXT

        public IEnumerable<Text> getAllTexts()
        {
            return db.texts;
        }

        public Text getText(int id)
        {
            return db.texts.FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<Text> getText(int[] ids)
        {
            return db.texts.Where(x => ids.Contains(x.id));
        }

        public IEnumerable<Text> getText(string controllerName, string language)
        {
            return db.texts.Where(x => x.controllerName == controllerName && x.language == language);
        }

        public Text createText(Text model)
        {
            db.texts.Add(model);
            db.SaveChanges();
            return model;
        }

        public void deleteText(int id)
        {
            var model = db.texts.Find(id);
            db.texts.Remove(model);
            db.SaveChanges();
        }

        #endregion

        #region WORK SHIFT

        public IEnumerable<WorkShift> getAllWorkShifts()
        {
            return db.workShifts;
        }

        public WorkShift getWorkShift(int id)
        {
            return db.workShifts.FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<WorkShift> getWorkShifts(int[] ids)
        {
            return db.workShifts.Where(x => ids.Contains(x.id));
        }

        public WorkShift createWorkShift(WorkShift model)
        {
            db.workShifts.Add(model);
            db.SaveChanges();
            return model;
        }

        public void deleteWorkShift(int id)
        {
            var model = db.workShifts.Find(id);
            db.workShifts.Remove(model);
            db.SaveChanges();
        }

        #endregion

        public void update(IEntity model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void dispose()
        {
            db.Dispose();
        }

    }
}