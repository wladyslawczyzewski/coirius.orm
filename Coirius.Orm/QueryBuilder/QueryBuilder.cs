﻿using System;

namespace Coirius.Orm
{
    public class QueryBuilder : AbstractQueryBuilder, IQueryBuilder
    {
        public IQueryBuilder Select(params string[] columnNames)
        {
            if (query.Length > 0)
            {
                query.Length--;
            }

            query.Append("SELECT ");
            foreach (string columnName in columnNames)
            {
                query.AppendFormat("{0},", columnName);
            }

            if (query.Length > 7)
            {
                query.Length--;
            }
            else if (query.Length == 7)
            {
                query.Append("*");
            }
            else
            {
                throw new Exception();
            }
            return this;
        }

        public IQueryBuilder Where(OrmExpression expr)
        {
            query.Append(" WHERE ");
            query.AppendFormat("{0};", expr);
            return this;
        }

        public IQueryBuilder OrderBy(string columnName, OrmOrderBy by)
        {
            if (query.ToString().EndsWith(";"))
            {
                query.Length--;
            }

            query.Append(" ORDER BY ");
            query.AppendFormat("{0} {1};", columnName, by.ToString().ToUpperInvariant());

            return this;
        }
    }
}