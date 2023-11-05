﻿using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Project.Dtos.Marks;
using Data;
using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Project.Dtos.Students;
using Project.Utils;
using System.ComponentModel.DataAnnotations;
using Data.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {

        private readonly IDataAccessLayerService dal;
        public MarksController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Assigns a note to a student
        /// </summary>
        /// <param name="markToCreate"></param>
        /// <returns></returns>

        [HttpPost]
        public void AddMark([FromBody] MarkToCreateDto mark) =>
        dal.AddMark(mark.Grade, mark.StudentId, mark.SubjectId);

        /// <summary>
        /// Gets all notes of a student
        /// </summary>
        /// <param name="markToCreate"></param>
        /// <returns></returns>
        /// 

        [HttpGet("ByStudent/{studentId}")]
        public IEnumerable<Mark> GetAllMarks([FromRoute] int studentId) =>
          dal.GetAllMarks(studentId).ToList();


        /// <summary>
        /// Gets notes of a student for a specific course
        /// </summary>
        /// <param name="markToCreate"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IEnumerable<Mark> GetMarkbySubject(int studentId, int subjectId)=>
            dal.GetMarkBySubject(studentId, subjectId);
    }
}
