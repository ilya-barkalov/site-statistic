using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using SiteStatistic.Core.Data.Entities;
using SiteStatistic.Infrastructure.EFCore;

namespace SiteStatistic.Helpers
{
    public static class DataSeeder
    {
        public static void SeedAsync(SiteStatisticDbContext dbContext)
        {
            var users = new List<User>()
            {
                new User("Давид", "Орлов", "Львович"),
                new User("Дан", "Ершов", "Евгеньевич"),
                new User("Ян", "Лебедев", "Дмитриевич"),
                new User("Вера", "Кириллова", "Львовна"),
                new User("Гарри", "Карпов", "Андреевич"),
                new User("Нонна", "Орехова", "Андреевна"),
                new User("Захар", "Анисимов", "Андреевич"),
                new User("Георгий", "Князев", "Сергеевич"),
                new User("Аполлон", "Волков", "Сергеевич"),
                new User("Тамара", "Лихачёва", "Ивановна"),
                new User("Эмма", "Елисеева", "Владимировна"),
                new User("Ольга", "Мясникова", "Дмитриевна"),
                new User("Михаил", "Никифоров", "Борисович"),
                new User("Анатолий", "Маслов", "Алексеевич"),
                new User("Зинаида", "Осипова", "Максимовна"),
                new User("Василиса", "Мухина", "Евгеньевна"),
                new User("Иосиф", "Баркалов", "Владимирович"),
                new User("Спартак", "Ситников", "Алексеевич"),
                new User("Август", "Мельников", "Евгеньевич"),
                new User("Доминика", "Комиссарова", "Дмитриевна"),
            };
            dbContext.User.AddRange(users);

            var siteSections = new List<SiteSection>()
            {
                new SiteSection("Новости"),
                new SiteSection("Друзья"),
                new SiteSection("Сообщества"),
                new SiteSection("Фотографии"),
                new SiteSection("Музыка"),
                new SiteSection("Видео"),
                new SiteSection("Клипы"),
                new SiteSection("Игры"),
            };
            dbContext.SiteSections.AddRange(siteSections);

            // System.Text.Json on 3.1 can't deserialize protected, private etc.. access modifiers
            // https://docs.microsoft.com/ru-ru/dotnet/standard/serialization/system-text-json-migrate-from-newtonsoft-how-to?pivots=dotnet-core-3-1#public-and-non-public-fields

            var jsonAsString = File.ReadAllText("visited-data.json");
            var visitedSiteSectionsTmp = JsonSerializer.Deserialize<List<VisitedSiteSectionTmp>>(jsonAsString);
            var visitedSiteSections = visitedSiteSectionsTmp.Select(x => new VisitedSiteSection(x.UserId, x.SiteSectionId, x.VisitedDate));
            dbContext.VisitedSiteSections.AddRange(visitedSiteSections);

            dbContext.SaveChanges();
        }       
    }

    // System.Text.Json on 3.1 can't deserialize protected, private etc.. access modifiers
    // https://docs.microsoft.com/ru-ru/dotnet/standard/serialization/system-text-json-migrate-from-newtonsoft-how-to?pivots=dotnet-core-3-1#public-and-non-public-fields
    internal class VisitedSiteSectionTmp
    {
        public int UserId { get; set; }

        public int SiteSectionId { get; set; }

        public DateTime VisitedDate { get; set; }
    }
}

