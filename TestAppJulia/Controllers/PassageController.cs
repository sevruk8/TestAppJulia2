﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TestAppJulia.Services.PassageService;
using TestAppJulia.Services.PassageService.Abstractions.Models;

namespace TestAppJulia.Controllers
{
    [Route("Passages")]
    [ApiController]
    public class PassageController : ControllerBase
    {
        private readonly PassageService _passageService;
        public PassageController(PassageService passageService)
        {
            _passageService = passageService;
        }
        [HttpGet]
        public ActionResult<List<PassageShortModel>> GetPassages()
        {
            return _passageService.GetAllPassages();
        }
        [HttpGet("{id}")]
        public ActionResult<PassageModel> GetPassages([FromRoute]Guid id)
        {
            return _passageService.GetPassage(id);
        }
        [HttpPost]
        public ActionResult<Guid> CreatePassage([FromBody]PassageInfo passage)
        {
            return _passageService.CreatePassage(passage);
        }
        [HttpDelete]
        public void DeletePassage([FromQuery] Guid id)
        {
            _passageService.DeletePassage(id);
        }
        [HttpPut("{passageId}")]
        public void UpdatePassage([FromBody] PassageInfo passage, [FromRoute]Guid passageId)
        {
            _passageService.UpdatePassage(passageId, passage);
        }
    }   
    
}
