﻿
using URFU_Scheduling.Domain.Entities;
using URFU_Scheduling.Domain.Interfaces;
using URFU_Scheduling.Domain.Repositories;

namespace URFU_Scheduling.Domain.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly ScheduleRepository _scheduleRepo;
        private readonly IEventSerivce _eventService;
        private readonly ITagService _tagService;


        public ScheduleService(
            ScheduleRepository scheduleRepository,
            IEventSerivce eventService,
            ITagService tagService)
        { 
            _scheduleRepo = scheduleRepository;
            _eventService = eventService;
            _tagService = tagService;
        }

        public bool Export(IScheduleExportProvider provider, Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public Schedule Import(IScheduleImportProvider provider)
        {
            throw new NotImplementedException();
        }

        public bool Update(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public Schedule? Create(object? data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public Schedule? Get(object? data)
        {
            throw new NotImplementedException();
        }
    }
}