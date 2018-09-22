﻿using Hayaa.BaseModel;
using Hayaa.BaseModel.Model;
using Hayaa.Common;
using Hayaa.CompanyWebSecurity.Client;
using Hayaa.RemoteConfig.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.RemoteConfigController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [UserAuthorityFilter]
    public class ComponentConfigController : ControllerBase
    {
        private IComponentConfigService ComponentConfigService = new ComponentConfigServer();
        [HttpPost]
        [EnableCors("any")]
        [Desc("GetPager", "获取ComponentConfig分页列表", "根据componentId获取ComponentConfig分页列表")]
        public TransactionResult<GridPager<ComponentConfig>> GetPager([FromForm] int page, [FromForm]  int size, [FromForm] int componentId)
        {
            TransactionResult<GridPager<ComponentConfig>> result = new TransactionResult<GridPager<ComponentConfig>>();
            var serviceResult = ComponentConfigService.GetPager(new BaseModel.GridPagerPamater<RemoteConfig.Service.ComponentConfigSearchPamater>()
            {
                Current = page,
                PageSize = size,
                SearchPamater = new RemoteConfig.Service.ComponentConfigSearchPamater() {  ComponentId=componentId}
            });
            if (serviceResult.ActionResult)
            {
                if (serviceResult.HavingData)
                    result.Data = serviceResult;
                else
                    result.Data = new GridPager<ComponentConfig>() { Data = new List<ComponentConfig>() };
            }
            else
            {
                result.Code = ErrorCode.NoData;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        [Desc("Get", "获取ComponentConfig", "根据主键获取数据")]
        public TransactionResult<ComponentConfig> Get([FromForm] int id)
        {
            TransactionResult<ComponentConfig> result = new TransactionResult<ComponentConfig>();
            var serviceResult = ComponentConfigService.Get(id);
            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = ErrorCode.NoData;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        [Desc("GetList", "获取ComponentConfig列表", "")]
        public TransactionResult<List<ComponentConfig>> GetList([FromForm] int appConfigId, [FromForm] int version)
        {
            TransactionResult<List<ComponentConfig>> result = new TransactionResult<List<ComponentConfig>>();
            var serviceResult = ComponentConfigService.GetComponentConfigList(appConfigId, version);
            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = ErrorCode.NoData;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        [Desc("Add", "添加ComponentConfig", "")]
        public TransactionResult<ComponentConfig> Add([FromForm] ComponentConfig info)
        {
            TransactionResult<ComponentConfig> result = new TransactionResult<ComponentConfig>();

            var serviceResult = ComponentConfigService.Create(info);

            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = ErrorCode.NoData;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        [Desc("Edit", "更新ComponentConfig", "根据主键更新数据")]
        public TransactionResult<Boolean> Edit([FromForm] ComponentConfig info)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = ComponentConfigService.UpdateByID(info);
            if (serviceResult.ActionResult)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = ErrorCode.NoData;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        [Desc("Delete", "删除ComponentConfig", "根据主键删除数据")]
        public TransactionResult<Boolean> Delete([FromForm] int id)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = ComponentConfigService.DeleteByID(new List<int>() { id });
            if (serviceResult.ActionResult)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = ErrorCode.NoData;
                result.Message = "暂无数据";
            }
            return result;
        }
        
    }
}
