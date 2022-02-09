using FluentValidation;
using RestaurantAPI.Entities;
using System.Linq;

namespace RestaurantAPI.Models.Validators
{
    public class RestaurantQueryValidator : AbstractValidator<RestaurantQuery>
    {
        private int[] allowedPageSizes = new[] { 5, 10, 15 };
        private string[] allowedSortByColumnNames = { nameof(Restaurant.Name), nameof(Restaurant.Description), nameof(Restaurant.Category) };
        public RestaurantQueryValidator()
        {
            RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(r => r.PageSize).Custom((value,context) =>
            {
                if(!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PagesSize", $"Page Size must be in[{allowedPageSizes}]");
                }
            });

            RuleFor(r=> r.SortBy).Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
                .WithMessage($"SortBy is optional, or must be in[{string.Join(",", allowedSortByColumnNames)}]");

        }
    }
}
