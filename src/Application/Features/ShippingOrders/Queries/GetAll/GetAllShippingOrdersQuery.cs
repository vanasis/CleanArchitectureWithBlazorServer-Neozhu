// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.ShippingOrders.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.ShippingOrders.Queries.GetAll;

    public class GetAllShippingOrdersQuery : IRequest<IEnumerable<ShippingOrderDto>>
    {
       
    }
    
    public class GetAllShippingOrdersQueryHandler :
         IRequestHandler<GetAllShippingOrdersQuery, IEnumerable<ShippingOrderDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<GetAllShippingOrdersQueryHandler> _localizer;

        public GetAllShippingOrdersQueryHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IStringLocalizer<GetAllShippingOrdersQueryHandler> localizer
            )
        {
            _context = context;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<IEnumerable<ShippingOrderDto>> Handle(GetAllShippingOrdersQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.ShippingOrders
                         .ProjectTo<ShippingOrderDto>(_mapper.ConfigurationProvider)
                         .ToListAsync(cancellationToken);
            return data;
        }
    }


