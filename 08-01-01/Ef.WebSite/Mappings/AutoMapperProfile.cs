using AutoMapper;
using Ef.WebSite.Models;
using EF.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ef.WebSite.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();
        }
    }
}