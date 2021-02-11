using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteStatistic.Infrastructure.EFCore.Migrations
{
    public partial class spGetTopSections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var script =
                @"
                    create procedure [dbo].[sp_GetTopSections] @Size int = 1
                    as
                    
                    select top (@Size) [ss].[Name], count([SiteSectionId]) as NumberOfVisits
                    from [VisitedSiteSection] as [vss]
                    inner join [SiteSection] as [ss]
                    	on [vss].[SiteSectionId] = [ss].[Id]
                    group by [vss].[SiteSectionId], [ss].[Name]
                    order by count([SiteSectionId]) desc		
                    
                    go
                ";

            migrationBuilder.Sql(script);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop procedure [dbo].[sp_GetTopSections]");
        }
    }
}
