﻿using Common.Domain.ValueObjects;
using Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Products.DTOs;

public class ProductDto:BaseDto
{
    public string Title { get; set; }
    public string ImageName { get; set; }
    public string Description { get; set; }
    public ProductCategoryDto Category { get; set; }
    public ProductCategoryDto SubCategory { get; set; }
    public ProductCategoryDto? SecondarySubCategory { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public List<ProductImageDto> Images { get; set; }
    public List<ProductSpecificationDto> Specifications { get; set; }
}

public class ProductCategoryDto
{
    public long Id { get; set; }
    public long? ParentId { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
}
public class ProductImageDto : BaseDto
{
    public long ProductId { get; set; }
    public string ImageName { get; set; }
    public int OrderOfImage { get; set; }
}

public class ProductSpecificationDto
{
    public string Key { get; set; }
    public string Value { get; set; }
}