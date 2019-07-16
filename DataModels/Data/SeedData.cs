using System;
using System.Linq;


namespace DataModels
{
    public static class SeedData
    {
        public static void Initialize(dbContext context)
        {
            

            if (context.mBoards.Any())
            {
                return;
            }

            context.mBoards.AddRange(
                new mBoard
                {
                    Name = "아무게",
                    WriterID = "Anyone",
                    Password = "0000",
                    Title = "테스트 입니다.",
                    Content = string.Empty,
                    Category = Category.공지,
                    PosteDate = DateTime.Now,
                    PostIp = "::1",//Microsoft.AspNetCore.Http.HttpContext.Connection.RemoteIpAddress.ToString(),
                    ReadCount = 3,
                    ReplySubCount = 2,
                    Encoing = Encoding.TEXT,
                    ModifyDate = null,
                    ModifyIp = null,
                    Ref = 1,
                    Step=0,
                    RefOrder=0,
                    DelFlag=false
                },
               
                new mBoard
                {
                    Name = "누구게",
                    WriterID = "Anyone",
                    Password = "0000",
                    Title = "연습용 입니다.",
                    Content = string.Empty,
                    Category = Category.공지,
                    PosteDate = DateTime.Now,
                    PostIp = "::1",
                    ReadCount = 0,
                    ReplySubCount = 0,
                    Encoing = Encoding.TEXT,
                    ModifyDate = null,
                    ModifyIp = null,
                    Ref = 2,
                    Step = 0,
                    RefOrder = 0,
                    DelFlag = false

                },

                 new mBoard
                 {
                     Name = "답변자 1",
                     WriterID = "Replyer",
                     Password = "0000",
                     Title = "답변 테스트용  1 입니다.",
                     Content = string.Empty,
                     Category = Category.공지,
                     PosteDate = DateTime.Now,
                     PostIp = "::1",
                     ReadCount = 0,
                     ReplySubCount = 2,
                     Encoing = Encoding.TEXT,
                     ModifyDate = null,
                     ModifyIp = null,
                     Ref = 1,
                     Step = 1,
                     RefOrder = 1,
                     DelFlag = false

                 },

                 new mBoard
                 {
                     Name = "답변자 2",
                     WriterID = "Replyer",
                     Password = "0000",
                     Title = "답변 테스트용 2 입니다.",
                     Content = string.Empty,
                     Category = Category.공지,
                     PosteDate = DateTime.Now,
                     PostIp = "::1",
                     ReadCount = 0,
                     ReplySubCount = 0,
                     Encoing = Encoding.TEXT,
                     ModifyDate = null,
                     ModifyIp = null,
                     Ref = 1,
                     Step = 1,
                     RefOrder = 5,
                     DelFlag = false

                 },

                 new mBoard
                 {
                     Name = "답변자 1-1",
                     WriterID = "Replyer",
                     Password = "0000",
                     Title = "답변 1-1 테스트용 입니다.",
                     Content = string.Empty,
                     Category = Category.공지,
                     PosteDate = DateTime.Now,
                     PostIp = "::1",
                     ReadCount = 0,
                     ReplySubCount = 1,
                     Encoing = Encoding.TEXT,
                     ModifyDate = null,
                     ModifyIp = null,
                     Ref = 1,
                     Step = 2,
                     RefOrder = 2,
                     DelFlag = false

                 },
                new mBoard
                {
                    Name = "답변자1-2",
                    WriterID = "Replyer",
                    Password = "0000",
                    Title = "답변 테스트용 1-2 입니다.",
                    Content = string.Empty,
                    Category = Category.공지,
                    PosteDate = DateTime.Now,
                    PostIp = "::1",
                    ReadCount = 0,
                    ReplySubCount = 0,
                    Encoing = Encoding.TEXT,
                    ModifyDate = null,
                    ModifyIp = null,
                    Ref = 1,
                    Step = 2,
                    RefOrder = 4,
                    DelFlag = false

                },

                 new mBoard
                 {
                     Name = "답변자 1-1-1",
                     WriterID = "Replyer",
                     Password = "0000",
                     Title = "답변 1-1-1 테스트용 입니다.",
                     Content = string.Empty,
                     Category = Category.공지,
                     PosteDate = DateTime.Now,
                     PostIp = "::1",
                     ReadCount = 0,
                     Encoing = Encoding.TEXT,
                     ModifyDate = null,
                     ModifyIp = null,
                     Ref = 1,
                     Step = 3,
                     RefOrder = 3,
                     DelFlag = false

                 }
            );
            context.SaveChanges();


            
        }
    }
}
