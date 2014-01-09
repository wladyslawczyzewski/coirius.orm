﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Coirius.Orm.Test
{
    [TestClass]
    public class QueryBuilderTest
    {
        [TestMethod]
        public void SelectTest()
        {
            QueryBuilder queryBuilder = new QueryBuilder();
            IQueryBuilder builder = queryBuilder as IQueryBuilder;
            Assert.AreEqual(string.Empty, queryBuilder.Query);

            builder = builder.Select("FirstColumn", "SecondColumn");
            Assert.AreEqual("SELECT FirstColumn,SecondColumn", queryBuilder.Query);
            Assert.AreNotEqual("SELECT FirstColumn,SecondColumn,", queryBuilder.Query);
        }

        [TestMethod]
        public void WhereTest()
        {
            QueryBuilder queryBuilder = new QueryBuilder();
            IQueryBuilder builder = queryBuilder as IQueryBuilder;
            Assert.AreEqual(string.Empty, queryBuilder.Query);

            builder = builder.Select("FirstColumn", "SecondColumn");
            Assert.AreEqual("SELECT FirstColumn,SecondColumn", queryBuilder.Query);
            Assert.AreNotEqual("SELECT FirstColumn,SecondColumn,", queryBuilder.Query);

            builder = builder.Where(new EqualExpression(new OrmColumn { Name = "FirstColumn" }, "Test"));
            Assert.AreEqual("SELECT FirstColumn,SecondColumn WHERE (FirstColumn = N'Test');", queryBuilder.Query);
            Assert.AreNotEqual("SELECT FirstColumn,SecondColumn WHERE (FirstColumn = N'Test')", queryBuilder.Query);
        }

        [TestMethod]
        public void OrderByTest()
        {
            QueryBuilder queryBuilder = new QueryBuilder();
            IQueryBuilder builder = queryBuilder as IQueryBuilder;
            Assert.AreEqual(string.Empty, queryBuilder.Query);

            builder = builder.Select("FirstColumn", "SecondColumn");
            Assert.AreEqual("SELECT FirstColumn,SecondColumn", queryBuilder.Query);
            Assert.AreNotEqual("SELECT FirstColumn,SecondColumn,", queryBuilder.Query);

            builder = builder.Where(new EqualExpression(new OrmColumn { Name = "FirstColumn" }, "Test"));
            Assert.AreEqual("SELECT FirstColumn,SecondColumn WHERE (FirstColumn = N'Test');", queryBuilder.Query);
            Assert.AreNotEqual("SELECT FirstColumn,SecondColumn WHERE (FirstColumn = N'Test')", queryBuilder.Query);

            builder = builder.OrderBy("FirstColumn", OrmOrderBy.Asc);
            Assert.AreEqual("SELECT FirstColumn,SecondColumn WHERE (FirstColumn = N'Test') ORDER BY FirstColumn ASC;", queryBuilder.Query);
            Assert.AreNotEqual("SELECT FirstColumn,SecondColumn WHERE (FirstColumn = N'Test') ORDER BY SecondColumn ASC;", queryBuilder.Query);

            queryBuilder = new QueryBuilder();
            builder = queryBuilder as IQueryBuilder;
            Assert.AreEqual(string.Empty, queryBuilder.Query);

            builder = builder.Select("FirstColumn", "SecondColumn");
            Assert.AreEqual("SELECT FirstColumn,SecondColumn", queryBuilder.Query);
            Assert.AreNotEqual("SELECT FirstColumn,SecondColumn,", queryBuilder.Query);

            builder = builder.Where(new EqualExpression(new OrmColumn { Name = "FirstColumn" }, "Test"));
            Assert.AreEqual("SELECT FirstColumn,SecondColumn WHERE (FirstColumn = N'Test');", queryBuilder.Query);
            Assert.AreNotEqual("SELECT FirstColumn,SecondColumn WHERE (FirstColumn = N'Test')", queryBuilder.Query);

            builder = builder.OrderBy("FirstColumn", OrmOrderBy.Desc);
            Assert.AreEqual("SELECT FirstColumn,SecondColumn WHERE (FirstColumn = N'Test') ORDER BY FirstColumn DESC;", queryBuilder.Query);
            Assert.AreNotEqual("SELECT FirstColumn,SecondColumn WHERE (FirstColumn = N'Test') ORDER BY SecondColumn DESC;", queryBuilder.Query);
        }
    }
}