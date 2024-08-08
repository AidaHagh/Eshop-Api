using Shop.Domain.CategoryAgg;
using Shop.Query.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Categories
{
    internal static class CategoryMapper
    {
        public static CategoryDto Map(this Category category)
        {
            if (category == null)
                return null;

            return new CategoryDto()
            {
                Title = category.Title,
                Id = category.Id,
                Slug = category.Slug,
                SeoData = category.SeoData,
                CreationDate = category.CreationDate,
                Childs = category.Childs.MapChild()
            };
        }
        public static List<CategoryDto> Map(this List<Category> categories)
        {
            var model = new List<CategoryDto>();

            categories.ForEach(category =>
            {
                model.Add(new CategoryDto()
                {
                    Title = category.Title,
                    Id = category.Id,
                    Slug = category.Slug,
                    SeoData = category.SeoData,
                    CreationDate = category.CreationDate,
                    Childs = category.Childs.MapChild()
                });
            });
            return model;
        }

        public static List<ChildCategoryDto> MapChild(this List<Category> children)
        {
            var model = new List<ChildCategoryDto>();

            children.ForEach(c =>
            {
                model.Add(new ChildCategoryDto()
                {
                    Title = c.Title,
                    Id = c.Id,
                    Slug = c.Slug,
                    SeoData = c.SeoData,
                    CreationDate = c.CreationDate,
                    ParentId = (long)c.ParentId,
                    Childs = c.Childs.MapSecondaryChild()
                });
            });
            return model;
        }

        public static List<SecondaryChildCategoryDto> MapSecondaryChild(this List<Category> children)
        {
            var model = new List<SecondaryChildCategoryDto>();

            children.ForEach(c =>
            {
                model.Add(new SecondaryChildCategoryDto()
                {
                    Title = c.Title,
                    Id = c.Id,
                    Slug = c.Slug,
                    SeoData = c.SeoData,
                    CreationDate = c.CreationDate,
                    ParentId = (long)c.ParentId,

                });
            });
            return model;
        }
    }
}
