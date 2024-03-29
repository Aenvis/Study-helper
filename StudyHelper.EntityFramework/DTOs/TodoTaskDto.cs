﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.EntityFramework.DTOs
{
    public class TodoTaskDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
