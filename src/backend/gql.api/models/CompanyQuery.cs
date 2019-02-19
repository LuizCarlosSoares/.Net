using gql.core.repository;
using GraphQL.Types;
using NHLStats.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gql.api.models
{
    public class CompanyQuery : ObjectGraphType
    {
        public CompanyQuery(ICompanyRepository companyRepository)
        {
            Field<CompanyType>(
                "company",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => companyRepository.Get(context.GetArgument<int>("id")));

            Field<CompanyType>(
                "randomCompany",
                resolve: context => companyRepository.GetRandom());

            Field<ListGraphType<CompanyType>>(
                "companies",
                resolve: context => companyRepository.All());
        }
    }
}



