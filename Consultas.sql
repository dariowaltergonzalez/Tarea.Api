SELECT TOP (1000) [Id]
      ,[Nombre]
      ,[EstaCompleta]
  FROM [TareaSimple].[dbo].[TareaItems]

  insert into TareaItems (Nombre, EstaCompleta) values ('Pintar el techo', 0)
  insert into TareaItems (Nombre, EstaCompleta) values ('Revestir la escalera', 0)