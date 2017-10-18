using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validation.Models;

namespace Validation.Validators
{
    public class MyValidationProvider : ModelValidatorProvider
    {
        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context)
        {
            if (metadata.ContainerType == typeof(Product))
            {
                return new ModelValidator[] { new ProductPropertyValidator(metadata, context) };
            }
            if (metadata.ModelType == typeof(Product))
            {
                return new ModelValidator[] { new ProductValidator(metadata, context) };
            }
            return Enumerable.Empty<ModelValidator>();            
        }
    }

    public class ProductPropertyValidator : ModelValidator
    {
        public ProductPropertyValidator(ModelMetadata metadata, ControllerContext context)
            : base(metadata, context)
        { }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            Product b = container as Product;
            if (b!=null)
            {
                switch (Metadata.PropertyName)
                {
                    case "Name" :
                        if (string.IsNullOrEmpty(b.Name))
                        {
                            return new ModelValidationResult[]
                            {
                                new ModelValidationResult{ MemberName="Name", Message="Enter name of product"}
                            };
                        }
                        break;
                    case "Manufacture":
                        if (string.IsNullOrEmpty(b.Manufacture))
                        {
                            return new ModelValidationResult[]
                            {
                                new ModelValidationResult{ MemberName="Manufacture", Message="Enter Manufacture of product"}
                            };
                        }
                        break;
                    case "Year":
                        if (b.Year > 2000 || b.Year < 1800)
                        {
                            return new ModelValidationResult[]
                            {
                                new ModelValidationResult {MemberName = "Year", Message="Incorrect Year"}
                            };
                        }
                        break;
                }
            }
            return Enumerable.Empty<ModelValidationResult>();
        }
    }

    public class ProductValidator : ModelValidator
    {
        public ProductValidator(ModelMetadata metadata, ControllerContext context)
            : base(metadata, context)
        { }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            Product product = (Product)Metadata.Model;

            List<ModelValidationResult> errors = new List<ModelValidationResult>();

            if (product.Manufacture == "Guness" && product.Year > 1910)
            {
                errors.Add(new ModelValidationResult { MemberName= "", Message= "Manufacture == Guness && product.Year > 1910" });
            }
            return errors;
        }
    }
}