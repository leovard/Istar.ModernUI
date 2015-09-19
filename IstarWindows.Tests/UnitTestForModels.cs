using System;
using System.Linq;
using IstarWindows.Models;
using NUnit.Framework;

namespace IstarWindows.Tests
{
    [TestFixture]
    public class UnitTestForModels
    {
        [Test]
        public void A_DataBaseCreatingTest()
        {
            using (var context = new IstarContext())
            {
                if (context.Database.Exists())
                {
                    context.Database.Delete();
                }
                context.Database.Create();
                Assert.That(context.Database.CompatibleWithModel(true),
                    "Тест на создание базы данных на основе модели пройден.");
            }
        }

        [Test]
        public void B_AddingNewDataIntoDataBase()
        {
            using (var logic = new IstarLogic())
            {
                logic.AddNewJob(new Job
                {
                    Jobdate = DateTime.Today,
                    Jobtitle = "Тестовая задача",
                    Jobtext = "Задача создана для проверки теста.",
                    Ismonthly = true,
                    Iscomplete = true
                });
                Assert.That(logic.GetJobs().First().Iscomplete = true, "Тест на добавление сущности пройден.");
            }

        }

        [Test]
        public void C_GettingDataFromDataBase()
        {
            using (var logic = new IstarLogic())
            {
                Assert.That(logic.GetJobs().First().Jobtitle == "Тестовая задача",
                    "Тест на получение сущности из базы данных пройден.");
            }
        }

        [Test]
        public void D_UpdatingDataInDataBase()
        {
            using (var logic = new IstarLogic())
            {
                var job = logic.GetJobs().First();
                job.Iscomplete = false;
                logic.UpdateCurrentJob(job);
                Assert.That(logic.GetJobs().First().Iscomplete == false, "Тест на изменение сущности пройден.");
            }
        }

        [Test]
        public void E_DeletingDataFromDataBase()
        {
            using (var logic = new IstarLogic())
            {
                var job = logic.GetJobs().First();
                logic.DeleteCurrentJob(job);
                Assert.That(logic.GetJobs().Count == 0, "Тест на удаление сущности пройден.");
            }
        }

        [Test]
        public void F_DataBaseDeletingTest()
        {
            using (var dbcontext = new IstarContext())
            {
                if (dbcontext.Database.Exists())
        {
                    dbcontext.Database.Delete();
                }
                Assert.IsTrue(!dbcontext.Database.Exists(), "Тест на удаление базы данных пройден.");
                dbcontext.Dispose();
            }
        }
    }
}
