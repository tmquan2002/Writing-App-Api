using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingApp.Domain.DomainInterface
{
    public interface IUser
    {
        Guid Id { get; } 
        string? Fullname { get; }
        DateOnly DateOfBirth { get; }
        string? Nationality { get;}
        string? Gender { get; }
    }
}
