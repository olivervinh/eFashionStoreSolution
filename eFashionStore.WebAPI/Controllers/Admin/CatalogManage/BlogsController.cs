using eFashionStore.Data.Repositories.Catalogs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.WebAPI.Controllers.Admin.CatalogManage
{
    [Route("api/admin/catalog/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
          private IBlogService _blogService;
        public BlogsController(IBlogService blogService)
        {
            this._blogService = blogService;
        }
    }
}
