using Ardalis.GuardClauses;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertiesApi.Application.Common.Wrappers;
using PropertiesApi.Application.Features.Properties.V1.DTOs;
using PropertiesApi.Domain.DTOs;
using PropertiesApi.Domain.Options.Pagination;
using System;

namespace PropertiesApi.Application.Features.Properties.V1.Queries
{
    public class GetListPropertiesQuery : IRequest<BaseResponse<Paged<GetListPropertiesResponse>>>
    {
        public List<FilterDto> Filters { get; set; } = [];
        public int? NumberPage { get; set; }
        public int? NumberRows { get; set; }
        public string OrderingField { get; set; } = string.Empty;
        public string SortDirection { get; set; } = string.Empty;
    }
}
