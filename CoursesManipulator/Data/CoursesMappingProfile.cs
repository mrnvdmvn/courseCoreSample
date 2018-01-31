using AutoMapper;
using CoursesManipulator.Data.Entities;
using CoursesManipulator.Data.Enums;
using CoursesManipulator.ViewModels;
using System;

namespace CoursesManipulator.Data
{
    public class CoursesMappingProfile : Profile
    {
        public CoursesMappingProfile()
        {
            CreateMap<Course, CourseViewModel>()
               .ForMember(src => src.DayString, opt => opt.MapFrom(x => ((EDays)x.Day).ToString()));

            CreateMap<CourseViewModel, Course>()
             .ForMember(src => src.Day, opt => opt.MapFrom(x => (EDays)Enum.Parse(typeof(EDays), x.DayString)));
        }
       
    }
}
