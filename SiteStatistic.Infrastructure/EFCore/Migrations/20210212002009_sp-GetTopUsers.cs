using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteStatistic.Infrastructure.EFCore.Migrations
{
    public partial class spGetTopUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			var script =
				@"
create procedure [dbo].[sp_GetTopUsers] @Size int = 10
as

;with cte as 
(
	-- Find most active user
	select top (@Size) [vss].[UserId], row_number() over(order by (select null)) as [OrderId]
	from [dbo].[VisitedSiteSection] as [vss]
	group by [vss].[UserId]
	order by count([vss].[UserId]) desc
),
second_cte as
(
	-- Get user activity (visite section count) by each site section
	select [vss].[UserId], [vss].[SiteSectionId], count([vss].[SiteSectionId]) as [sectioncount], [cte].[OrderId]
	from [dbo].[VisitedSiteSection] as [vss]
	inner join [cte]
		on [vss].[UserId] = [cte].[UserId]
	group by [vss].[UserId], [vss].[SiteSectionId], [cte].[orderId]
)
select 
	[second_cte].[orderId] as [OrderId],
	[user].[LastName] + ' ' + [user].[FirstName] + ' ' + [user].[MiddleName] as [FullName],
	[section].[Name] as [SectionName]
from second_cte
inner join [dbo].[User] as [user]
	on [second_cte].[UserId] = [user].[Id]
inner join [dbo].[SiteSection] as [section]
	on [second_cte].[SiteSectionId] = [section].[Id]
inner join 
(
	-- Find most visited section by each user
	select [orderId], max([sectioncount]) as [maximum]
	from second_cte
	group by [orderId]
) as [tmp]
	on [second_cte].[OrderId] = [tmp].[OrderId] and [second_cte].sectioncount = [tmp].[maximum]
order by [second_cte].[OrderId]

go
                ";

			migrationBuilder.Sql(script);
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("drop procedure [dbo].[sp_GetTopUsers]");
		}
    }
}
