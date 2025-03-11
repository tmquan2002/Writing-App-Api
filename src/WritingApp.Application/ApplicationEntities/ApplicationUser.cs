using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingApp.Domain.DomainInterface;
using WritingApp.Domain.Entities;

namespace WritingApp.Application.ApplicationEntities
{
    public class ApplicationUser : IdentityUser, IUser
    {
        public string? Fullname { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public string? Gender { get; set; }
        public List<Writing>? Writings { get; set; } = new List<Writing>();

        string IUser.Id => Id;
        //string IUser.Fullname => Fullname ?? "";
        //DateOnly IUser.DateOfBirth => DateOfBirth; 
        //string IUser.Nationality => Nationality ?? "";
        //string IUser.Gender => Gender ?? "";
    }
}
