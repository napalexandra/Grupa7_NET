﻿using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    //clase repository  sunt clase care implementeaza operatiile CRUD pe Baza de Date
    public class AnnouncementsRepository
    {
        private readonly ProgrammingClubDataContext _context;

        public AnnouncementsRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public DbSet<AnnouncementModel> GetAnnouncements()
        {
            return _context.Announcements;
        }

        public void Add(AnnouncementModel model)
        {
            model.IdAnnouncement = Guid.NewGuid();   //setam id-ul

            _context.Entry(model).State = EntityState.Added;  // adaugam modelul in layerul ORM (ProgrammingClubDataContext)
            _context.SaveChanges();  // commit to database
        }

        public AnnouncementModel GetAnnouncementById(Guid id)
        {
            AnnouncementModel announcement = _context.Announcements.FirstOrDefault(x => x.IdAnnouncement == id);
            return announcement;

        }

        public void Update(AnnouncementModel model)
        {
            _context.Announcements.Update(model);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            AnnouncementModel announcement = GetAnnouncementById(id);
            _context.Announcements.Remove(announcement);
            _context.SaveChanges();
        }
    }
}
