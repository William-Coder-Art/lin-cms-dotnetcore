﻿using LinCms.Web.Data;
using LinCms.Web.Models.Logs;
using LinCms.Web.Repositories;
using LinCms.Zero.Data;
using LinCms.Zero.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using LinCms.Web.Services;
using LinCms.Web.Services.Interfaces;
using LinCms.Zero.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace LinCms.Web.Controllers
{
    [Route("cms/log")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        /// <summary>
        /// 查询日志记录的用户
        /// </summary>
        /// <returns></returns>
        [HttpGet("users")]
        [LinCmsAuthorize("查询日志记录的用户", "日志")]
        public List<string> GetLoggedUsers([FromQuery]PageDto pageDto)
        {
            return _logService.GetLoggedUsers(pageDto);
        }

        /// <summary>
        /// 查询日志信息（分页）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [LinCmsAuthorize("查询所有日志", "日志")]
        public PagedResultDto<LinLog> GetLogs([FromQuery]LogSearchDto searchDto)
        {
            return _logService.GetLogUsers(searchDto);
        }

        /// <summary>
        /// 搜索日志信息（分页）
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [HttpGet("search")]
        [LinCmsAuthorize("搜索日志", "日志")]
        public PagedResultDto<LinLog> SearchLogs([FromQuery]LogSearchDto searchDto)
        {
            return _logService.GetLogUsers(searchDto);
        }

    }
}
