﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyOutputTypes(
  IVerifyAliased<IGqlpOutputObject> aliased,
  IMerge<IGqlpOutputField> mergeFields,
  IMerge<IGqlpOutputAlternate> mergeAlternates,
  ILoggerFactory logger
) : AstObjectVerifier<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputArg, IGqlpOutputField, IGqlpOutputAlternate, OutputContext>(aliased, mergeFields, mergeAlternates, logger)
{
  protected override void UsageValue(IGqlpOutputObject usage, OutputContext context)
  {
    IEnumerable<IGqlpOutputField> enumFields = usage.ObjFields
      .Where(f => !string.IsNullOrWhiteSpace(f.EnumLabel));

    foreach (IGqlpOutputField? enumField in enumFields) {
      if (string.IsNullOrWhiteSpace(enumField.EnumType.Name)) {
        if (context.GetEnumValue(enumField.EnumLabel!, out string? enumType)) {
          enumField.SetEnumType(enumType);
        } else {
          context.AddError(enumField, "Output Field Enum", $"Enum Value '{enumField.EnumLabel}' not defined");
        }
      } else {
        context.CheckEnumValue("Field", enumField);
      }
    }

    base.UsageValue(usage, context);
  }

  protected override void UsageField(IGqlpOutputField field, OutputContext context)
  {
    foreach (IGqlpInputParam parameter in field.Params) {
      CheckType(context, parameter.Type, " Param")
        .CheckModifiers(parameter);
    }

    base.UsageField(field, context);
  }

  protected override OutputContext MakeContext(IGqlpOutputObject usage, IGqlpType[] aliased, ITokenMessages errors)
  {
    Map<IGqlpDescribed> validTypes = aliased.AliasedGroup()
      .Select(p => (Id: p.Key, Type: (IGqlpDescribed)p.First()))
      .Concat(usage.TypeParams.Select(p => (Id: "$" + p.Name, Type: (IGqlpDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors, aliased.MakeEnumValues());
  }

  internal override void CheckArgType<TArg>(OutputContext context, TArg type, string suffix)
  {
    if (type is IGqlpOutputArg output) {
      if (string.IsNullOrWhiteSpace(output.EnumLabel) && context.GetEnumValue(type.Name, out string? enumType)) {
        output.SetEnumType(enumType);
      }

      if (!string.IsNullOrWhiteSpace(output.EnumLabel)) {
        context.CheckEnumValue("Arg", output);
      }
    }

    base.CheckArgType(context, type, suffix);
  }
}
