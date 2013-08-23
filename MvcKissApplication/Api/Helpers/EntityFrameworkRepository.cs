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

        //public void updateAdministrator(Administrator model)
        //{
        //    db.Entry(model).State = EntityState.Modified;
        //    db.SaveChanges();
        //}

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

        //public void updateCategory(Category model)
        //{
        //    db.Entry(model).State = EntityState.Modified;
        //    db.SaveChanges();
        //}

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

        //public void updateCategoryInput(CategoryInput model)
        //{
        //    db.Entry(model).State = EntityState.Modified;
        //    db.SaveChanges();
        //}

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

        //public void updateCompanyCustomer(CompanyCustomer model)
        //{
        //    db.Entry(model).State = EntityState.Modified;
        //    db.SaveChanges();
        //}

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

        //public void updateEmployee(Employee model)
        //{
        //    db.Entry(model).State = EntityState.Modified;
        //    db.SaveChanges();
        //}

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

        //public void updateMission(Mission model)
        //{
        //    db.Entry(model).State = EntityState.Modified;
        //    db.SaveChanges();
        //}

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

        //public void updatePrivateCustomer(PrivateCustomer model)
        //{
        //    db.Entry(model).State = EntityState.Modified;
        //    db.SaveChanges();
        //}

        #endregion

        #region SUBCATEGORY

        public IEnumerable<Subcategory> getAllSubcategories()
        {
            return db.subcategories;
        }

        public Subcategory getSubcategory(int id)
        {
            return db.subcategories.FirstOrDefault(x => x.id == id);
        }

        public Subcategory createSubcategory(Subcategory model)
        {
            db.subcategories.Add(model);
            db.SaveChanges();
            return model;
        }

        public void deleteSubcategory(int id)
        {
            var model = db.subcategories.Find(id);
            db.subcategories.Remove(model);
            db.SaveChanges();
        }

        //public void updateSubcategory(Subcategory model)
        //{
        //    db.Entry(model).State = EntityState.Modified;
        //    db.SaveChanges();
        //}

        #endregion

        #region SUBSÙBCATEGORY

        public IEnumerable<Subsubcategory> getAllSubsubcategories()
        {
            return db.subsubcategories;
        }

        public Subsubcategory getSubsubcategory(int id)
        {
            return db.subsubcategories.FirstOrDefault(x => x.id == id);
        }

        public Subsubcategory createSubsubcategory(Subsubcategory model)
        {
            db.subsubcategories.Add(model);
            db.SaveChanges();
            return model;
        }

        public void deleteSubsubcategory(int id)
        {
            var model = db.subsubcategories.Find(id);
            db.subsubcategories.Remove(model);
            db.SaveChanges();
        }

        //public void updateSubsubcategory(Subsubcategory model)
        //{
        //    db.Entry(model).State = EntityState.Modified;
        //    db.SaveChanges();
        //}

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

        //public void updateWorkShift(WorkShift model)
        //{
        //    db.Entry(model).State = EntityState.Modified;
        //    db.SaveChanges();
        //}

        #endregion

        public void update(IEntity model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}