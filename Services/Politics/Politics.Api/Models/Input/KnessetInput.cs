using FluentValidation;

namespace Politics.Api.Models.Input
{
    public class KnessetInput
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool IsCurrent { get; set; }
    }

    public static class KnessetInputExtensions
    {
        public static BL.Models.Knesset ToBlModel(this KnessetInput input)
        {
            return new BL.Models.Knesset
            {
                Id = input.ID,
                Name = input.Name,
                FromDate = input.FromDate,
                ToDate = input.ToDate,
                IsCurrent = input.IsCurrent
            };
        }
    }

    public class KnessetInputValidator : AbstractValidator<KnessetInput>
    {
        public KnessetInputValidator()
        {
            RuleFor(knesset => knesset.Name).NotEmpty().WithMessage("Knesset name is required.");
            RuleFor(knesset => knesset.FromDate).NotEmpty().WithMessage("From date is required.");
            // Add other validation rules as needed
        }
    }
}
