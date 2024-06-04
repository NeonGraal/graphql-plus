using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyOutputTypes(
  IVerifyAliased<IGqlpOutputObject> aliased,
  IMerge<IGqlpOutputField> mergeFields,
  IMerge<IGqlpAlternate<IGqlpOutputBase>> mergeAlternates,
  ILoggerFactory logger
) : AstObjectVerifier<IGqlpOutputObject, IGqlpOutputField, IGqlpOutputBase, OutputContext>(aliased, mergeFields, mergeAlternates, logger)
{
  protected override void UsageValue(IGqlpOutputObject usage, OutputContext context)
  {
    IEnumerable<IGqlpOutputField> enumFields = usage.Fields
      .Where(f => !string.IsNullOrWhiteSpace(f.Type.EnumValue));

    foreach (IGqlpOutputField? enumField in enumFields) {
      if (string.IsNullOrWhiteSpace(enumField?.Type.TypeName)) {
        if (context.GetEnumValue(enumField!.Type.EnumValue!, out string? enumType)) {
          enumField.Type.SetEnumType(enumType);
        } else {
          context.AddError(enumField, "Output Field Enum", $"Enum Value '{enumField.Type.EnumValue}' not defined");
        }
      } else {
        context.CheckEnumValue("Field", enumField.Type);
      }
    }

    base.UsageValue(usage, context);
  }

  protected override void UsageField(IGqlpOutputField field, OutputContext context)
  {
    foreach (IGqlpInputParameter parameter in field.Parameters) {
      context.CheckType(parameter.Type, " Parameter");

      context.CheckModifiers(parameter);
    }

    base.UsageField(field, context);
  }

  protected override OutputContext MakeContext(IGqlpOutputObject usage, IGqlpType[] aliased, ITokenMessages errors)
  {
    Map<IGqlpDescribed> validTypes = aliased.AliasedGroup()
      .Select(p => (Id: p.Key, Type: (IGqlpDescribed)p.First()))
      .Concat(usage.TypeParameters.Select(p => (Id: "$" + p.Name, Type: (IGqlpDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors, aliased.MakeEnumValues());
  }
}
