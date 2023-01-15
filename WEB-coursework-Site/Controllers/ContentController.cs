﻿using Microsoft.AspNetCore.Mvc;
using WEB_coursework_Site.DB.Context;
using WEB_coursework_Site.DB.Entities;

namespace WEB_coursework_Site.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContentController : ControllerBase
    {
        private readonly ISiteDbContextHelper _siteDbContextHelper;

        public ContentController(ISiteDbContextHelper siteDbContextHelper)
        {
            _siteDbContextHelper = siteDbContextHelper ?? throw new NullReferenceException("ISiteDbContextHelper is null at PostController.cs");
        }

        [HttpGet]
        public async Task<PostWithDateModel> GetAsync(DateTimeOffset startTime)
        {
            var result = _siteDbContextHelper.GetPostsAsync(startTime);
            try
            {
                return await result;
            }
            catch
            {
                return new PostWithDateModel();
            }
        }
    }
}