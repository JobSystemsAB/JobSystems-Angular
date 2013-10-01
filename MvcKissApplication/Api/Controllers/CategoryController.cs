using MvcKissApplication.Api.Helpers;
using MvcKissApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.OutputCache;

namespace MvcKissApplication.Api.ViewModels
{
    public class CategoryController : ApiController
    {

        #region CONSTRUCTORS

        private IRepository repo;

        public CategoryController()
            : this(new EntityFrameworkRepository())
        {

        }

        public CategoryController(IRepository repo)
        {
            this.repo = repo;
        }

        #endregion CONSTRUCTORS

        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public IEnumerable<CategoryView> Get()
        {
            var models = repo.getAllCategories();
            var views = CategoryView.getViews(models);
            return views;
        }

        [HttpGet]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public Node GetTree()
        {
            var categories = repo.getAllCategories();
            var categoryViews = CategoryView.getViews(categories);

            Node tree = new Node();
            constructTree(tree, categoryViews.ToArray(), null);

            return tree;
        }

        private void constructTree(Node node, ICollection<CategoryView> categories, int? currentId)
        {
            var children = categories.Where(c => c.parentId == currentId);
            foreach (var child in children)
            {
                Node leaf = new Node();
                leaf.data = child;
                node.children.Add(leaf);
                constructTree(leaf, categories, child.id);
            }
        }

        [HttpGet]
        [ActionName("DefaultAction")]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage Get(int id)
        {
            var model = repo.getCategory(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var view = new CategoryView(model);
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
        }

        [HttpGet]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage Missions(int id)
        {
            var model = repo.getCategory(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var missions = model.missions;
                var views = MissionView.getViews(missions);
                return Request.CreateResponse(HttpStatusCode.OK, views);
            }
        }

        [HttpGet]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage Employees(int id)
        {
            var model = repo.getCategory(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var employees = model.employees;
                var views = EmployeeView.getViews(employees);
                return Request.CreateResponse(HttpStatusCode.OK, views);
            }
        }

        [HttpGet]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage Children(int id)
        {
            var model = repo.getCategory(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var subcategories = model.children;
                var views = CategoryView.getViews(subcategories);
                return Request.CreateResponse(HttpStatusCode.OK, views);
            }
        }

        [HttpGet]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage CategoryInputs(int id)
        {
            var model = repo.getCategory(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var categoryInputs = model.categoryInputs;
                var views = CategoryInputView.getViews(categoryInputs);
                return Request.CreateResponse(HttpStatusCode.OK, views);
            }
        }

        [HttpPost]
        [ActionName("DefaultAction")]
        public HttpResponseMessage Post(CategoryView view)
        {
            var model = view.getModel();
            model = repo.createCategory(model);
            view = new CategoryView(model);

            var response = Request.CreateResponse<CategoryView>(HttpStatusCode.Created, view);
            string uri = Url.Route(null, new { id = view.id });
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        // POST api/category/SaveCategories
        [HttpPost]
        public HttpResponseMessage SaveCategories(IEnumerable<CategoryView> views)
        {
            foreach (var view in views)
            {
                var original = repo.getCategory(view.id);
                if (original.name != view.name)
                {
                    original.name = view.name;
                    repo.update(original);
                }
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        [ActionName("DefaultAction")]
        public void Put(int id, CategoryView view)
        {
            view.id = id;
            var model = view.getModel();
            repo.update(model);
        }
    }
}
