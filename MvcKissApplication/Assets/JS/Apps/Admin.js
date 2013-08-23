(function() {
  window.app = angular.module('AdminApp', ['services', 'ui.bootstrap', 'ui.date', 'google-maps']);

  window.app.config(function($routeProvider, $locationProvider) {
    $routeProvider.when('/login', {
      templateUrl: '/Assets/JS/Partials/Admin/Login.html',
      controller: 'LoginController'
    });
    $routeProvider.when('/administrator', {
      templateUrl: '/Assets/JS/Partials/Admin/Administrator.html',
      controller: 'AdministratorController'
    });
    $routeProvider.when('/administrator/:administratorId', {
      templateUrl: '/Assets/JS/Partials/Admin/AdministratorView.html',
      controller: 'AdministratorViewController'
    });
    $routeProvider.when('/category', {
      templateUrl: '/Assets/JS/Partials/Admin/Category.html',
      controller: 'AdministratorController'
    });
    $routeProvider.when('/category/:categoryId', {
      templateUrl: '/Assets/JS/Partials/Admin/CategoryView.html',
      controller: 'CategoryViewController'
    });
    $routeProvider.when('/customer', {
      templateUrl: '/Assets/JS/Partials/Admin/Customer.html',
      controller: 'CustomerController'
    });
    $routeProvider.when('/customer/0', {
      templateUrl: '/Assets/JS/Partials/Admin/CustomerView.html',
      controller: 'CustomerViewController'
    });
    $routeProvider.when('/customer/:customerType/:customerId', {
      templateUrl: '/Assets/JS/Partials/Admin/CustomerView.html',
      controller: 'CustomerViewController'
    });
    $routeProvider.when('/employee', {
      templateUrl: '/Assets/JS/Partials/Admin/Employee.html',
      controller: 'EmployeeController'
    });
    $routeProvider.when('/employee/:employeeId', {
      templateUrl: '/Assets/JS/Partials/Admin/EmployeeView.html',
      controller: 'EmployeeViewController'
    });
    $routeProvider.when('/mission', {
      templateUrl: '/Assets/JS/Partials/Admin/Mission.html',
      controller: 'MissionController'
    });
    $routeProvider.when('/mission/:missionId', {
      templateUrl: '/Assets/JS/Partials/Admin/MissionView.html',
      controller: 'MissionViewController'
    });
    $routeProvider.when('/subcategory', {
      templateUrl: '/Assets/JS/Partials/Admin/Subcategory.html',
      controller: 'SubcategoryController'
    });
    $routeProvider.when('/subcategory/:subcategoryId', {
      templateUrl: '/Assets/JS/Partials/Admin/SubcategoryView.html',
      controller: 'SubcategoryViewController'
    });
    $routeProvider.when('/subsubcategory', {
      templateUrl: '/Assets/JS/Partials/Admin/Subsubcategory.html',
      controller: 'SubsubcategoryController'
    });
    $routeProvider.when('/subsubcategory/:subsubcategoryId', {
      templateUrl: '/Assets/JS/Partials/Admin/SubsubcategoryView.html',
      controller: 'SubsubcategoryViewController'
    });
    return $routeProvider.otherwise({
      redirectTo: '/login'
    });
  });

}).call(this);
