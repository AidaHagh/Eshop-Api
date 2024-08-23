using Common.Application;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Domain.SellerAgg;
using Shop.Query.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.Presentation.Facade.Sellers;

public interface ISellerFacade
{
    Task<OperationResult> CreateSeller(CreateSellerCommand command);
    Task<OperationResult> EditSeller(EditSellerCommand command);


    Task<SellerDto?> GetSellerById(long sellerId);  
    Task<SellerDto?> GetSellerByUserId(long userId);  
    Task<SellerFilterResult> GetSellerByFilter(SellerFilterParams filterParams );  

}
