using MvcKissApplication.Database.Helpers;
using MvcKissApplication.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKissApplication.Api.Helpers
{
    public interface IRepository
    {
        #region ADMINISTRATOR

        IEnumerable<Administrator> getAllAdministrators();

        Administrator getAdministrator(int id);

        Administrator getAdministrator(string email, string password);

        Administrator createAdministrator(Administrator model);

        void deleteAdministrator(int id);

        //void updateAdministrator(Administrator model);

        #endregion

        #region CATEGORY

        IEnumerable<Category> getAllCategories();

        Category getCategory(int id);

        Category createCategory(Category model);

        void deleteCategory(int id);

        //void updateCategory(Category model);

        #endregion

        #region CATEGORY INPUT

        IEnumerable<CategoryInput> getAllCategoryInputs();

        CategoryInput getCategoryInput(int id);

        CategoryInput createCategoryInput(CategoryInput model);

        void deleteCategoryInput(int id);

        //void updateCategoryInput(CategoryInput model);

        #endregion

        #region COMPANY CUSTOMER

        IEnumerable<CompanyCustomer> getAllCompanyCustomers();

        CompanyCustomer getCompanyCustomer(int id);

        CompanyCustomer createCompanyCustomer(CompanyCustomer model);

        void deleteCompanyCustomer(int id);

        //void updateCompanyCustomer(CompanyCustomer model);

        #endregion

        #region CUSTOMER

        IEnumerable<Customer> getAllCustomers();

        Customer getCustomer(int id);

        Customer getCustomer(string email, string password);

        #endregion

        #region EMPLOYEE

        IEnumerable<Employee> getAllEmployees();

        Employee getEmployee(int id);

        Employee getEmployee(string email, string password);

        Employee createEmployee(Employee model);

        void deleteEmployee(int id);

        //void updateEmployee(Employee model);

        #endregion

        #region MISSION

        IEnumerable<Mission> getAllMissions();

        Mission getMission(int id);

        Mission createMission(Mission model);

        void deleteMission(int id);

        //void updateMission(Mission model);

        #endregion

        #region PRIVATE CUSTOMER

        IEnumerable<PrivateCustomer> getAllPrivateCustomers();

        PrivateCustomer getPrivateCustomer(int id);

        PrivateCustomer createPrivateCustomer(PrivateCustomer model);

        void deletePrivateCustomer(int id);

        //void updatePrivateCustomer(PrivateCustomer model);

        #endregion

        #region SUBCATEGORY

        IEnumerable<Subcategory> getAllSubcategories();

        Subcategory getSubcategory(int id);

        Subcategory createSubcategory(Subcategory model);

        void deleteSubcategory(int id);

        //void updateSubcategory(Subcategory model);

        #endregion

        #region SUBSUBCATEGORY

        IEnumerable<Subsubcategory> getAllSubsubcategories();

        Subsubcategory getSubsubcategory(int id);

        Subsubcategory createSubsubcategory(Subsubcategory model);

        void deleteSubsubcategory(int id);

        //void updateSubsubcategory(Subsubcategory model);

        #endregion

        #region WORK SHIFT

        IEnumerable<WorkShift> getAllWorkShifts();

        WorkShift getWorkShift(int id);

        WorkShift createWorkShift(WorkShift model);

        void deleteWorkShift(int id);

        //void updateWorkShift(WorkShift model);

        #endregion

        #region GLOBAL

        void update(IEntity model);

        #endregion

    }
}