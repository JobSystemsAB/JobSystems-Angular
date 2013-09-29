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

        IEnumerable<Administrator> getAdministrators(int[] ids);

        Administrator getAdministrator(int id);

        Administrator getAdministrator(string email, string password);

        Administrator createAdministrator(Administrator model);

        Administrator deleteAdministrator(int id);

        #endregion

        #region CATEGORY

        IEnumerable<Category> getAllCategories();

        IEnumerable<Category> getCategories(int[] ids);

        Category getCategory(int id);

        Category createCategory(Category model);

        Category deleteCategory(int id);

        #endregion

        #region CATEGORY INPUT

        IEnumerable<CategoryInput> getAllCategoryInputs();

        IEnumerable<CategoryInput> getCategoryInputs(int[] ids);

        CategoryInput getCategoryInput(int id);

        CategoryInput createCategoryInput(CategoryInput model);

        CategoryInput deleteCategoryInput(int id);

        #endregion

        #region COMPANY CUSTOMER

        IEnumerable<CompanyCustomer> getAllCompanyCustomers();

        IEnumerable<CompanyCustomer> getCompanyCustomers(int[] ids);

        CompanyCustomer getCompanyCustomer(int id);

        CompanyCustomer createCompanyCustomer(CompanyCustomer model);

        CompanyCustomer deleteCompanyCustomer(int id);

        #endregion

        #region CUSTOMER

        IEnumerable<Customer> getAllCustomers();

        IEnumerable<Customer> getCustomers(int[] ids);

        Customer getCustomer(int id);

        Customer getCustomer(string email, string password);

        #endregion

        #region EMPLOYEE

        IEnumerable<Employee> getAllEmployees();

        IEnumerable<Employee> getEmployees(int[] ids);

        Employee getEmployee(int id);

        Employee getEmployee(string email, string password);

        Employee createEmployee(Employee model);

        Employee deleteEmployee(int id);

        #endregion

        #region MISSION

        IEnumerable<Mission> getAllMissions();

        IEnumerable<Mission> getMissions(int[] ids);

        Mission getMission(int id);

        Mission createMission(Mission model);

        Mission deleteMission(int id);

        #endregion

        #region PRIVATE CUSTOMER

        IEnumerable<PrivateCustomer> getAllPrivateCustomers();

        IEnumerable<PrivateCustomer> getPrivateCustomers(int[] ids);

        PrivateCustomer getPrivateCustomer(int id);

        PrivateCustomer createPrivateCustomer(PrivateCustomer model);

        PrivateCustomer deletePrivateCustomer(int id);

        #endregion

        #region TESTIMONIAL

        IEnumerable<Testimonial> getAllTestimonials();

        IEnumerable<Testimonial> getTestimonials(string language);

        IEnumerable<Testimonial> getTestimonials(int[] ids);

        Testimonial getTestimonial(int id);

        Testimonial createTestimonial(Testimonial model);

        Testimonial deleteTestimonial(int id);

        #endregion

        #region TEXT

        IEnumerable<Text> getAllTexts();

        IEnumerable<Text> getTexts(int[] ids);

        IEnumerable<Text> getTexts(string language);

        IEnumerable<Text> getTexts(string controllerName, string language);

        Text getText(int id);

        Text createText(Text model);

        Text deleteText(int id);

        #endregion

        #region TEXT MESSAGE

        IEnumerable<TextMessage> getAllTextMessages();

        IEnumerable<TextMessage> getTextMessages(int[] ids);

        TextMessage getTextMessage(int id);

        TextMessage getTextMessage(string id);

        TextMessage createTextMessage(TextMessage model);

        TextMessage deleteTextMessage(int id);

        #endregion


        #region WORK SHIFT

        IEnumerable<WorkShift> getAllWorkShifts();

        IEnumerable<WorkShift> getWorkShifts(int[] ids);

        WorkShift getWorkShift(int id);

        WorkShift createWorkShift(WorkShift model);

        WorkShift deleteWorkShift(int id);

        #endregion

        #region GLOBAL

        void update(IEntity model);

        void dispose();

        #endregion

    }
}