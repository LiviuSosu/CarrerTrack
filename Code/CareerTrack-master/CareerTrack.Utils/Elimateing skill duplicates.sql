/*
CURRENT SKILL 15 SQL
*/


SELECT  [Id],[Name] FROM [CareerTrack].[dbo].[Skill] 
	--where name not in (insert name of the skill here) 
	order by Name

  select * from SkillJobAnnouncement where Skill_Id=207 -- 

  INSERT INTO [dbo].[SkillJobAnnouncement]
           ([Skill_Id]
           ,[JobAnnouncement_Id])
     VALUES
           (15 --skill ID
           ,125 -- job announcement id
		   )

DELETE FROM [dbo].[SkillJobAnnouncement]
      WHERE Skill_Id =207 and JobAnnouncement_Id=125

	  delete from Skill where Id=207